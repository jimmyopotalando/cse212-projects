/// <summary>
/// Circular queue where people have finite or infinite turns
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add a new person to the queue with a name and number of turns.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them.
    /// Person goes back to the queue if they have remaining turns or infinite turns.
    /// Throws exception if queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
            throw new InvalidOperationException("No one in the queue.");

        Person person = _people.Dequeue();

        // Infinite turns (0 or negative)
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        else
        {
            // Finite turns: decrement
            person.Turns -= 1;
            if (person.Turns != 0) // still has turns left
            {
                _people.Enqueue(person);
            }
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
