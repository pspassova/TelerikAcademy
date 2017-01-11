using System;
using System.Linq;

namespace Guards
{
    public class Startup
    {
        private const int Infinity = int.MaxValue - 10;
        private const int NormalCellTime = 1;
        private const int RiskyCellTime = 3;
        private const string FailureMessage = "Meow";

        public static void Main()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);

            long[,] paths = new long[rows, cols];

            int guardsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < guardsCount; i++)
            {
                input = Console.ReadLine().Split(' ').ToArray();
                int guardRow = int.Parse(input[0]);
                int guardCol = int.Parse(input[1]);
                string guardDirection = input[2];

                paths[guardRow, guardCol] = Infinity;

                if (guardDirection == "U" && guardRow > 0 && paths[guardRow - 1, guardCol] == 0)
                {
                    paths[guardRow - 1, guardCol] = RiskyCellTime;
                }
                else if (guardDirection == "D" && guardRow + 1 < rows && paths[guardRow + 1, guardCol] == 0)
                {
                    paths[guardRow + 1, guardCol] = RiskyCellTime;
                }
                else if (guardDirection == "L" && guardCol > 0 && paths[guardRow, guardCol - 1] == 0)
                {
                    paths[guardRow, guardCol - 1] = RiskyCellTime;
                }
                else if (guardDirection == "R" && guardCol + 1 < cols && paths[guardRow, guardCol + 1] == 0)
                {
                    paths[guardRow, guardCol + 1] = RiskyCellTime;
                }
            }

            long maxProfit = FindMaximumProfit(paths, rows, cols);
            if (maxProfit >= Infinity)
            {
                Console.WriteLine(FailureMessage);
            }
            else
            {
                Console.WriteLine(maxProfit + 1);
            }
        }

        private static long FindMaximumProfit(long[,] paths, int rows, int cols)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row == 0 && col == 0)
                    {
                        continue;
                    }
                    if (paths[row, col] == 0)
                    {
                        paths[row, col] = NormalCellTime;
                    }
                    if (row == 0)
                    {
                        paths[row, col] += paths[row, col - 1];
                    }
                    else if (col == 0)
                    {
                        paths[row, col] += paths[row - 1, col];
                    }
                    else
                    {
                        paths[row, col] += Math.Min(paths[row - 1, col], paths[row, col - 1]);
                    }
                }
            }

            return paths[rows - 1, cols - 1];
        }
    }
}
