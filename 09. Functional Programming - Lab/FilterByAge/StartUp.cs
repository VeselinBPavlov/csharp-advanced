namespace FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var namesCount = int.Parse(Console.ReadLine());
            var people = new List<KeyValuePair<string, int>>();

            // Fill list with people and their age.
            for (int i = 0; i < namesCount; i++)
            {
                var data = Console.ReadLine()
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var name = data[0];
                var age = int.Parse(data[1]);

                people.Add(new KeyValuePair<string, int>(name, age));
            }

            var condition = Console.ReadLine();
            var ageLimit = int.Parse(Console.ReadLine());
            var format = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // Filter people by criteria and print them.
            people.Where(p => condition == "younger" ? p.Value < ageLimit : p.Value >= ageLimit)
                .ToList()
                .ForEach(p => Printer(p, format));            
        }


        public static void Printer(KeyValuePair<string, int> person, string[] format)
        {
            if (format.Length == 2)
            {
                Console.WriteLine($"{person.Key} - {person.Value}");
            } 
            else
            {
                Console.WriteLine(format[0] == "name" ? $"{person.Key}" : $"{person.Value}");
            }
        }        
    }
}
