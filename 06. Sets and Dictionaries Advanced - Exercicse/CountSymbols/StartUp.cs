namespace CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var text = Console.ReadLine();
            var counter = new SortedDictionary<char, int>();

            // Count character in text.
            foreach (var character in text)
            {
                if (counter.ContainsKey(character) == false)
                {
                    counter[character] = 0;
                }
                counter[character]++;
            }

            // Print result.
            foreach (var character in counter)
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}
