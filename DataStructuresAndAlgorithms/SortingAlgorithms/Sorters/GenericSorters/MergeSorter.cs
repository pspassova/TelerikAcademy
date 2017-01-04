using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorters.GenericSorters
{
    public class MergeSorter<T>
        where T : IComparable<T>
    {
        public IList<T> Sort(List<T> elements)
        {
            var sortedElements = this.SortHelper(elements);

            elements.Clear();
            elements.AddRange(sortedElements);

            return elements;
        }

        private List<T> SortHelper(IList<T> elements)
        {
            int elementsCount = elements.Count / 2;
            if (elementsCount < 2)
            {
                return elements.ToList();
            }

            List<T> leftPart = new List<T>();
            List<T> rightPart = new List<T>();

            leftPart.AddRange(elements.Take(elementsCount));
            rightPart.AddRange(elements.Skip(elementsCount));

            leftPart = this.SortHelper(leftPart);
            rightPart = this.SortHelper(rightPart);

            return this.Merge(leftPart, rightPart);
        }

        private List<T> Merge(IList<T> leftPart, IList<T> rightPart)
        {
            var elements = new List<T>(leftPart.Count + rightPart.Count);

            int leftIndex = 0;
            int rightIndex = 0;
            for (int i = 0; i < elements.Capacity; i++)
            {
                if (leftIndex >= leftPart.Count)
                {
                    elements.Add(rightPart[rightIndex]);
                    rightIndex++;
                }
                else if (rightIndex >= rightPart.Count)
                {
                    elements.Add(leftPart[leftIndex]);
                    leftIndex++;
                }
                else if (leftPart[leftIndex].CompareTo(rightPart[rightIndex]) > 0)
                {
                    elements.Add(rightPart[rightIndex]);
                    rightIndex++;
                }
                else
                {
                    elements.Add(leftPart[leftIndex]);
                    leftIndex++;
                }
            }

            return elements;
        }
    }
}
