using Sorters.GenericSorters;

using System;
using System.Collections.Generic;

namespace Sorters
{
    public class Startup
    {
        private static IList<int> quickSortedElements = new List<int>();
        private static IList<int> selectionSortedElements = new List<int>();
        private static IList<int> mergeSortedElements = new List<int>();

        public static void Main()
        {
            IList<int> testElements = new List<int>() { 22, 12, 2, 32 };

            QuickSorter<int> quickSorter = new QuickSorter<int>();
            SelectionSorter<int> selectionSorter = new SelectionSorter<int>();
            MergeSorter<int> mergeSorter = new MergeSorter<int>();

            quickSortedElements = quickSorter.Sort(testElements);
            selectionSortedElements = selectionSorter.Sort(testElements);
            mergeSortedElements = mergeSorter.Sort((List<int>)testElements);

            Console.WriteLine($"Elements after QuickSort: {string.Join(" ", quickSortedElements)}");
            Console.WriteLine($"Elements after SelectionSort: {string.Join(" ", selectionSortedElements)}");
            Console.WriteLine($"Elements after MergeSort: {string.Join(" ", mergeSortedElements)}");
        }
    }
}
