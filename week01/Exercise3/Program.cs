using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        string playAgain = "yes";

        // Stretch challenge: loop to play again
        while (playAgain == "yes")
        {
            // Core requirement 3: random number from 1 to 100
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;   // Stretch challenge: count guesses

            // Core requirement 2: keep looping until guessed correctly
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

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

            // Stretch challenge: display number of guesses
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Stretch challenge: ask to play again
            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine().ToLower();
        }

        Console.WriteLine("Thanks for playing!");
    }
}