namespace SumMatrixColumns
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var rowLength = matrixSize[0];
            var colLength = matrixSize[1];

            var matrix = new int[rowLength, colLength];
            var result = new int[colLength];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    result[col] += arr[col];
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, result));
        }
    }
}
