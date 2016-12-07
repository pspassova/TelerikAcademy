using System;
using System.Collections.Generic;

namespace Sorters.GenericSorters
{
    public class QuickSorter<T>
        where T : IComparable<T>
    {
        public IList<T> Sort(IList<T> elements)
        {
            if (elements.Count <= 1)
            {
                return elements;
            }

            int pivotIndex = elements.Count / 2;
            T pivot = elements[pivotIndex];

            List<T> leftPart = new List<T>();
            List<T> rightPart = new List<T>();
            for (int i = 0; i < pivotIndex; i++)
            {
                if (elements[i].CompareTo(pivot) <= 0)
                {
                    leftPart.Add(elements[i]);
                }
                else
                {
                    rightPart.Add(elements[i]);
                }
            }

            for (int i = pivotIndex + 1; i < elements.Count; i++)
            {
                if (elements[i].CompareTo(pivot) < 0)
                {
                    leftPart.Add(elements[i]);
                }
                else
                {
                    rightPart.Add(elements[i]);
                }
            }
            List<T> result = new List<T>();

            result.AddRange(Sort(leftPart));
            result.Add(pivot);
            result.AddRange(Sort(rightPart));

            return result;
        }
    }
}
