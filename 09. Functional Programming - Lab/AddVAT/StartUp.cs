namespace AddVAT
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => n.Trim())
                .Select(AddVat)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:f2}"));
        }

        public static Func<string, double> AddVat = n => (double.Parse(n) * 1.2);
    }
}
