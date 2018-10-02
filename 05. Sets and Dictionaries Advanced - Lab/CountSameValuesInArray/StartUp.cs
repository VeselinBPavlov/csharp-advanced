namespace CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var dictionary = new Dictionary<double, int>();

            // Create unique keys of numbers and count them.
            foreach (var number in numbers)
            {
                if (dictionary.ContainsKey(number) == false)
                {
                    dictionary[number] = 0;
                }

                dictionary[number]++;
            }

            // Print dictionary.
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
