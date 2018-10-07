namespace CountUppercaseWords
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine(String.Join('\n', Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(x => IsUpper(x[0]))
                .ToList()));
        }

        public static Func<char, bool> IsUpper = c => Char.IsUpper(c);
    }
}
