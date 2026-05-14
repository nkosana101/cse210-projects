using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement: Ask for grade percentage
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int percentage = int.Parse(input);

        // Core Requirement: Determine letter grade
        string letter = "";
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch Challenge: Determine sign (+ or -)
        string sign = "";
        int lastDigit = percentage % 10;

        // Only add sign for grades that are not exceptional cases
        // Exceptional cases: A+ doesn't exist, F+ and F- don't exist
        if (letter == "A")
        {
            // For A, only A- is possible (90-92), no A+
            if (lastDigit < 3 && percentage >= 90 && percentage <= 92)
            {
                sign = "-";
            }
            // else no sign (including 93-100, but we also ensure no A+)
        }
        else if (letter == "F")
        {
            // No + or - for F
            sign = "";
        }
        else
        {
            // For B, C, D: + for last digit >= 7, - for last digit < 3
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            // else no sign
        }

        // Display the final letter grade with sign (if any)
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Core Requirement: Determine if the user passed (70 or above)
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Don't give up! Better luck next time.");
        }
    }
}