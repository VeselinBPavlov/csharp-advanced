namespace MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var expr = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < expr.Length; i++)
            {
                if (expr[i] == '(')
                {
                    stack.Push(i);
                }
                if (expr[i] == ')')
                {
                    int start = stack.Pop();
                    int length = i - start + 1;

                    Console.WriteLine(expr.Substring(start, length));
                }
            }
        }
    }
}
