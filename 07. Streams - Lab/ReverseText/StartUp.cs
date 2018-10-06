namespace ReverseText
{
    using System;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var basePath = "";
            var inputFileName = "StartUp.cs";
            var outputFileName = "reverse.txt";

            basePath = Path.Combine(basePath, inputFileName);

            using (StreamReader reader = new StreamReader(basePath))
            {
                using (StreamWriter writer = new StreamWriter(outputFileName))
                {
                    var line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine (String.Join("", line.Reverse()));
                        line = reader.ReadLine();
                    }
                }                
            }
        }
    }
}
