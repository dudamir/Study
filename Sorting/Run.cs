using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorting
{
    [TestClass]
    public class Run
    {
        [TestMethod]
        public void SelectionSort()
        {
            var numbers = new[] { 1, 2, 6, -3, 1000, 3, 56, 76, 43 };
            var expected = new[] { -3, 1, 2, 3, 6, 43, 56, 76, 1000 };

            Sorter.SelectionSort(numbers);

            CollectionAssert.AreEqual(expected, numbers);
        }

        [TestMethod]
        public void InsertionSort()
        {
            var numbers = new[] { 1, 2, 6, -3, 1000, 3, 56, 76, 43 };
            var expected = new[] { -3, 1, 2, 3, 6, 43, 56, 76, 1000 };

            Sorter.InsertionSort(numbers);

            CollectionAssert.AreEqual(expected, numbers);
        }
    }

    public static class Sorter
    {
        public static void SelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var min = i;

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[j] < numbers[min]) 
                        min = j;

                    Swap(numbers, j, min);
                }
            }
        }

        private static void Swap(int[] numbers, int @from, int to)
        {
            var aux = numbers[to];
            numbers[to] = numbers[@from];
            numbers[@from] = aux;
        }

        public static void InsertionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var j = i;

                while (j > 0 && numbers[j] < numbers[j - 1])
                {
                    Swap(numbers, j, j - 1);
                    j--;
                }
            }
        }
    }
}