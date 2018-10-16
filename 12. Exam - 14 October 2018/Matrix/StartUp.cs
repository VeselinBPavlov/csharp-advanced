namespace Miner
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            var commands = Console.ReadLine()
                .Split(' ')
                .ToArray();

            var matrix = new string[size][];
            var minerRow = 0;
            var minerCol = 0;
            var coalsCount = 0;
            var isGameOver = false;

            // Fill matrix, find coordinates of miner and count coals.
            for (int i = 0; i < matrix.Length; i++)
            {
                var line = Console.ReadLine().Split(' ').ToArray();

                if (line.Contains("s"))
                {
                    minerRow = i;
                    minerCol = Array.IndexOf(line, "s");
                }

                if (line.Contains("c"))
                {
                    foreach (var character in line)
                    {
                        if (character == "c")
                        {
                            coalsCount++;
                        }
                    }
                }

                matrix[i] = line;
            }

            // Move miner.
            foreach (var command in commands)
            {
                switch (command)
                {
                    case "up":
                        {                            
                            if (IsValidMove(matrix, minerRow - 1, minerCol) == false)
                            {
                                break;
                            }                            

                            if (matrix[minerRow - 1][minerCol] == "c")
                            {
                                coalsCount--;
                            }

                            if (matrix[minerRow - 1][minerCol] == "e")
                            {
                                isGameOver = true;
                            }

                            matrix[minerRow][minerCol] = "*";
                            minerRow--;
                            matrix[minerRow][minerCol] = "s";
                            
                        }
                        break;
                    case "down":
                        {
                            if (IsValidMove(matrix, minerRow + 1, minerCol) == false)
                            {
                                break;
                            }

                            if (matrix[minerRow + 1][minerCol] == "c")
                            {
                                coalsCount--;
                            }

                            if (matrix[minerRow + 1][minerCol] == "e")
                            {
                                isGameOver = true;
                            }

                            matrix[minerRow][minerCol] = "*";
                            minerRow++;
                            matrix[minerRow][minerCol] = "s";
                        }
                        break;
                    case "left":
                        {
                            if (IsValidMove(matrix, minerRow, minerCol - 1) == false)
                            {
                                break;
                            }

                            if (matrix[minerRow][minerCol - 1] == "c")
                            {
                                coalsCount--;
                            }

                            if (matrix[minerRow][minerCol - 1] == "e")
                            {
                                isGameOver = true;
                            }

                            matrix[minerRow][minerCol] = "*";
                            minerCol--;
                            matrix[minerRow][minerCol] = "s";
                        }
                        break;
                    case "right":
                        {
                            if (IsValidMove(matrix, minerRow, minerCol + 1) == false)
                            {
                                break;
                            }

                            if (matrix[minerRow][minerCol + 1] == "c")
                            {
                                coalsCount--;
                            }

                            if (matrix[minerRow][minerCol + 1] == "e")
                            {
                                isGameOver = true;
                            }

                            matrix[minerRow][minerCol] = "*";
                            minerCol++;
                            matrix[minerRow][minerCol] = "s";
                        }
                        break;
                    default: break;
                }

                if (isGameOver)
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    return;
                }

                if (coalsCount == 0)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    return;
                }
            }

            Console.WriteLine($"{coalsCount} coals left. ({minerRow}, {minerCol})");
        }

        private static bool IsValidMove(string[][] matrix, int row, int col)
        {
            if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length)
            {
                return true;
            }
            return false;
        }
    }
}
