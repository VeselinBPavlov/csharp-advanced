namespace BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var data = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            

            var pushLenght = data[0];
            var popLength = data[1];
            var numToFind = data[2];

            var stack = new Stack<int>(pushLenght);

            for (int i = 0; i < pushLenght; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < popLength; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(numToFind))
            {
                Console.WriteLine("true");
            } 
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                var smallestNum = int.MaxValue;
                while (stack.Count > 0)
                {
                    var currentNum = stack.Pop();
                    if (currentNum < smallestNum)
                    {
                        smallestNum = currentNum;
                    }
                }

                Console.WriteLine(smallestNum);
            }

        }
    }
}
