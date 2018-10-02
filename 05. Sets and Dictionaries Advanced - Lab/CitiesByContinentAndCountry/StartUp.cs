namespace CitiesByContinentAndCountry
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var inputCount = int.Parse(Console.ReadLine());

            var register = new Dictionary<string, Dictionary<string, List<string>>>();

            // Fill register with continents, countries and towns.
            for (int i = 0; i < inputCount; i++)
            {
                var data = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var continent = data[0];
                var country = data[1];
                var town = data[2];

                if (register.ContainsKey(continent) == false)
                {
                    register[continent] = new Dictionary<string, List<string>>();
                }

                if (register[continent].ContainsKey(country) == false)
                {
                    register[continent][country] = new List<string>();
                }

                register[continent][country].Add(town);
            }

            // Print register.
            foreach (var continent in register)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {String.Join(", ", country.Value)}");
                }
            }

        }
    }
}
