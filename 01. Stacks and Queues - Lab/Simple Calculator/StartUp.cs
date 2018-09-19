namespace SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var expr = Console.ReadLine().Split(' ').Reverse();
            var stack = new Stack<string>(expr);

            var sum = 0;
            sum += int.Parse(stack.Pop());
            while (stack.Count > 0)
            {                
                var oper = stack.Pop();
                var number = int.Parse(stack.Pop());

                if (oper == "+")
                {
                    sum += number;
                }
                else
                {
                    sum -= number;
                }
            }            

            Console.WriteLine(sum);
        }
    }
}
