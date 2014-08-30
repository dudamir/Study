namespace SortingTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures.Sorting;

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Simple()
        {
            var unsorted = new[] { 0, 1, 20, 12, 30, 1, 33, 54, 6, 54503403 };

            var sorter = new SelSort();

            // sorter.Sort(unsorted);

            AssertIsSorted(unsorted);
        }

        private void AssertIsSorted(int[] sorted)
        {
            bool result = true;

            for (int i = 0; i < sorted.GetLength(0); i++)
            {
                if (sorted[i] <= sorted[i + 1])
                {
                    result = false;
                    Assert.Fail("{0} is bigger than {1}", sorted[i + 1], sorted[i]);
                }
            }

            Assert.IsTrue(result);
        }
    }
}