using System;

namespace Towns
{
    public class Program
    {
        public static void Main()
        {
            int townsCount = int.Parse(Console.ReadLine());

            int[] townsCitizens = new int[townsCount];
            for (int i = 0; i < townsCount; i++)
            {
                var details = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                townsCitizens[i] = int.Parse(details[0]);
            }

            int longestPath = FindLongestPath(townsCitizens);
            Console.WriteLine(longestPath);
        }

        private static int FindLongestPath(int[] townsCitizens)
        {
            // Step 1: find the longest paths in ascending order
            int[] firstToLast = new int[townsCitizens.Length];
            for (int i = 0; i < townsCitizens.Length; i++)
            {
                int maxLength = 0;
                for (int j = 0; j < i; j++)
                {
                    if (townsCitizens[j] < townsCitizens[i])
                    {
                        maxLength = Math.Max(maxLength, firstToLast[j]);
                    }
                }

                firstToLast[i] = maxLength + 1;
            }

            // Step 2: find the longest paths in descending order
            int[] lastToFirst = new int[townsCitizens.Length];
            for (int j = townsCitizens.Length - 1; j >= 0; j--)
            {
                int maxLength = 0;
                for (int i = townsCitizens.Length - 1; i >= j; i--)
                {
                    if (townsCitizens[i] < townsCitizens[j])
                    {
                        maxLength = Math.Max(maxLength, lastToFirst[i]);
                    }
                }

                lastToFirst[j] = maxLength + 1;
            }

            // Step 3: find best path from the previous two's combination
            int longestPath = 0;
            for (int i = 0; i < townsCitizens.Length; i++)
            {
                int combination = firstToLast[i] + lastToFirst[i];
                longestPath = Math.Max(combination, longestPath);
            }

            return longestPath - 1; // because the same town has been calculated twice
        }
    }
}
