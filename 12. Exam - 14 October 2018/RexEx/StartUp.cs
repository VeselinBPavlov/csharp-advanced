namespace DataTransfer
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            var inputPattern = @"s:([^;]+);r:([^;]+);m--(""[A-Za-z ]+"")";

            var inputCount = int.Parse(Console.ReadLine());
            var totalData = 0;

            for (int i = 0; i < inputCount; i++)
            {
                var input = Console.ReadLine();

                // Match valid input.
                var match = Regex.Match(input, inputPattern);

                if (match.Success == false)
                {
                    continue;
                }

                // Match sender, receiver and message.
                var senderRgx = match.Groups[1].Value;
                var receiverRxg = match.Groups[2].Value;
                var message = match.Groups[3].Value;                

                // Filter sender name.
                var sender = senderRgx
                    .Where(x => Char.IsLetter(x) || x == ' ')
                    .ToArray();

                // Filter receiver name.
                var receiver = receiverRxg
                    .Where(x => Char.IsLetter(x) || x == ' ')
                    .ToArray();

                // Calculate total data.
                totalData += (senderRgx + receiverRxg)
                    .Where(x => Char.IsDigit(x))
                    .Select(x => int.Parse(x.ToString()))
                    .ToList()
                    .Sum();

                Console.WriteLine($"{String.Join("", sender)} says {message} to {String.Join("", receiver)}");
            }

            Console.WriteLine($"Total data transferred: {totalData}MB");
        }
    }
}
