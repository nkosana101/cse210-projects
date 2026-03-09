using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        int percentage = int.Parse(input);

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

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Don't give up! Keep working hard for next time.");
        }

        string sign = "";
        int lastDigit = percentage % 10; 

        if (percentage >= 60 && percentage <= 100)
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
        }

        // --- Handle exceptional cases: no A+, no F+ or F- ---
        if (letter == "A")
        {
            if (sign == "+")   // A+ doesn't exist
            {
                sign = "";      // change to just A
            }
            // A- is fine, keep sign if it's "-"
        }
        else if (letter == "F")
        {
            // F has no sign at all
            sign = "";
        }

        // --- Final output ---
        // Combine letter and sign, but if sign is empty just print letter
        Console.WriteLine($"Your grade is: {letter}{sign}");
    }
}