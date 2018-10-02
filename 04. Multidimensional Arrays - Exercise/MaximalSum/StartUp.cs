namespace MaximalSum
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
            var matrix = new int[rowsCount, colsCount];

            // Fill matrix.
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var arr = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            // Find maximum sum and indexes of matrix.
            var maxSum = int.MinValue;
            var rowIndex = 0;
            var colIndex = 0;

            // Iteration over big matrix.
            for (int row = 0;  row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    var tempSum = 0;

                    // Iteration over submatrix. Find max sum and indexes.
                    for (int subRow = row; subRow < row + 3; subRow++)
                    {
                        for (int subCol = col; subCol < col + 3; subCol++)
                        {
                            tempSum += matrix[subRow, subCol];
                        }
                    }

                    if (tempSum > maxSum)
                    {
                        maxSum = tempSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            // Print 3x3 matrix with biggest sum.
            Console.WriteLine($"Sum = {maxSum}");

            for (int row = rowIndex; row <= rowIndex + 2; row++)
            {
                for (int col = colIndex; col <= colIndex + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }            
        }
    }
}
