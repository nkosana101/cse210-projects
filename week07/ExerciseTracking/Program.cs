using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Activity running = new Running(new DateTime(2022, 11, 3), 30, 4.8);
            Activity cycling = new Cycling(new DateTime(2022, 11, 4), 45, 20.0);
            Activity swimming = new Swimming(new DateTime(2022, 11, 5), 25, 30);

            
            List<Activity> activities = new List<Activity> { running, cycling, swimming };

            
            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}