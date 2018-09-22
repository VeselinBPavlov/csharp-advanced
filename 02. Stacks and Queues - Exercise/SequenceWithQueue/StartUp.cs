namespace SequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            long num = long.Parse(Console.ReadLine());
            var queue = new Queue<long>(new long[] { num });
            int counter = 0;

            while (counter < 50)
            {
                queue.Enqueue(num + 1);
                queue.Enqueue(2 * num + 1);
                queue.Enqueue(num + 2);

                Console.Write(queue.Dequeue() + " ");
                num = queue.Peek();
                counter++;
            }
        }
    }
}
