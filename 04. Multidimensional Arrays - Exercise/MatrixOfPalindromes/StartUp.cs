namespace MatrixOfPalindromes
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
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var rowsCount = matrixSize[0];
            var colsCount = matrixSize[1];
            var matrix = new string[rowsCount, colsCount];

            // Fill matrix with palindromes.
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var element = $"{alphabet[row]}{alphabet[row + col]}{alphabet[row]}";
                    matrix[row, col] = element;
                }
            }

            // Print matrix.
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
