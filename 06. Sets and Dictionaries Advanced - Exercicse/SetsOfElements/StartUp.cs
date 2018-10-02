namespace SetsOfElements
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var lenghtsOfSets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var firstLength = int.Parse(lenghtsOfSets[0]);
            var secondLength = int.Parse(lenghtsOfSets[1]);

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            // Fill first set.
            for (int i = 0; i < firstLength; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            // Fill second set.
            for (int i = 0; i < secondLength; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            // Find duplicate numbers.
            foreach (var firstNumber in firstSet)
            {
                foreach (var secondNumber in secondSet)
                {
                    if (firstNumber == secondNumber)
                    {
                        Console.Write($"{firstNumber} ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
