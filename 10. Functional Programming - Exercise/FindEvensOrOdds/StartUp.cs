namespace FindEvensOrOdds
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var interval = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Predicate<int> evenOrOdd = GetCondition();

            for (int i = interval[0]; i <= interval[1]; i++)
            {
                if (evenOrOdd(i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        private static Predicate<int> GetCondition()
        {
            var condition = Console.ReadLine();
            if (condition == "even")
            {
                return x => x % 2 == 0;
            }
            return x => x % 2 != 0;
        }
    }
}
