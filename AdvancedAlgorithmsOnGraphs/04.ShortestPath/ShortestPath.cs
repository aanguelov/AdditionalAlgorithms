namespace _04.ShortestPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ShortestPath
    {
        private static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            int edgesCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            int[,] distances = new int[nodesCount, nodesCount];
            for (int i = 0; i < edgesCount; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int startNode = input[0];
                int endNode = input[1];
                int weight = input[2];
                distances[startNode, endNode] = weight;
                distances[endNode, startNode] = weight;
            }

            FloydWarshall(distances);
            PrintMatrix(distances);
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + "   ");
                }

                Console.WriteLine();
            }
        }

        private static void FloydWarshall(int[,] matrix)
        {
            int numberOfIterations = matrix.GetLength(0);
            for (int i = 0; i < numberOfIterations; i++)
            {
                HashSet<int> blockedRows = new HashSet<int> { i };
                HashSet<int> blockedCols = new HashSet<int> { i };
                for (int j = 0; j < numberOfIterations; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        blockedCols.Add(j);
                    }

                    if (matrix[j, i] == 0)
                    {
                        blockedRows.Add(j);
                    }
                }

                for (int row = 0; row < numberOfIterations; row++)
                {
                    if (blockedRows.Contains(row))
                    {
                        continue;
                    }

                    for (int col = 0; col < numberOfIterations; col++)
                    {
                        if (blockedCols.Contains(col) || row == col)
                        {
                            continue;
                        }

                        if (matrix[row, col] > matrix[i, col] + matrix[row, i] || matrix[row, col] == 0)
                        {
                            matrix[row, col] = matrix[i, col] + matrix[row, i];
                        }
                    }
                }
            }
        }
    }
}