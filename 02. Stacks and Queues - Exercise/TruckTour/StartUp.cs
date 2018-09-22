namespace TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var pumps = long.Parse(Console.ReadLine());

            var stations = new Queue<long>();

            for (int i = 0; i < pumps; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var petrol = input[0];
                var distance = input[1];
                stations.Enqueue(petrol - distance);
            }

            for (int i = 0; i < pumps; i++)
            {
                long fuelLeft = 0;
                foreach (var fuel in stations)
                {
                    fuelLeft += fuel;
                    if (fuelLeft < 0)
                    {
                        break;
                    }
                }

                if (fuelLeft >= 0)
                {
                    Console.WriteLine(i);
                    return;
                }
                stations.Enqueue(stations.Dequeue());
            }
        }
    }
}
