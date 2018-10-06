namespace LineNumbers
{
    using System;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            var path = "../_Resources/";
            var inputFileName = "text.txt";
            var outputFileName = "lineNumbers.txt";

            path = Path.Combine(path, inputFileName);

            using (StreamReader reader = new StreamReader(path))
            {
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    var line = reader.ReadLine();
                    var counter = 0;
                    while (line != null)
                    {
                        writer.WriteLine($"Line {++counter}: {String.Join("", line)}");
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
