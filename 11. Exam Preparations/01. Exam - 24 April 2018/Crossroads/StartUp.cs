namespace Crossroads
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var greenLight = int.Parse(Console.ReadLine());
            var freeWindow = int.Parse(Console.ReadLine());

            var queue = new Queue<string>();
            var counter = 0;
            char crash = '\0';
            var isCrashed = false;

            var command = Console.ReadLine();
            while (command != "END")
            {
                if (command != "green")
                {
                    queue.Enqueue(command);
                }
                else
                {
                    var time = greenLight;

                    while (time > 0)
                    {
                        if (queue.Count == 0)
                        {
                            break;
                        }

                        var car = queue.Peek();

                        if (time >= car.Length)
                        {
                            queue.Dequeue();
                            time -= car.Length;
                            counter++;
                        }
                        else
                        {
                            if ((time + freeWindow) >= car.Length)
                            {
                                queue.Dequeue();
                                time -= car.Length;
                                counter++;
                            }
                            else
                            {
                                crash = car[time + freeWindow];
                                isCrashed = true;
                                break;
                            }
                        }
                    }
                }

                if (isCrashed)
                {
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{queue.Dequeue()} was hit at {crash}.");
                    return;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}
