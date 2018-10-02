namespace TheVLogger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var command = Console.ReadLine();
            var vLogger = new Dictionary<string, HashSet<string>>();
            var following = new Dictionary<string, int>();

            // Manage vLogger.
            while (command.ToLower() != "statistics")
            {
                var data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var name = data[0];
                var action = data[1];

                switch (action)
                {
                    case "joined":
                        {
                            // Check if vlogger already register.
                            if (vLogger.ContainsKey(name) == false)
                            {
                                vLogger[name] = new HashSet<string>();
                                following[name] = 0;
                            }
                        }
                        break;
                    case "followed":
                        {
                            var vloggerToFollow = data[2];
                            // Check if follower and following are existing.
                            var isVloggersJoined = vLogger.ContainsKey(name) && vLogger.ContainsKey(vloggerToFollow);
                            // Check if vlogger try to follow himself.
                            var isNotDublicate = name != vloggerToFollow;                         

                            if (isVloggersJoined && isNotDublicate)
                            {
                                // Check if vlogger try to follow other second time.
                                if (!vLogger[vloggerToFollow].Contains(name))
                                {
                                    vLogger[vloggerToFollow].Add(name);
                                    following[name]++;
                                }
                                
                            }
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            // Print vLogger statistic.
            Console.WriteLine($"The V-Logger has a total of {vLogger.Count} vloggers in its logs.");
            var counter = 1;
            // Order vloggers by number of followed descending and number of followed ascending.
            foreach (var vlogger in vLogger.OrderByDescending(x => x.Value.Count).ThenBy(x => following[x.Key]))
            {
                Console.WriteLine($"{counter}. {vlogger.Key} : {vlogger.Value.Count} followers, {following[vlogger.Key]} following");
                if (counter == 1)
                {   
                    // Order followed vloggers by name alphabetical.
                    foreach (var name in vlogger.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {name}");
                    }
                }
                counter++;
            }
        }
    }
}
