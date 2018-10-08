namespace AppliedArithmetics
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
                .Select(int.Parse)
                .ToList();

            var command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add": numbers = Add(numbers); break;
                    case "multiply": numbers = Multiply(numbers); break;
                    case "subtract": numbers = Subtract(numbers); break;
                    case "print": Print(numbers); break;
                    default: break;
                }

                command = Console.ReadLine();
            }
        }

        public static Func<List<int>, List<int>> Add = n => n.Select(x => x + 1).ToList();
        public static Func<List<int>, List<int>> Multiply = n => n.Select(x => x * 2).ToList();
        public static Func<List<int>, List<int>> Subtract = n => n.Select(x => x - 1).ToList();
        public static Action<List<int>> Print = arr => Console.WriteLine(String.Join(" ", arr));
    }
}
