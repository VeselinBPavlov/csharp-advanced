namespace PeriodicTable
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var compoundsCount = int.Parse(Console.ReadLine());
            var chemicalCompounds = new SortedSet<string>();

            // Take chemical compounds.
            for (int i = 0; i < compoundsCount; i++)
            {
                var compounds = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var compound in compounds)
                {
                    chemicalCompounds.Add(compound);
                }
            }

            // Print chemical compounds in ascending order.
            Console.WriteLine(String.Join(' ', chemicalCompounds));
        }
    }
}
