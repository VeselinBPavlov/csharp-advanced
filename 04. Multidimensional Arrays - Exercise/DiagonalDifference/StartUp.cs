namespace DiagonalDifference
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new int[matrixSize, matrixSize];

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

            // Calculate sum of first diagonal.
            var firstNum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                firstNum += matrix[row, row];
            }

            // Calculate sum of second diagonal.
            var reverseIndex = matrixSize - 1;
            var secondNum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                secondNum += matrix[row, reverseIndex];
                reverseIndex--;
            }

            var difference = Math.Abs(firstNum - secondNum);
            Console.WriteLine(difference);
        }
    }
}
