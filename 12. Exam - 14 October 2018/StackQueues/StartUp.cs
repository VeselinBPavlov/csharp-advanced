namespace StackQueues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        public static void Main()
        {
            var cupsArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var bottlesArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var cups = new Queue<int>(cupsArr);
            var bottles = new Stack<int>(bottlesArr);
            var wastedWater = 0;

            while (true)
            {
                // Take bottle and cup.
                var cup = cups.Peek();
                var bottle = bottles.Peek();

                // Compare bottle and cup capacities.
                if (bottle >= cup)
                {
                    wastedWater += bottle - cup;
                    cups.Dequeue();
                    bottles.Pop();
                }
                else
                {
                    var difference = cup - bottle;
                    bottles.Pop();

                    // Take new bottle if cup is not full.
                    while (difference > 0)
                    {
                        difference -= bottles.Pop();
                    }

                    // Calculate wasted water.
                    wastedWater += Math.Abs(difference);
                    cups.Dequeue();
                }

                // Print result.
                if (cups.Count == 0)
                {
                    Console.WriteLine($"Bottles: {String.Join(" ", bottles)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    return;
                }

                if (bottles.Count == 0)
                {
                    Console.WriteLine($"Cups: {String.Join(" ", cups)}");
                    Console.WriteLine($"Wasted litters of water: {wastedWater}");
                    return;
                }
            }
        }
    }
}
