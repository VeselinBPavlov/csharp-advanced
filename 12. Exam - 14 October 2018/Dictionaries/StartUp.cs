namespace Tagram
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var command = Console.ReadLine();
            var tagram = new Dictionary<string, Dictionary<string, int>>();
            var tagsCount = new Dictionary<string, int>();
            var totalLikes = new Dictionary<string, int>();

            while (command != "end")
            {
                var data = command.Split(" -> ");

                // Remove username.
                if (data.Length == 1)
                {
                    var dataRemove = data[0].Split(' ');

                    var usernameRemove = dataRemove[1];

                    if (tagram.ContainsKey(usernameRemove))
                    {
                        tagram.Remove(usernameRemove);
                        tagsCount.Remove(usernameRemove);
                    }

                    command = Console.ReadLine();
                    continue;
                }

                // Add username, tags and likes.
                var username = data[0];
                var tag = data[1];
                var likes = int.Parse(data[2]);

                if (tagram.ContainsKey(username) == false)
                {
                    tagram[username] = new Dictionary<string, int>();
                    tagsCount[username] = 0;
                    totalLikes[username] = 0;
                }

                if (tagram[username].ContainsKey(tag) == false)
                {
                    tagram[username][tag] = 0;
                    tagsCount[username]++;
                }
                tagram[username][tag] += likes;
                totalLikes[username] += likes;

                command = Console.ReadLine();
            }

            // Print tagram.
            foreach (var user in tagram.OrderByDescending(x => totalLikes[x.Key]).ThenBy(x => tagsCount[x.Key]))
            {
                Console.WriteLine(user.Key);
                foreach (var tags in user.Value)
                {
                    Console.WriteLine($"- {tags.Key}: {tags.Value}");
                }
            }
        }
    }
}
