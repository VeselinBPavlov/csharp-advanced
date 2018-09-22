namespace StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<long>();
            stack.Push(0);
            stack.Push(1);

            for (int i = 1; i < n; i++)
            {
                var currentNum = stack.Pop();
                var prevNum = stack.Peek();                
                stack.Push(currentNum);
                stack.Push(prevNum + currentNum);              
                
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
