using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace MindfulnessProgram
{
    // Base class for all mindfulness activities
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration; // in seconds

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        // Common starting message
        public void StartMessage()
        {
            Console.Clear();
            Console.WriteLine($"Starting {_name} Activity");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("How many seconds would you like to do this activity? ");
            _duration = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Get ready to begin...");
            ShowSpinner(3);
        }

        // Common ending message
        public void EndMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Good job!");
            ShowSpinner(2);
            Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
            ShowSpinner(3);
        }

        // Animation: spinning cursor
        protected void ShowSpinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            while (DateTime.Now < endTime)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(200);
                Console.Write("\b \b");
                i++;
            }
        }

        // Animation: countdown timer
        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        // Abstract method to be implemented by derived classes
        public abstract void Run();
    }

    // Breathing activity
    public class BreathingActivity : Activity
    {
        private int _breathDuration = 4; // seconds per breath in/out

        public BreathingActivity() : base("Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        public override void Run()
        {
            StartMessage();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.WriteLine();
                Console.Write("Breathe in... ");
                ShowCountdown(_breathDuration);
                Console.WriteLine();

                if (DateTime.Now >= endTime) break;

                Console.Write("Breathe out... ");
                ShowCountdown(_breathDuration);
                Console.WriteLine();
            }

            EndMessage();
        }
    }

    // Reflection activity with non‑repeating random prompts and questions
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private Random _random = new Random();

        public ReflectionActivity() : base("Reflection",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
        {
        }

        // Returns a shuffled copy of a list (to ensure non‑repeating random order)
        private List<T> ShuffleList<T>(List<T> list)
        {
            var shuffled = new List<T>(list);
            int n = shuffled.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                T value = shuffled[k];
                shuffled[k] = shuffled[n];
                shuffled[n] = value;
            }
            return shuffled;
        }

        public override void Run()
        {
            StartMessage();

            // Select a random prompt (once)
            string prompt = _prompts[_random.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();

            // Prepare a shuffled list of questions to cycle through without repetition
            List<string> shuffledQuestions = ShuffleList(_questions);
            int questionIndex = 0;

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                // Get next question (cycle through shuffled list)
                string question = shuffledQuestions[questionIndex % shuffledQuestions.Count];
                Console.Write($"> {question} ");
                // Wait between 5 seconds and remaining time, whichever is smaller
                int remaining = (int)(endTime - DateTime.Now).TotalSeconds;
                int pauseTime = Math.Min(5, remaining);
                if (pauseTime > 0)
                    ShowSpinner(pauseTime);
                else
                    break;
                Console.WriteLine();
                questionIndex++;
            }

            EndMessage();
        }
    }

    // Listing activity with non‑repeating random prompts
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private Random _random = new Random();

        public ListingActivity() : base("Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        public override void Run()
        {
            StartMessage();

            // Select a random prompt
            string prompt = _prompts[_random.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.WriteLine("You have a few seconds to think about the prompt...");
            ShowCountdown(5);

            Console.WriteLine();
            Console.WriteLine("Now start listing items (press Enter after each item).");
            Console.WriteLine("Type 'done' to finish early, or keep going until time runs out.");
            Console.WriteLine();

            List<string> items = new List<string>();
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (input.ToLower() == "done")
                    break;
                if (!string.IsNullOrWhiteSpace(input))
                    items.Add(input);
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} items!");
            EndMessage();
        }
    }

    // Additional feature: Activity Logger (exceeds core requirements)
    // Keeps a log file and also provides session summary.
    public static class ActivityLogger
    {
        private static string logFile = "activity_log.txt";
        private static List<string> sessionLog = new List<string>();

        public static void LogActivity(string activityName, int durationSeconds)
        {
            string entry = $"{DateTime.Now}: {activityName} activity for {durationSeconds} seconds.";
            sessionLog.Add(entry);
            // Append to file
            using (StreamWriter sw = File.AppendText(logFile))
            {
                sw.WriteLine(entry);
            }
        }

        public static void ShowSessionSummary()
        {
            Console.Clear();
            Console.WriteLine("===== Session Summary =====");
            if (sessionLog.Count == 0)
            {
                Console.WriteLine("No activities performed in this session.");
            }
            else
            {
                foreach (string entry in sessionLog)
                {
                    Console.WriteLine(entry);
                }
                Console.WriteLine($"\nTotal activities: {sessionLog.Count}");
            }
            Console.WriteLine("\nPress Enter to return to menu.");
            Console.ReadLine();
        }

        public static void ShowFullLog()
        {
            Console.Clear();
            Console.WriteLine("===== Complete Activity Log =====");
            if (File.Exists(logFile))
            {
                string logContent = File.ReadAllText(logFile);
                Console.WriteLine(logContent);
            }
            else
            {
                Console.WriteLine("No log file found.");
            }
            Console.WriteLine("\nPress Enter to return to menu.");
            Console.ReadLine();
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mindfulness Program";
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("==================");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. View Session Summary");
                Console.WriteLine("5. View Complete Log");
                Console.WriteLine("6. Quit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        ActivityLogger.ShowSessionSummary();
                        continue;
                    case "5":
                        ActivityLogger.ShowFullLog();
                        continue;
                    case "6":
                        running = false;
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Press Enter to try again.");
                        Console.ReadLine();
                        continue;
                }

                if (activity != null)
                {
                    activity.Run();
                    ActivityLogger.LogActivity(activity.GetType().Name, activity._duration);
                    Console.WriteLine("\nPress Enter to return to menu.");
                    Console.ReadLine();
                }
            }

            Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
        }
    }
}