using System;
using System.Linq;
using System.Numerics;

namespace RingsOfTheAcademy
{
    // Test:
    // 6
    // 0
    // 1
    // 2
    // 3
    // 4
    // 4
    public class Startup
    {
        public static void Main()
        {
            int ringsCount = int.Parse(Console.ReadLine());

            int[] rings = new int[ringsCount + 1];
            for (int i = 0; i < ringsCount; i++)
            {
                int parentRing = int.Parse(Console.ReadLine());
                rings[parentRing]++;
            }

            BigInteger[] factorials = CalculateFactorials(rings);

            BigInteger ringConfigurations = 1;
            for (int i = 1; i < rings.Length; i++)
            {
                ringConfigurations *= factorials[rings[i]];
            }

            Console.WriteLine(ringConfigurations);
        }

        private static BigInteger[] CalculateFactorials(int[] numbers)
        {
            BigInteger[] factorials = new BigInteger[numbers.Max() + 1];
            factorials[0] = 1;

            for (int i = 1; i < factorials.Length; i++)
            {
                factorials[i] = factorials[i - 1] * i;
            }

            return factorials;
        }
    }
}
