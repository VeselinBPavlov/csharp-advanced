namespace RecordUniqueNames
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var namesCount = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();

            for (int i = 0; i < namesCount; i++)
            {
                // If set contains the name - it ignores it.
                set.Add(Console.ReadLine());
            }

            foreach (var name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}
