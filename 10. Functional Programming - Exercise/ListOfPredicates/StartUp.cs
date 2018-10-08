namespace ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var limiter = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var result = new List<int>();

            for (int i = 1; i <= limiter; i++)
            {
                if (IsDivisible(i, numbers))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }

        public static Func<int, int[], bool> IsDivisible = (n, arr) =>
        {            
            foreach (var num in arr)
            {
                if (n % num != 0)
                {
                    return false;
                }
            }
            return true;
        };
    }
}
