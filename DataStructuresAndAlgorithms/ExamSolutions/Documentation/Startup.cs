using System;

namespace Documentation
{
    public class Startup
    {
        private const int LatinLettersCount = 26;
        private const int MinCharValue = 97;
        private const int MaxCharValue = 122;

        public static void Main()
        {
            string characters = Console.ReadLine().ToLower();

            int minOperations = 0;
            int leftIndex = 0;
            int rightIndex = characters.Length - 1;

            while (leftIndex < rightIndex)
            {
                int leftChar = characters[leftIndex];
                int rightChar = characters[rightIndex];

                while ((leftChar < MinCharValue || leftChar > MaxCharValue) && leftIndex < rightIndex)
                {
                    leftIndex++;
                    leftChar = characters[leftIndex];
                }

                while ((rightChar < MinCharValue || rightChar > MaxCharValue) && leftIndex < rightIndex)
                {
                    rightIndex--;
                    rightChar = characters[rightIndex];
                }

                if (leftIndex >= rightIndex)
                {
                    break;
                }

                int difference = Math.Abs(leftChar - rightChar);
                minOperations += Math.Min(difference, LatinLettersCount - difference);

                leftIndex++;
                rightIndex--;
            }

            Console.WriteLine(minOperations);
        }
    }
}
