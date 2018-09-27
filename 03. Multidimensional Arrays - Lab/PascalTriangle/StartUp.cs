namespace PascalTriangle
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());

            long[][] jaggedArr = new long[rowsCount][];
            jaggedArr[0] = new long[1] { 1 };

            // Declare all arrays.
            for (int i = 1; i < rowsCount; i++)
            {
                jaggedArr[i] = new long[i + 1];
                jaggedArr[i][0] = 1;
                jaggedArr[i][jaggedArr[i].Length - 1] = 1;
            }

            // Fill jagged array with algorithm.
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    if (col != 0 && col != jaggedArr[row].Length - 1)
                    {
                        long sum = jaggedArr[row - 1][col - 1] + jaggedArr[row - 1][col];
                        jaggedArr[row][col] = sum;
                    }
                }
            }

            // Print jagged array.
            foreach (var arr in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
