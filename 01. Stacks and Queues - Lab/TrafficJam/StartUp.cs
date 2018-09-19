namespace TrafficJam
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var trafficLimit = int.Parse(Console.ReadLine());
            var queueCars = new Queue<string>();
            var passedCars = 0;
            var input = Console.ReadLine();

            while (input != "end")
            {
                if (input != "green")
                {
                    queueCars.Enqueue(input);
                }
                else
                {
                    var length = Math.Min(queueCars.Count, trafficLimit);
                    for (int i = 0; i < length; i++)
                    {
                        Console.WriteLine($"{queueCars.Dequeue()} passed!");
                        passedCars++;
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
