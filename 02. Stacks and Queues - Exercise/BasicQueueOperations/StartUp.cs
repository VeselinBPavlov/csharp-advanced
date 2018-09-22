namespace BasicQueueOperations
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

            var queue = new Queue<int>(pushLenght);

            for (int i = 0; i < pushLenght; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < popLength; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(numToFind))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                var smallestNum = int.MaxValue;
                while (queue.Count > 0)
                {
                    var currentNum = queue.Dequeue();
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
