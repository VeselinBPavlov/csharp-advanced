namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var path = "../_Resources/";
            var wordsFile = "words.txt";
            var textFile = "text.txt";
            var resultFile = "result.txt";

            var wordsPath = Path.Combine(path, wordsFile);
            var textPath = Path.Combine(path, textFile);
            var result = new Dictionary<string, int>();

            using (StreamReader wordsReader = new StreamReader(wordsPath))
            {
                using (StreamReader textReader = new StreamReader(textPath))
                {

                    var searchedWords = wordsReader.ReadToEnd()
                        .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToArray();

                    var lines = textReader.ReadToEnd()
                        .Split(new[] { '-', ' ', '?', '!', '.', ',', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.ToLower())
                        .Select(x => x.Trim())
                        .ToArray();

                    using (StreamWriter resultWriter = new StreamWriter(resultFile))
                    {
                        foreach (var searchedWord in searchedWords)
                        {
                            foreach (var word in lines)
                            {
                                if (searchedWord == word)
                                {
                                    if (result.ContainsKey(searchedWord) == false)
                                    {
                                        result[searchedWord] = 0;
                                    }

                                    result[searchedWord]++;
                                }
                            }
                        }

                        foreach (var word in result.OrderByDescending(x => x.Value))
                        {
                            resultWriter.WriteLine($"{word.Key} - {word.Value}");
                        }
                    }
                }
            }
        }
    }
}
