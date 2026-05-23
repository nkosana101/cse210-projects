using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ScriptureMemorizer
{
    /*
        CREATIVITY & EXCEEDING REQUIREMENTS:
        1. Scripture library loaded from a text file (scriptures.txt) - supports multiple scriptures.
        2. Random scripture selection at the start of the program.
        3. When hiding words, only words that are NOT already hidden are considered.
        4. The number of words hidden per step is random (1 to 3), making memorization practice more dynamic.
        5. If the user completes all words, the program ends gracefully showing the fully hidden scripture.
    */
    class Program
    {
        static void Main(string[] args)
        {
            // Load scriptures from file (creativity)
            List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");
            if (scriptures.Count == 0)
            {
                Console.WriteLine("No scriptures found. Using a default scripture.");
                Reference defaultRef = new Reference("John", 3, 16);
                scriptures.Add(new Scripture(defaultRef, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
            }

            // Randomly select a scripture (creativity)
            Random random = new Random();
            Scripture currentScripture = scriptures[random.Next(scriptures.Count)];

            // Main loop
            while (true)
            {
                Console.Clear();
                Console.WriteLine(currentScripture.GetDisplayText());
                Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");

                string input = Console.ReadLine();
                if (input?.ToLower() == "quit")
                    break;

                // Hide a random number of words (1 to 3) among still-visible words (creativity)
                bool moreToHide = currentScripture.HideRandomWords(random.Next(1, 4));
                if (!moreToHide)
                {
                    // All words are hidden; show final state and exit
                    Console.Clear();
                    Console.WriteLine(currentScripture.GetDisplayText());
                    Console.WriteLine("\nAll words are hidden. Great job memorizing!");
                    break;
                }
            }
        }

        /// <summary>
        /// Loads scriptures from a text file.
        /// File format: reference|text
        /// Example: John 3:16|For God so loved the world...
        /// Example: Proverbs 3:5-6|Trust in the Lord with all thine heart...
        /// </summary>
        static List<Scripture> LoadScripturesFromFile(string filename)
        {
            List<Scripture> scriptures = new List<Scripture>();
            if (!File.Exists(filename))
            {
                // Create a default file if it doesn't exist
                CreateDefaultScriptureFile(filename);
            }

            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                string[] parts = line.Split('|');
                if (parts.Length != 2)
                    continue;

                string refPart = parts[0].Trim();
                string text = parts[1].Trim();

                Reference reference = ParseReference(refPart);
                if (reference != null)
                {
                    scriptures.Add(new Scripture(reference, text));
                }
            }
            return scriptures;
        }

        /// <summary>
        /// Creates a default scriptures.txt file with some sample scriptures.
        /// </summary>
        static void CreateDefaultScriptureFile(string filename)
        {
            string[] defaultScriptures = {
                "John 3:16|For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.",
                "Proverbs 3:5-6|Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.",
                "Psalm 23:1|The Lord is my shepherd; I shall not want.",
                "Philippians 4:13|I can do all things through Christ which strengtheneth me."
            };
            File.WriteAllLines(filename, defaultScriptures);
        }

        /// <summary>
        /// Parses a reference string like "John 3:16" or "Proverbs 3:5-6".
        /// Returns a Reference object or null if invalid.
        /// </summary>
        static Reference ParseReference(string refString)
        {
            // Expected format: "Book Chapter:Verse" or "Book Chapter:StartVerse-EndVerse"
            string[] spaceParts = refString.Split(' ');
            if (spaceParts.Length < 2) return null;

            string book = string.Join(" ", spaceParts.Take(spaceParts.Length - 1));
            string chapterVerse = spaceParts.Last();

            string[] cvParts = chapterVerse.Split(':');
            if (cvParts.Length != 2) return null;

            if (!int.TryParse(cvParts[0], out int chapter))
                return null;

            string versePart = cvParts[1];
            if (versePart.Contains('-'))
            {
                string[] verses = versePart.Split('-');
                if (verses.Length == 2 &&
                    int.TryParse(verses[0], out int startVerse) &&
                    int.TryParse(verses[1], out int endVerse))
                {
                    return new Reference(book, chapter, startVerse, endVerse);
                }
            }
            else
            {
                if (int.TryParse(versePart, out int singleVerse))
                {
                    return new Reference(book, chapter, singleVerse);
                }
            }
            return null;
        }
    }
}