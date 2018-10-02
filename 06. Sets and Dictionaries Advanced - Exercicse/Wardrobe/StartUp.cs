namespace Wardrobe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var clothesCount = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            // Count colors of clothes and their count.
            for (int i = 0; i < clothesCount; i++)
            {
                var clothes = Console.ReadLine()
                    .Split(new[] { "->", "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();

                var color = clothes[0];
                clothes = clothes.Skip(1).ToList();

                if (wardrobe.ContainsKey(color) == false)
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                foreach (var wear in clothes)
                {
                    if (wardrobe[color].ContainsKey(wear) == false)
                    {
                        wardrobe[color][wear] = 0;
                    }
                    wardrobe[color][wear]++;
                }
            }

            // Find specific wear.
            var searchedWear = Console.ReadLine().Split(' ');
            var colorToFind = searchedWear[0];
            var wearToFind = searchedWear[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                if (color.Key != colorToFind)
                {
                    foreach (var wear in color.Value)
                    {
                        Console.WriteLine($"* {wear.Key} - {wear.Value}");
                    }
                }
                else
                {
                    foreach (var wear in color.Value)
                    {
                        if (wear.Key == wearToFind)
                        {
                            Console.WriteLine($"* {wear.Key} - {wear.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {wear.Key} - {wear.Value}");
                        }
                    }
                }
            }
        }
    }
}
