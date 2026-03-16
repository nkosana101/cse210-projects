using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();
    private static Random _random = new Random();

    public PromptGenerator()
    {
        _prompts.Add("Who was the most interesting person I met with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
    }

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
            return "No prompts available.";

        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}