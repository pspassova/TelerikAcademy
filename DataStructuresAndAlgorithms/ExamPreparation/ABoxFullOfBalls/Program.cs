using System;
using System.Linq;

namespace ABoxFullOfBalls
{
    public class Program
    {
        public static void Main()
        {
            int[] possibleTurns = Console.ReadLine()
                                     .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();
            int[] aAndB = Console.ReadLine()
                                     .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();
            int a = aAndB[0];
            int b = aAndB[1];

            int mikisWins = CalculateWins(possibleTurns, a, b);
            Console.WriteLine(mikisWins);
        }

        private static int CalculateWins(int[] possibleTurns, int a, int b)
        {
            int numberOfGames = b + 101;
            bool[] wins = new bool[numberOfGames];

            int winsCount = 0;
            for (int i = 0; i <= b; i++)
            {
                if (!wins[i])
                {
                    for (int j = 0; j < possibleTurns.Length; j++)
                    {
                        wins[i + possibleTurns[j]] = true;
                    }
                }

                if (i >= a && wins[i])
                {
                    winsCount++;
                }
            }

            return winsCount;
        }
    }
}
