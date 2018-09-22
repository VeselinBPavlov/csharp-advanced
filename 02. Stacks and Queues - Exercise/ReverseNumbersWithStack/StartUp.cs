namespace ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse);
               

            var stack = new Stack<int>(input);

            while (stack.Count > 0)
            {
                Console.Write($"{stack.Pop()} ");
            }
            Console.WriteLine();
        }
    }
}
