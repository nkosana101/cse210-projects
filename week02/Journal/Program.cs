using System;
using System.Collections.Generic;

namespace JournalProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            List<string> prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?",
                "What is something I learned today?" // extra prompt beyond 5
            };

            Random random = new Random();

            bool running = true;
            while (running)
            {
                Console.WriteLine("=== Journal Menu ===");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Write new entry
                        string randomPrompt = prompts[random.Next(prompts.Count)];
                        Console.WriteLine($"\nPrompt: {randomPrompt}");
                        Console.Write("Your response: ");
                        string response = Console.ReadLine();
                        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                        Entry newEntry = new Entry(currentDate, randomPrompt, response);
                        journal.AddEntry(newEntry);
                        Console.WriteLine("Entry added!\n");
                        break;

                    case "2":
                        // Display journal
                        Console.WriteLine("\n=== Journal Entries ===");
                        journal.DisplayAll();
                        break;

                    case "3":
                        // Save to file
                        Console.Write("Enter filename to save (e.g., journal.txt): ");
                        string saveFile = Console.ReadLine();
                        journal.SaveToFile(saveFile);
                        break;

                    case "4":
                        // Load from file
                        Console.Write("Enter filename to load: ");
                        string loadFile = Console.ReadLine();
                        journal.LoadFromFile(loadFile);
                        break;

                    case "5":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again.\n");
                        break;
                }
            }
        }
    }
}