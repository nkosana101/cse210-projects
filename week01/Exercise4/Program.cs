using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Collect numbers until user enters 0 (do not add 0 to list)
        while (true)
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            if (number == 0)
                break;

            numbers.Add(number);
        }

        // Core: sum, average, max
        int sum = 0;
        int max = int.MinValue;

        foreach (int num in numbers)
        {
            sum += num;
            if (num > max)
                max = num;
        }

        double average = numbers.Count > 0 ? (double)sum / numbers.Count : 0;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch 1: smallest positive number (closest to zero)
        int? smallestPositive = null;
        foreach (int num in numbers)
        {
            if (num > 0 && (smallestPositive == null || num < smallestPositive))
                smallestPositive = num;
        }

        if (smallestPositive.HasValue)
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        else
            Console.WriteLine("No positive numbers were entered.");

        // Stretch 2: sort and display the sorted list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
            Console.WriteLine(num);
    }
}