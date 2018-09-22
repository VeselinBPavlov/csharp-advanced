namespace MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            var maxNum = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var operation = input[0];

                switch (operation)
                {
                    case 1:
                        {
                            stack.Push(input[1]);
                            if (maxNum < input[1])
                            {
                                maxNum = input[1];
                            }
                        } break;
                    case 2:
                        {
                            stack.Pop();
                            if (stack.Count > 0)
                            {
                                maxNum = stack.ToArray().OrderBy(x => x).Last();
                            }
                            else
                            {
                                maxNum = int.MinValue;
                            }

                        } break;
                    case 3:
                        {
                            Console.WriteLine(maxNum);                           
                        } break;
                    default: break;
                }

            }
        }
    }
}
