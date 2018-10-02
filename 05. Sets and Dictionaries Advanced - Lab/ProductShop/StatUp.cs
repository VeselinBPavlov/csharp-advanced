namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StatUp
    {
        public static void Main()
        {
            var supermarkets = new Dictionary<string, Dictionary<string, double>>();

            var command = Console.ReadLine();

            // Add products in supermarkets.
            while (command != "Revision")
            {
                var data = command
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var supermarket = data[0];
                var product = data[1];
                var price = double.Parse(data[2]);

                if (supermarkets.ContainsKey(supermarket) == false)
                {
                    supermarkets[supermarket] = new Dictionary<string, double>();
                }

                supermarkets[supermarket].Add(product, price);

                command = Console.ReadLine();
            }

            // Print supermarkets, ordered by name.
            foreach (var supermarket in supermarkets.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{supermarket.Key}->");
                foreach (var product in supermarket.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
