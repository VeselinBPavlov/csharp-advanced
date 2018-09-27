namespace SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var rowsLength = matrixSize[0];
            var colsLength = matrixSize[1];
            var matrix = new int[rowsLength, colsLength];
            var biggestSum = int.MinValue;
            var miniMatrix = new int[2, 2];
            var rowIndex = 0;
            var colIndex = 0;

            // Fill matrix.
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var arr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            // Find maximum sum starting indexes of 2x2 submatrix.
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var firstNum = matrix[row, col];
                    var secondNum = matrix[row, col + 1];
                    var thirdNum = matrix[row + 1, col];
                    var fourthNum = matrix[row + 1, col + 1];
                    var currentSum = firstNum + secondNum + thirdNum + fourthNum;

                    if (biggestSum < currentSum)
                    {
                        biggestSum = currentSum;
                        rowIndex = row;
                        colIndex = col;                        
                    }
                }
            }

            // Print 2x2 submatrix and biggest sum.
            for (int row = rowIndex; row < rowIndex + 2; row++)
            {
                for (int col = colIndex; col < colIndex + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(biggestSum);
        }
    }
}
