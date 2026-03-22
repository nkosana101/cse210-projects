class Program
{
    static void Main()
    {
         Create a scripture
        Reference reference = new Reference("John", 3, 16);
        string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";

         Alternative example with multiple verses:
         Reference reference = new Reference("Proverbs", 3, 5, 6);
         string scriptureText = "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";

        Scripture scripture = new Scripture(reference, scriptureText);

        Console.WriteLine("Scripture Memorizer");
        Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit.\n");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input?.ToLower() == "quit")
                break;

            if (input == "")
            {
                 Hide up to 3 words per turn (adjust as desired)
                scripture.HideRandomWords(3);

                if (scripture.AllWordsHidden())
                {
                    Console.Clear();
                    Console.WriteLine(scripture.GetDisplayText());
                    Console.WriteLine("\nAll words are hidden. Program ending.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to hide words or type 'quit'.");
                Console.ReadKey();
            }
        }

        Console.WriteLine("\nThank you for using the Scripture Memorizer!");
    }
}