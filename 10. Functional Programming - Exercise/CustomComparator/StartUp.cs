namespace CustomComparator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Predicate<int> isEven = n => n % 2 == 0;

            var evenNums = numbers.Where(x => isEven(x)).ToArray();
            var oddNums = numbers.Where(x => !isEven(x)).ToArray();

            Array.Sort(evenNums, oddNums);
            Console.WriteLine(string.Join(" ", evenNums.Concat(oddNums)));
        }
    }
}
