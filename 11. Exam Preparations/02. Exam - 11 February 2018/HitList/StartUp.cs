namespace HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var targetIndex = int.Parse(Console.ReadLine());
            var information = new Dictionary<string, SortedDictionary<string, string>>();
            var infoIndex = new Dictionary<string, int>();

            var command = Console.ReadLine();

            while (command != "end transmissions")
            {
                var data = command
                    .Split(new char[] { '=', ';', ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = data[0];

                // Initialize name.
                if (information.ContainsKey(name) == false)
                {
                    information[name] = new SortedDictionary<string, string>();
                    infoIndex[name] = 0;
                }

                // Get properties of current name and count their length.
                for (int i = 1; i < data.Length; i+=2)
                {
                    var key = data[i];
                    var value = data[i + 1];

                    if (information[name].ContainsKey(key) == false)
                    {
                        information[name][key] = "";
                        infoIndex[name] += key.Length;
                    }
                    infoIndex[name] -= information[name][key].Length;
                    information[name][key] = value;
                    infoIndex[name] += value.Length;                   
                }

                command = Console.ReadLine();
            }

            var secondCommand = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var searchedName = secondCommand[1];

            // Print information about current person.
            Console.WriteLine($"Info on {searchedName}:");
            foreach (var props in information[searchedName])
            {
                Console.WriteLine($"---{props.Key}: {props.Value}");
            }
            Console.WriteLine($"Info index: {infoIndex[searchedName]}");

            var index = infoIndex[searchedName];

            if (targetIndex > index)
            {
                Console.WriteLine($"Need {targetIndex - index} more info.");
            }
            else
            {
                Console.WriteLine("Proceed");
            }
        }
    }
}
