namespace BalancedParenthesis
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var brackets = Console.ReadLine();
            var stack = new Stack<char>();

            foreach (var bracket in brackets)
            {
                if (bracket == '{' || bracket == '[' || bracket == '(')
                {
                    stack.Push(bracket);
                } 
                else
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    var areBallanced = ((stack.Peek() == '{' && bracket == '}')
                                        || (stack.Peek() == '[' && bracket == ']')
                                        || (stack.Peek() == '(' && bracket == ')'));

                    if (areBallanced)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
