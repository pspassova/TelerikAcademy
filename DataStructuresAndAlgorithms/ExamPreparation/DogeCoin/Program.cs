using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DogeCoin
{
    public class Program
    {
        public static void Main()
        {
            int[] rowsAndCols = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int coinsCount = int.Parse(Console.ReadLine());
            int[,] field = new int[rows, cols];

            for (int i = 0; i < coinsCount; i++)
            {
                int[] coords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                field[coords[0], coords[1]] += 1; // there can be more than one coin in a cell
            }

            BigInteger resultCoins = FindMaxCoinsCount(rows, cols, field);
            Console.WriteLine(resultCoins);
        }

        private static BigInteger FindMaxCoinsCount(int rows, int cols, int[,] field)
        {
            for (int row = 1; row < rows; row++)
            {
                field[row, 0] += field[row - 1, 0];
            }

            for (int col = 1; col < cols; col++)
            {
                field[0, col] += field[0, col - 1];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    if (field[row, col - 1] > field[row - 1, col])
                    {
                        field[row, col] += field[row, col - 1];
                    }
                    else
                    {
                        field[row, col] += field[row - 1, col];
                    }
                }
            }

            return field[rows - 1, cols - 1];
        }
    }
}
