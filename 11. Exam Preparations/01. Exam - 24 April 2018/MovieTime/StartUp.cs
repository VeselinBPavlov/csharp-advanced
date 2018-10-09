namespace MovieTime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var wishedGenre = Console.ReadLine();
            var wishedLength = Console.ReadLine();
            var playlist = new Dictionary<string, List<string>>();
            var totalDuration = new List<string>();

            var input = Console.ReadLine();

            while (input != "POPCORN!")
            {
                var movieData = input.Split('|', StringSplitOptions.RemoveEmptyEntries).ToArray();
                var title = movieData[0];
                var genre = movieData[1];
                var duration = movieData[2];

                // Skip movies with wrong genre.
                if (wishedGenre != genre)
                {
                    totalDuration.Add(duration);
                    input = Console.ReadLine();
                    continue;                       
                }

                if (playlist.ContainsKey(title) == false)
                {
                    playlist[title] = new List<string>(); // May have error.
                    totalDuration.Add(duration);
                }
                var timeArr = duration.Split(":").ToArray();
                playlist[title].Add(timeArr[0]);
                playlist[title].Add(timeArr[1]);
                playlist[title].Add(timeArr[2]);

                input = Console.ReadLine();
            }

            // Sort movies by duration.
            if (wishedLength == "Short")
            {
                playlist = playlist
                    .OrderBy(x => int.Parse(x.Value[0]))
                    .ThenBy(x => int.Parse(x.Value[1]))
                    .ThenBy(x => int.Parse(x.Value[2]))
                    .ToDictionary(x => x.Key, y => y.Value);
            }
            else
            {
                playlist = playlist
                    .OrderByDescending(x => int.Parse(x.Value[0]))
                    .ThenByDescending(x => int.Parse(x.Value[1]))
                    .ThenByDescending(x => int.Parse(x.Value[2]))
                    .ToDictionary(x => x.Key, y => y.Value);
            }

            // Calculate total duration of movies.
            var totDuration = GetTotalDuration(totalDuration);

            // Get the right movie.
            foreach (var movie in playlist)
            {
                var wish = Console.ReadLine();

                if (wish != "Yes")
                {
                    Console.WriteLine(movie.Key);
                }
                else
                {
                    Console.WriteLine(movie.Key);
                    Console.WriteLine($"We're watching {movie.Key} - {String.Join(":", movie.Value)}");
                    break;
                }
            }

            Console.WriteLine($"Total Playlist Duration: {totDuration}");
        }

        private static string GetTotalDuration(List<string> totalDuration)
        {
            var seconds = 0;
            var minutes = 0;
            var hours = 0;
            var totalTime = "";

            foreach (var time in totalDuration)
            {
                var data = time.Split(':').ToArray();

                seconds += int.Parse(data[2]);
                if (seconds > 59)
                {
                    minutes++;
                    seconds -= 60;
                }

                minutes += int.Parse(data[1]);
                if (minutes > 59)
                {
                    hours++;
                    minutes -= 60;
                }

                hours += int.Parse(data[0]);
            }

            totalTime = $"{hours:d2}:{minutes:d2}:{seconds:d2}";
            return totalTime;
        }
    }
}
