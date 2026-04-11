public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    // PROBLEM 1: Insert UNIQUE values only
    public void Insert(int value)
    {
        if (value == Data)
        {
            return; // ignore duplicates
        }

        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    // PROBLEM 2: Contains (recursive search)
    public bool Contains(int value)
    {
        if (value == Data)
            return true;

        if (value < Data)
            return Left != null && Left.Contains(value);

        return Right != null && Right.Contains(value);
    }

    // PROBLEM 4: Height of tree
    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}