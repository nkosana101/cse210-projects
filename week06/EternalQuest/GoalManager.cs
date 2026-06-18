using System;
using System.Collections.Generic;
using System.IO;
using System.Linq; 

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    
    private int GetUserInt(string prompt)
    {
        int result;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out result))
        {
            Console.Write("Invalid input. Please enter a valid number: ");
        }
        return result;
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("  (No goals created yet.)");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("Select Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        int choice = GetUserInt("Choice: ");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        int points = GetUserInt("Points: ");

        switch (choice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, desc, points));
                break;

            case 2:
                _goals.Add(new EternalGoal(name, desc, points));
                break;

            case 3:
                int target = GetUserInt("Target Count: ");
                int bonus = GetUserInt("Bonus Points: ");
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;

            default:
                Console.WriteLine("Invalid choice. Goal not created.");
                return;
        }

        Console.WriteLine($"\n✅ Goal '{name}' created successfully!\n");
    }

    public void RecordEvent()
    {
        Console.Clear();
        
        
        if (_goals.Count == 0)
        {
            Console.WriteLine("You haven't created any goals yet!");
            return;
        }

        ListGoalDetails();

        int index = GetUserInt("\nSelect Goal: ") - 1;

        
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        int earned = _goals[index].RecordEvent();
        _score += earned;

        Console.WriteLine($"\n✅ You earned {earned} points!");
        Console.WriteLine($"🎯 Your new total score is: {_score}\n");
    }


    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
        
            writer.WriteLine(_score);

        
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"✅ Goals saved successfully to {filename}!");
    }

    
    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"❌ File {filename} not found. Starting with empty goals.");
            return;
        }

        using (StreamReader reader = new StreamReader(filename))
        {
        
            _score = int.Parse(reader.ReadLine());

        
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Goal goal = CreateGoalFromString(line);
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }
        Console.WriteLine($"✅ Goals loaded successfully from {filename}!");
    }


    private Goal CreateGoalFromString(string line)
    {
        string[] parts = line.Split('|');

        switch (parts[0])
        {
            case "SimpleGoal":
        
                return new SimpleGoal(
                    parts[1],                    // Name
                    parts[2],                    // Description
                    int.Parse(parts[3]),         // Points
                    bool.Parse(parts[4])         // IsComplete
                );

            case "EternalGoal":
            
                return new EternalGoal(
                    parts[1],                    // Name
                    parts[2],                    // Description
                    int.Parse(parts[3])          // Points
                );

            case "ChecklistGoal":
            
                return new ChecklistGoal(
                    parts[1],                    // Name
                    parts[2],                    // Description
                    int.Parse(parts[3]),         // Points
                    int.Parse(parts[5]),         // Target (index 5)
                    int.Parse(parts[4]),         // Bonus (index 4)
                    int.Parse(parts[6])          // AmountCompleted (index 6)
                );

            default:
                return null;
        }
    }
}