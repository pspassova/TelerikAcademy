using System;
using System.Collections.Generic;

namespace KnapsackProblem
{
    public class Program
    {
        private static int productsCount;
        private static int capacity;

        //  Example: M=10kg, N=6, products:
        //  beer – weight=3, cost=2
        //  vodka – weight=8, cost=12
        //  cheese – weight=4, cost=5
        //  nuts – weight=1, cost=4
        //  ham – weight=2, cost=3
        //  whiskey – weight=8, cost=13
        public static void Main()
        {
            // Values are hardcoded for easier testing
            capacity = 10;
            productsCount = 6;
            int[] values = new int[] { 3, 2, 8, 12, 4, 5, 1, 4, 2, 3, 8, 13 };

            List<int[]> productsDetails = new List<int[]>();
            for (int i = 0; i < values.Length; i += 2)
            {
                productsDetails.Add(new int[] { values[i], values[i + 1] });
            }

            int highestCost = CalculateHighestCost(productsDetails, capacity);
            Console.WriteLine(highestCost);
        }

        private static int CalculateHighestCost(List<int[]> productsDetails, int capacity)
        {
            int[,] costs = new int[productsCount, capacity + 1];

            for (int row = 0; row < productsCount; row++)
            {
                for (int col = 1; col <= capacity; col++)
                {
                    int productWeight = productsDetails[row][0];
                    int productCost = productsDetails[row][1];

                    if (col >= productWeight)
                    {
                        if (row == 0)
                        {
                            costs[row, col] = productCost;
                        }
                        else
                        {
                            costs[row, col] = Math.Max(productCost + costs[row - 1, col - productWeight], costs[row - 1, col]);
                        }
                    }
                }
            }

            return costs[productsCount - 1, capacity];
        }
    }
}
