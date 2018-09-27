namespace SymbolInMatrix
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());
            var matrix = new char[matrixSize, matrixSize];

            // Fill matrix.
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var arr = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            // Search symbol.
            var symbol = char.Parse(Console.ReadLine()); 

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(0); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
