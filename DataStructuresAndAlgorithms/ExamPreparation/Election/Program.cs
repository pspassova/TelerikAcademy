using System;
using System.Linq;
using System.Numerics;

namespace Election
{
    public class Program
    {
        public static void Main()
        {
            int seats = int.Parse(Console.ReadLine());
            int partiesCount = int.Parse(Console.ReadLine());

            int[] partiesSeats = new int[partiesCount];
            for (int i = 0; i < partiesCount; i++)
            {
                partiesSeats[i] = int.Parse(Console.ReadLine());
            }

            BigInteger possibleCombinations = FindCombinations(partiesSeats, seats);

            Console.WriteLine(possibleCombinations);
        }

        private static BigInteger FindCombinations(int[] partiesSeats, int seats)
        {
            BigInteger[] combinations = new BigInteger[partiesSeats.Sum() + 1];

            combinations[0] = 1; // base

            foreach (int partySeats in partiesSeats)
            {
                for (int i = combinations.Length - 1; i >= 0; i--)
                {
                    if (combinations[i] > 0)
                    {
                        combinations[i + partySeats] += combinations[i];
                    }
                }
            }

            BigInteger possibleCombinations = new BigInteger(0);
            for (int i = seats; i < combinations.Length; i++)
            {
                possibleCombinations += combinations[i];
            }

            return possibleCombinations;
        }
    }
}
