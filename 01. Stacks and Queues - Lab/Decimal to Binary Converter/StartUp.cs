namespace DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var reminder = 0;

            while (number > 0)
            {
                reminder = number % 2;
                stack.Push(reminder);
                number /= 2;
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
            Console.WriteLine();
        }
    }
}
