using System;


public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private readonly int _target;
    private readonly int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        
        if (_amountCompleted >= _target)
            return 0;

        
        _amountCompleted++;

    
        return _amountCompleted == _target ? Points + _bonus : Points;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        // Format: Type|Name|Description|Points|Bonus|Target|AmountCompleted
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_bonus}|{_target}|{_amountCompleted}";
    }
}