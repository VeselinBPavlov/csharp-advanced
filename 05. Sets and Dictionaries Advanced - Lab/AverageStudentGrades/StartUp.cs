namespace AverageStudentGrades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var studentsCount = int.Parse(Console.ReadLine());

            var students = new Dictionary<string, List<double>>();

            // Create dictionary with students and list of grades.
            for (int i = 0; i < studentsCount; i++)
            {
                var studentData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = studentData[0];
                var grade = double.Parse(studentData[1]);

                if (students.ContainsKey(name) == false)
                {
                    students[name] = new List<double>();
                }

                students[name].Add(grade);
            }

            // Print students with grades and average grade.
            foreach (var student in students)
            {
                Console.Write(student.Key + " -> ");

                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:F2} ");
                }

                Console.WriteLine($"(avg: {student.Value.Average():F2})");
            }

        }
    }
}
