namespace ReadFile
{
    using System;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            var path = "";
            var fileName = "StartUp.cs";

            path = Path.Combine(path, fileName);

            using (StreamReader reader = new StreamReader(path))
            {
                var line = reader.ReadLine();
                var counter = 0;

                while (line != null)
                {
                    Console.WriteLine($"Line {++counter}: {line}");
                    line = reader.ReadLine();
                }
            }
        }
    }
}
