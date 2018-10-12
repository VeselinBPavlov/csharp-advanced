namespace Regeh
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var pattern = @"\[[A-Za-z]+<(\d+)REGEH(\d+)>[A-Za-z]+]";
            var list = new List<int>();

            var matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                list.Add(int.Parse(match.Groups[1].Value));
                list.Add(int.Parse(match.Groups[2].Value));
            }

            var currentIndex = 0;
            foreach (var index in list)
            {
                currentIndex += index;
                var character = currentIndex % (input.Length - 1);
                Console.Write(input[character]);
            }
            Console.WriteLine();
        }
    }
}
