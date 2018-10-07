namespace SortEvenNumbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine(String.Join(", ", Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray()));
        }
    }
}
