using System;

/// <summary>
/// Base class for all goal types in the tracking system.
/// </summary>
public abstract class Goal
{
    public string Name { get; }
    public string Description { get; }
    public int Points { get; }

    protected Goal(string name, string description, int points)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        Points = points >= 0 ? points : throw new ArgumentOutOfRangeException(nameof(points));
    }

    /// <summary>
    /// Returns a display string for the goal, including its completion status.
    /// </summary>
    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description})";
    }

    /// <summary>
    /// Records progress for this goal and returns the points earned.
    /// </summary>
    public abstract int RecordEvent();

    /// <summary>
    /// Indicates whether the goal has been fully completed.
    /// </summary>
    public abstract bool IsComplete();

    /// <summary>
    /// Returns a string representation suitable for saving/loading.
    /// </summary>
    public abstract string GetStringRepresentation();
}