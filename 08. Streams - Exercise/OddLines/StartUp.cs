namespace OddLines
{
    using System;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            var path = "../_Resources/";
            var fileName = "text.txt";

            path = Path.Combine(path, fileName);

            using (StreamReader reader = new StreamReader(path))
            {
                var counter = 0;
                var line = "";

                while ((line = reader.ReadLine()) != null)
                {
                    if (counter % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    counter++;
                }
            }
        }
    }
}
