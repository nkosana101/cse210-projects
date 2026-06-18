using System;



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

    
    
    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description})";
    }

    
    
    public abstract int RecordEvent();

    
    
    public abstract bool IsComplete();


    
    public abstract string GetStringRepresentation();
}