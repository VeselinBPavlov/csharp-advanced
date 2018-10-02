namespace Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            // Save contests.
            var firstCommand = Console.ReadLine();
            var contests = new Dictionary<string, string>();

            while (firstCommand != "end of contests")
            {
                var input = firstCommand.Split(':', StringSplitOptions.RemoveEmptyEntries);

                var course = input[0];
                var pass = input[1];

                contests.Add(course, pass);

                firstCommand = Console.ReadLine();
            }

            // Save candidates.
            var secondCommand = Console.ReadLine();
            var candidates = new Dictionary<string, Dictionary<string, int>>();
            var totals = new Dictionary<string, int>();

            while (secondCommand != "end of submissions")
            {
                var data = secondCommand.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                var course = data[0];
                var pass = data[1];
                var student = data[2];
                var points = int.Parse(data[3]);

                // Check if course existing.
                if (contests.ContainsKey(course) == false)
                {
                    secondCommand = Console.ReadLine();
                    continue;
                }

                // Check if current pass is the same as course pass.
                if (contests[course] != pass)
                {
                    secondCommand = Console.ReadLine();
                    continue;
                }

                // Initialize new candidate.
                if (candidates.ContainsKey(student) == false)
                {
                    candidates[student] = new Dictionary<string, int>();
                    totals[student] = 0;
                }

                // Initialize new course.
                if (candidates[student].ContainsKey(course) == false)
                {
                    candidates[student][course] = 0;
                }
                
                // Take best score of candidate of current course and recalculate total points.
                if (candidates[student][course] < points)
                {
                    totals[student] -= candidates[student][course];
                    totals[student] += points;
                    candidates[student][course] = points;
                }

                secondCommand = Console.ReadLine();
            }

            // Order candidates by total points.
            totals = totals.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine($"Best candidate is {totals.Keys.First()} with total {totals.Values.First()} points.");
            Console.WriteLine("Ranking:");
            // Print candidates ordered alphabetically.
            foreach (var student in candidates.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);
                // Print courses ordered by total points.
                foreach (var course in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {course.Key} -> {course.Value}");
                }
            }
        }
    }
}
