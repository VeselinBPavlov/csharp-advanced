namespace KnightGame
{
    using System;

    class StartUp
    {
        public static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            var chess = new char[size][];

            chess = FillMatrix(chess, size);

            var targetRow = 0;
            var targetCol = 0;
            var removeKnights = 0;

            while (true)
            {
                var bestKiller = 0;

                for (int row = 0; row < chess.Length; row++)
                {
                    for (int col = 0; col < chess[row].Length; col++)
                    {
                        var tempKills = 0;

                        if (chess[row][col] != 'K')
                        {
                            continue;
                        }

                        // Up Left.
                        if (IsInside(chess, row - 2, col - 1) && chess[row - 2][col - 1] == 'K')
                        {
                            tempKills++;
                        }

                        // Up Right.
                        if (IsInside(chess, row - 2, col + 1) && chess[row - 2][col + 1] == 'K')
                        {
                            tempKills++;
                        }

                        // Down Left.
                        if (IsInside(chess, row + 2, col - 1) && chess[row + 2][col - 1] == 'K')
                        {
                            tempKills++;
                        }

                        // Down Right.
                        if (IsInside(chess, row + 2, col + 1) && chess[row + 2][col + 1] == 'K')
                        {
                            tempKills++;
                        }

                        // Left Up.
                        if (IsInside(chess, row - 1, col - 2) && chess[row - 1][col - 2] == 'K')
                        {
                            tempKills++;
                        }

                        // Left Down.
                        if (IsInside(chess, row + 1, col - 2) && chess[row + 1][col - 2] == 'K')
                        {
                            tempKills++;
                        }

                        // Right Up.
                        if (IsInside(chess, row - 1, col + 2) && chess[row - 1][col + 2] == 'K')
                        {
                            tempKills++;
                        }

                        //Right Down.
                        if (IsInside(chess, row + 1, col + 2) && chess[row + 1][col + 2] == 'K')
                        {
                            tempKills++;

                        }

                        if (tempKills > bestKiller)
                        {
                            bestKiller = tempKills;
                            targetRow = row;
                            targetCol = col;
                        }
                    }
                }

                if (bestKiller > 0)
                {
                    chess[targetRow][targetCol] = '0';
                    removeKnights++;
                }
                else
                {
                    Console.WriteLine(removeKnights);
                    break;
                }
            }
        }

        private static bool IsInside(char[][] chess, int row, int col)
        {
            if (row >= 0 && row < chess.Length && col >= 0 && col < chess[row].Length)
            {
                return true;
            }
            return false;
        }

        private static char[][] FillMatrix(char[][] chess, int size)
        {
            for (int i = 0; i < chess.Length; i++)
            {
                var line = Console.ReadLine().ToCharArray();
                chess[i] = line;
            }
            return chess;
        }
    }
}
