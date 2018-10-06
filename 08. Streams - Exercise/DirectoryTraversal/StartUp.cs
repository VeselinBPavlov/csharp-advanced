namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var path = Console.ReadLine();
            var files = Directory.GetFiles(path);
            var fileExtensions = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;

                if (!fileExtensions.ContainsKey(extension))
                {
                    fileExtensions[extension] = new List<FileInfo>();
                }
                fileExtensions[extension].Add(fileInfo);
            }

            fileExtensions = fileExtensions
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);
            
            var fullFimeName = "report.txt";

            using (var writer = new StreamWriter(fullFimeName))
            {
                foreach (var kvp in fileExtensions)
                {
                    var extension = kvp.Key;
                    var infoList = kvp.Value;

                    writer.WriteLine(extension);
                    foreach (var item in infoList.OrderBy(x => x.Length))
                    {
                        var fileSize = (double)item.Length / 1024;
                        writer.WriteLine($"--{item.Name} - {fileSize:F3}");
                    }
                }
            }
        }
    }
}
