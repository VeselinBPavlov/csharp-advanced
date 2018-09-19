namespace ReverseString
{
    using System;
    using System.Collections.Generic;


    public class StartUp
    {
        public static void Main()
        {
            var str = Console.ReadLine();
            var stack = new Stack<char>();

            foreach (var letter in str)
            {
                stack.Push(letter);
            }

            foreach (var letter in stack)
            {
                Console.Write(letter);
            }
            Console.WriteLine();
        }
    }
}
