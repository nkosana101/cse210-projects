using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create one of each activity (using the spec's example dates)
            Activity running = new Running(new DateTime(2022, 11, 3), 30, 4.8);
            Activity cycling = new Cycling(new DateTime(2022, 11, 4), 45, 20.0);
            Activity swimming = new Swimming(new DateTime(2022, 11, 5), 25, 30);

            // Put them all in a single List (Polymorphism in action!)
            List<Activity> activities = new List<Activity> { running, cycling, swimming };

            // Loop through and call GetSummary on each
            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}