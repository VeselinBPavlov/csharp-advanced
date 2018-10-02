namespace EvenTimes
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var numCount = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<int, int>();

            // Add numbers in dictionary.
            for (int i = 0; i < numCount; i++)
            {
                var number = int.Parse(Console.ReadLine());

                if (numbers.ContainsKey(number) == false)
                {
                    numbers[number] = 0;
                }
                numbers[number]++;
            }

            // Find number with even times of appears.
            foreach (var num in numbers)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                    break;
                }
            }
        }
    }
}
