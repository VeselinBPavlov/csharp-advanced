namespace Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var hospital = new Dictionary<string, Dictionary<int, List<string>>>();
            var doctors = new Dictionary<string, List<string>>();
            var departaments = new Dictionary<string, List<string>>();

            var command = Console.ReadLine();
            while (command != "Output")
            {
                var data = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var departament = data[0];
                var doctor = $"{data[1]} {data[2]}";
                var patient = data[3];

                if (hospital.ContainsKey(departament) == false)
                {
                    hospital[departament] = new Dictionary<int, List<string>>();
                    departaments[departament] = new List<string>();

                    for (int i = 1; i <= 20; i++)
                    {
                        hospital[departament][i] = new List<string>();
                    }
                }

                for (int i = 1; i < 20; i++)
                {
                    if (hospital[departament][i].Count < 3)
                    {
                        hospital[departament][i].Add(patient);
                        departaments[departament].Add(patient);
                        break;
                    }
                }

                if (doctors.ContainsKey(doctor) == false)
                {
                    doctors[doctor] = new List<string>();
                }

                doctors[doctor].Add(patient);


                command = Console.ReadLine();
            }

            var output = Console.ReadLine();

            while (output != "End")
            {
                var data = output.Split();
                var info = data[0];

                if (data.Length == 2)
                {
                    int room;
                    var isRoom = int.TryParse(data[1], out room);

                    if (isRoom)
                    {
                        var departament = info;

                        foreach (var patient in hospital[departament][room].OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                    else
                    {
                        var doctor = $"{data[0]} {data[1]}";

                        foreach (var patient in doctors[doctor].OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }                    
                }
                else if (departaments.ContainsKey(info))
                {
                    var departament = info;

                    foreach (var patient in departaments[departament])
                    {
                        Console.WriteLine(patient);
                    }
                }

                output = Console.ReadLine();
            }
        }
    }
}
