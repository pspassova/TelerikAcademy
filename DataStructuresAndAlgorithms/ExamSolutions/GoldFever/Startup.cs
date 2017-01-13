using System;
using System.Linq;

namespace GoldFever
{
    public class Startup
    {
        public static void Main()
        {
            int days = int.Parse(Console.ReadLine());
            int[] prices = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            long profit = CalculateMaxProfit(prices);
            Console.WriteLine(profit);
        }

        private static long CalculateMaxProfit(int[] prices)
        {
            long maxProfit = 0;
            int currentProfit = 0;

            for (int day = prices.Length - 1; day >= 0; day--)
            {
                if (prices[day] > currentProfit)
                {
                    currentProfit = prices[day];
                }

                maxProfit += currentProfit - prices[day];
            }

            return maxProfit;
        }
    }
}
