namespace UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var namesCount = int.Parse(Console.ReadLine());
            var names = new HashSet<string>();

            // Collect unique names.
            for (int i = 0; i < namesCount; i++)
            {
                names.Add(Console.ReadLine());
            }

            // Print names.
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
