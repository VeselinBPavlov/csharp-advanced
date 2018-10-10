namespace CryptoBlockchain
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            var inputCount = int.Parse(Console.ReadLine());
            var crypto = "";
            var digits = new List<string>();
            var legths = new List<int>();
            var code = "";

            var pattern = @"{[^\[\]{]+}|\[[^{}\[]+\]";
            var numPattern = @"[0-9]{3,}";

            for (int i = 0; i < inputCount; i++)
            {
                crypto += Console.ReadLine();                
            }

            // Match entire block.
            MatchCollection matches = Regex.Matches(crypto, pattern);

            foreach (Match match in matches)
            {
                var groupDigits = match.ToString();
                legths.Add(groupDigits.Length);

                // Matching digits.
                var digitsMatch = new Regex(numPattern);                
                var matchDigits = digitsMatch.Match(groupDigits).ToString();

                if (matchDigits.Length % 3 != 0)
                {
                    continue;
                }

                digits.Add(matchDigits);
            }

            // Decrypting code.
            for (int i = 0; i < digits.Count; i++)
            {
                for (int j = 0; j < digits[i].Length; j+=3)
                {
                    var firstDigit = digits[i][j].ToString();
                    var seconDigit = digits[i][j + 1].ToString();
                    var thirdDigit = digits[i][j + 2].ToString();

                    var numStr = firstDigit + seconDigit + thirdDigit;
                    var num = (int.Parse(numStr)) - legths[i];
                    var character = (char)num;
                    code += character;
                }
            }

            Console.WriteLine(code);
        }
    }
}
