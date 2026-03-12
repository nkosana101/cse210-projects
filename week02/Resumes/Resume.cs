using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    // Method to display the full resume
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();   // Use the Display method from the Job class
        }
    }
}