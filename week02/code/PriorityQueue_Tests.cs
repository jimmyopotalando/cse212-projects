using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them.
    // Expected Result: Items are dequeued in descending priority order.
    // Defect(s) Found: If Dequeue does not remove highest priority, this test will fail.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("low", 1);
        pq.Enqueue("medium", 5);
        pq.Enqueue("high", 10);

        Assert.AreEqual("high", pq.Dequeue());
        Assert.AreEqual("medium", pq.Dequeue());
        Assert.AreEqual("low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority and dequeue them.
    // Expected Result: Items with the same priority are dequeued in FIFO order.
    // Defect(s) Found: If Dequeue does not respect FIFO for same priority, this test will fail.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("first", 5);
        pq.Enqueue("second", 5);
        pq.Enqueue("third", 5);

        Assert.AreEqual("first", pq.Dequeue());
        Assert.AreEqual("second", pq.Dequeue());
        Assert.AreEqual("third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: If exception is not thrown for empty queue, this test will fail.
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Enqueue items in mixed order and check priority removal.
    // Expected Result: Highest priority is always dequeued first, then next highest, etc.
    // Defect(s) Found: Any misordering in Dequeue will fail this test.
    public void TestPriorityQueue_MixedOrder()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("a", 3);
        pq.Enqueue("b", 10);
        pq.Enqueue("c", 1);
        pq.Enqueue("d", 10); // Same highest priority as "b"

        Assert.AreEqual("b", pq.Dequeue()); // FIFO for same high priority
        Assert.AreEqual("d", pq.Dequeue());
        Assert.AreEqual("a", pq.Dequeue());
        Assert.AreEqual("c", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue single item and dequeue repeatedly.
    // Expected Result: Dequeue returns that item and queue becomes empty afterward.
    // Defect(s) Found: Any error in handling single-element queue will fail this test.
    public void TestPriorityQueue_SingleItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("only", 7);
        Assert.AreEqual("only", pq.Dequeue());

        var ex = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }
}