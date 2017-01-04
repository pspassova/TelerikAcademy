using System;
using System.Collections.Generic;

namespace Sorters.GenericSorters
{
    public class SelectionSorter<T>
        where T : IComparable<T>
    {
        public IList<T> Sort(IList<T> elements)
        {
            for (int i = 0; i < elements.Count - 1; i++)
            {
                int currentMin = i;
                for (int j = i + 1; j < elements.Count; j++)
                {
                    if (elements[currentMin].CompareTo(elements[j]) > 0)
                    {
                        currentMin = j;
                    }
                }

                T temp = elements[i];
                elements[i] = elements[currentMin];
                elements[currentMin] = temp;
            }

            return elements;
        }
    }
}
