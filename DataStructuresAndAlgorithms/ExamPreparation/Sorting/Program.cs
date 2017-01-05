using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorting
{
    public class Program
    {
        public static void Main()
        {
            Console.ReadLine();
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int k = int.Parse(Console.ReadLine());

            int operationsResult = FindFewestNumberOfOperations(numbers, k);
            Console.WriteLine(operationsResult);
        }

        private static int FindFewestNumberOfOperations(int[] numbers, int k)
        {
            Dictionary<int, int> visited = new Dictionary<int, int>(); // <HashCode, minPathToKey>
            Queue<int[]> permutations = new Queue<int[]>();

            permutations.Enqueue(numbers);
            visited.Add(GetHashCode(numbers), 0);

            while (permutations.Count > 0)
            {
                int[] currentPermutation = permutations.Dequeue();
                int currentPath = visited[GetHashCode(currentPermutation)];
                if (IsArraySorted(currentPermutation))
                {
                    return currentPath;
                }

                for (int i = 0; i <= numbers.Length - k; i++)
                {
                    int[] successor = (int[])currentPermutation.Clone();
                    Array.Reverse(successor, i, k);

                    if (!visited.ContainsKey(GetHashCode(successor)))
                    {
                        visited.Add(GetHashCode(successor), currentPath + 1);
                        permutations.Enqueue(successor);
                    }
                }
            }

            return -1;
        }

        private static bool IsArraySorted(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i - 1] > numbers[i])
                {
                    return false;
                }
            }

            return true;
        }


        private static int GetHashCode(int[] numbers)
        {
            int hash = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                hash *= 10; // could be 8 in this particular problem
                hash += numbers[i];
            }

            return hash; // from 3 4 2 7 5 8 we'll get 342758 as an integer
        }
    }
}
