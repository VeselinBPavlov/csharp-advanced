namespace KnightsOfHonor
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => n.Trim())
                .ToList()
                .ForEach(Print);
        }

        public static Action<string> Print = n => Console.WriteLine($"Sir {n}");
    }
}
