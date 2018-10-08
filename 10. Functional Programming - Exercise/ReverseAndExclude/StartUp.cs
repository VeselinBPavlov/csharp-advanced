namespace ReverseAndExclude
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            Func<int, int, bool> Devide = (n, d) =>
            {
                Predicate<int> isDevidable = x => x % d != 0;

                return isDevidable(n) ? true : false;
            };

            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var devider = int.Parse(Console.ReadLine());

            Console.WriteLine(String.Join(' ', numbers.Where(x => Devide(x, devider)).Reverse().ToList()));
        }        
    }
}
