namespace PredicateForNames
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var nameLength = int.Parse(Console.ReadLine());

            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(n => SortNames(n, nameLength))
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }

        public static Func<string, int, bool> SortNames = (n, l) => n.Length <= l;
    }
}
