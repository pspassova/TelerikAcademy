using Sorters.GenericSorters;

using NUnit.Framework;

using System.Collections.Generic;

namespace Sorters.Tests.GenericSorters
{
    [TestFixture]
    public class QuickSorterTests
    {
        [Test]
        public void SortMethodShould_SortElementsProperly_IfTheyAreOfTypeFloat()
        {
            // Arrange 
            IList<float> floatElements = new List<float> { 10.2f, -14f, 8.46f, 12f, 1f, -18f, 6f };
            IList<float> sortedFloatElements = new List<float> { -18f, -14f, 1f, 6f, 8.46f, 10.2f, 12 };

            QuickSorter<float> sorter = new QuickSorter<float>();

            // Act
            IList<float> actualSortedElements = sorter.Sort(floatElements);

            // Assert
            Assert.AreEqual(sortedFloatElements, actualSortedElements);
        }

        [Test]
        public void SortMethodShould_SortElementsProperly_IfTheyAreOfTypeDecimal()
        {
            // Arrange 
            IList<decimal> decimalElements = new List<decimal> { 10.2m, 8.46m, 12m, -14m, 1m, -18m, 6m };
            IList<decimal> sortedDecimalElements = new List<decimal> { -18m, -14m, 1m, 6m, 8.46m, 10.2m, 12m };

            QuickSorter<decimal> sorter = new QuickSorter<decimal>();

            // Act
            IList<decimal> actualSortedElements = sorter.Sort(decimalElements);

            // Assert
            Assert.AreEqual(sortedDecimalElements, actualSortedElements);
        }

        [Test]
        public void SortMethodShould_SortElementsProperly_IfTheyAreOfTypeDouble()
        {
            // Arrange 
            IList<double> doubleElements = new List<double> { 10.2d, 8.46d, 12d, -14d, 1d, -18d, 6d };
            IList<double> sortedDoubleElements = new List<double> { -18d, -14d, 1d, 6d, 8.46d, 10.2d, 12d };

            QuickSorter<double> sorter = new QuickSorter<double>();

            // Act
            IList<double> actualSortedElements = sorter.Sort(doubleElements);

            // Assert
            Assert.AreEqual(sortedDoubleElements, actualSortedElements);
        }

        [Test]
        public void SortMethodShould_SortElementsProperly_IfTheyAreOfTypeInteger()
        {
            // Arrange 
            IList<int> integerElements = new List<int> { 10, 2, 8, 4, -6, 12, -20, 14, -18 };
            IList<int> sortedIntegerElements = new List<int> { -20, -18, -6, 2, 4, 8, 10, 12, 14 };

            QuickSorter<int> sorter = new QuickSorter<int>();

            // Act
            IList<int> actualSortedElements = sorter.Sort(integerElements);

            // Assert
            Assert.AreEqual(sortedIntegerElements, actualSortedElements);
        }

        [Test]
        public void SortMethodShould_SortElementsProperly_IfTheyAreOfTypeChar()
        {
            // Arrange 
            IList<char> charElements = new List<char> { 'b', 'a', 'c', 'f', 'e' };
            IList<char> sortedCharElements = new List<char> { 'a', 'b', 'c', 'e', 'f' };

            QuickSorter<char> sorter = new QuickSorter<char>();

            // Act
            IList<char> actualSortedElements = sorter.Sort(charElements);

            // Assert
            Assert.AreEqual(sortedCharElements, actualSortedElements);
        }

        [Test]
        public void SortMethodShould_SortElementsProperly_IfTheyAreOfTypeString()
        {
            // Arrange 
            IList<string> stringElements = new List<string> { "gg", "ga", "p", "v", "c" };
            IList<string> sortedStringElements = new List<string> { "c", "ga", "gg", "p", "v" };

            QuickSorter<string> sorter = new QuickSorter<string>();

            // Act
            IList<string> actualSortedElements = sorter.Sort(stringElements);

            // Assert
            Assert.AreEqual(sortedStringElements, actualSortedElements);
        }
    }
}
