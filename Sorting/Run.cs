namespace SortingTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;
    using Structures.Sorting;

    [TestClass]
    public class Run
    {
        private static Sorter<int> GetSorter()
        {
            return new InsertionSorter<int>((i, j) => i < j);
        }

        [TestMethod]
        public void SortBasic()
        {
            var numbers = new[] { 10000, 2, 6, -3, 1000, 3, 56, 76, 43 };

            var sorter = GetSorter();
            sorter.Sort(numbers);

            AssertSort(numbers);
        }

        [TestMethod]
        public void SortOnlyOne()
        {
            var numbers = new[] { -3 };

            var sorter = GetSorter();
            sorter.Sort(numbers);

            AssertSort(numbers);
        }

        [TestMethod]
        public void SortEmpty()
        {
            var numbers = new int[0];

            var sorter = GetSorter();
            sorter.Sort(numbers);

            AssertSort(numbers);
        }

        [TestMethod]
        public void SortSorted()
        {
            var numbers = new[] { 1, 2, 6};

            var sorter = GetSorter();
            sorter.Sort(numbers);

            AssertSort(numbers);
        }

        private static void AssertSort(int[] sorted)   
        {
            Printer.Print(sorted);

            for (int i = 0; i < sorted.GetLength(0) - 1; i++)
            {
                if (sorted[i] > sorted[i + 1]) Assert.Fail("not sorted {0} is bigger than {1}", sorted[i], sorted[i + 1]);
            }
        }
    }
}