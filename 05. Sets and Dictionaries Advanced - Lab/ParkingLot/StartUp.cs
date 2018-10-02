namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var data = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            var parking = new HashSet<string>();

            // Manage cars in parking.
            while (data[0]?.ToLower() != "end")
            {
                var direction = data[0];
                var carNumber = data[1];

                switch (direction)
                {
                    case "IN": parking.Add(carNumber); break;
                    case "OUT": parking.Remove(carNumber); break;
                    default: break;
                }

                data = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
            }

            // Print cars in parking.
            if (parking.Any())
            {
                foreach (var carNumber in parking)
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
