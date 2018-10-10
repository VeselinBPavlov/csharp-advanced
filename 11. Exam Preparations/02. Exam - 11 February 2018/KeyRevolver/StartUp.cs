namespace KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var bulletPrice = int.Parse(Console.ReadLine());
            var barrelSize = int.Parse(Console.ReadLine());
            var bulletsArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var lockerArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var earnedMoney = int.Parse(Console.ReadLine());

            var bullets = new Stack<int>(bulletsArr);
            var lockers = new Queue<int>(lockerArr);
        
            var counter = 0;
            var bulletsCount = 0;

            // Start shooting.
            while (true)
            {
                var bullet = bullets.Pop();
                var locker = lockers.Peek();

                // Check for sizes of bullet and lock.
                if (bullet > locker)
                {
                    Console.WriteLine("Ping!");                    
                }
                else
                {
                    Console.WriteLine("Bang!");
                    lockers.Dequeue();
                }

                bulletsCount++;
                counter++;

                // Print result.
                if (bullets.Count == 0 && lockers.Count == 0)
                {
                    var moneyLeft = earnedMoney - (bulletsCount * bulletPrice);
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyLeft}");
                    return;
                }

                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {lockers.Count}");
                    return;
                }
                
                if (counter == barrelSize)
                {
                    // Reload with new barrel.
                    counter = 0;
                    Console.WriteLine("Reloading!");
                }

                if (lockers.Count == 0)
                {
                    var moneyLeft = earnedMoney - (bulletsCount * bulletPrice);
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyLeft}");
                    return;
                }
            }
        }
    }
}
