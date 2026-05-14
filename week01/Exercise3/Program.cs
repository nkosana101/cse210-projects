using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        string playAgain = "yes";

        while (playAgain == "yes")
        {
            // Core Requirement: Generate random magic number (1 to 100)
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = 0;
            int guessCount = 0;   // Stretch: count guesses

            // Core Requirement: Loop until guess is correct
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();
                guess = int.Parse(input);
                guessCount++;

                // Core Requirement: Give higher/lower feedback
                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // Stretch: Display number of guesses
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Stretch: Ask to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
            Console.WriteLine(); // blank line for readability
        }

        Console.WriteLine("Thanks for playing!");
    }
}