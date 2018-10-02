namespace SquaresInMatrix
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var rowsCount = matrixSize[0];
            var colsCount = matrixSize[1];
            var matrix = new char[rowsCount, colsCount];

            // Fill matrix.
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var arr = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            // Count 2x2 squares of equal chars.
            var counter = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var character = matrix[row, col];

                    if (character == matrix[row, col + 1]
                        && character == matrix[row + 1, col]
                        && character == matrix[row + 1, col + 1])
                    {
                        counter++;
                    }                    
                }
            }

            Console.WriteLine(counter);
        }
    }
}
