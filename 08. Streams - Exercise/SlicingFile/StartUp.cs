namespace SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            var path = "../_Resources/";
            var fileName = "sliceMe.mp4";
            var parts = 4;

            path = Path.Combine(path, fileName);
            var destination = "";

            Slice(path, destination, parts);

            var list = new List<string>
            {
                "Part-0.mp4",
                "Part-1.mp4",
                "Part-2.mp4",
                "Part-3.mp4",
                "Part-4.mp4",
            };

            Assemble(list, destination);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                var extension = sourceFile.Substring(sourceFile.LastIndexOf(".") + 1);

                var partsSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i <= parts; i++)
                {
                    var currentPieceSize = 0L;

                    if (destinationDirectory == "")
                    {
                        destinationDirectory = "./";
                    }

                    var currentPart = destinationDirectory + $"Part-{i}.{extension}";
                    using (var writer = new FileStream(currentPart, FileMode.Create))
                    {
                        var size = 4096;
                        var buffer = new byte[size];
                        while (reader.Read(buffer, 0, size) == size)
                        {
                            writer.Write(buffer, 0, size);
                            currentPieceSize += size;

                            if (currentPieceSize >= partsSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            var extension = files[0].Substring(files[0].LastIndexOf(".") + 1);
            if (destinationDirectory == "")
            {
                destinationDirectory = "./";
            }
            string wholeFile = $"{destinationDirectory}Assembled.{extension}";

            using (var writer = new FileStream(wholeFile, FileMode.Create))
            {
                foreach (var file in files)
                {
                    using (var reader = new FileStream(file, FileMode.Open))
                    {
                        var size = 4096;
                        var bytes = new byte[size];

                        while (reader.Read(bytes, 0, size) == size)
                        {
                            writer.Write(bytes, 0, size);
                        }
                    }
                }
            }
        }
    }
}
