namespace HotPotato
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split(' ');
            var toss = int.Parse(Console.ReadLine());
            var queue = new Queue<string>(names);
            
            while (queue.Count > 1)
            {
                for (int i = 1; i <= toss; i++)
                {
                    if (i == toss)
                    {
                        Console.WriteLine($"Removed {queue.Dequeue()}");
                    }
                    else
                    {
                        queue.Enqueue(queue.Dequeue());
                    }
                }                
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
