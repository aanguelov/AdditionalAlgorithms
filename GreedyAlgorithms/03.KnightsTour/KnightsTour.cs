namespace _03.KnightsTour
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    internal class KnightsTour
    {
        private static void Main()
        {
            int boardSize = int.Parse(Console.ReadLine());

            int[,] board = new int[boardSize, boardSize];

            int initialRow = 0;
            int initialCol = 0;
            board[initialRow, initialCol] = 1;

            int movesCount = int.Parse(Math.Pow(boardSize, 2).ToString(CultureInfo.InvariantCulture));

            for (int i = 1; i < movesCount; i++)
            {
                List<int[]> possibleMoves = GetPossibleMoves(initialRow, initialCol, board);
                int[] currentMove = new int[2];
                int minMovesCount = int.MaxValue;

                foreach (var possibleMove in possibleMoves)
                {
                    int count = GetPossibleMoves(possibleMove[0], possibleMove[1], board).Count;
                    if (count < minMovesCount)
                    {
                        minMovesCount = count;
                        currentMove = possibleMove;
                    }
                }

                board[currentMove[0], currentMove[1]] = i + 1;
                initialRow = currentMove[0];
                initialCol = currentMove[1];
            }

            PrintBoard(board);
        }

        private static List<int[]> GetPossibleMoves(int row, int col, int[,] board)
        {
            int[][] moves =
                {
                    new[] { row + 1, col - 2 }, new[] { row + 2, col - 1 }, 
                    new[] { row + 2, col + 1 }, new[] { row + 1, col + 2 }, 
                    new[] { row - 1, col + 2 }, new[] { row - 2, col + 1 }, 
                    new[] { row - 2, col - 1 }, new[] { row - 1, col - 2 } 
                };

            return moves.Where(move => IsValidMove(move, board)).ToList();
        }

        private static bool IsValidMove(int[] move, int[,] matrix)
        {
            int row = move[0];
            int col = move[1];

            bool isValid = false;

            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                if (matrix[row, col] == 0)
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        private static void PrintBoard(int[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }
    }
}