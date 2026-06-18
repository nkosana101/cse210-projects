using System;

/// <summary>
/// Represents a goal that is never fully completed and awards points 
/// every time the user records an event.
/// </summary>
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent() => Points;

    public override bool IsComplete() => false;

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}";
    }
}