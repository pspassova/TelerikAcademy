using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Doge
{
    public class Program
    {
        //  Input
        //  4 5
        //  3 4
        //  3
        //  1 1
        //  2 2
        //  2 3

        public static void Main()
        {
            int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[] foodCoordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int enemiesCount = int.Parse(Console.ReadLine());

            List<int[]> enemiesCoordinates = new List<int[]>();
            for (int i = 0; i < enemiesCount; i++)
            {
                int[] coords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                enemiesCoordinates.Add(coords);
            }

            BigInteger pathsCount = FindPathsToFood(rows, cols, foodCoordinates, enemiesCoordinates);
            Console.WriteLine(pathsCount);
        }

        private static BigInteger FindPathsToFood(int rows, int cols, int[] foodCoordinates, List<int[]> enemiesCoordinates)
        {
            BigInteger[,] paths = new BigInteger[rows, cols];
            paths[0, 0] = 1;

            foreach (var coords in enemiesCoordinates)
            {
                paths[coords[0], coords[1]] = -1;
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (paths[row, col] == -1)
                    {
                        continue;
                    }

                    if (row > 0 && paths[row - 1, col] != -1)
                    {
                        paths[row, col] += paths[row - 1, col];
                    }

                    if (col > 0 && paths[row, col - 1] != -1)
                    {
                        paths[row, col] += paths[row, col - 1];
                    }
                }
            }

            return paths[foodCoordinates[0], foodCoordinates[1]];
        }
    }
}
