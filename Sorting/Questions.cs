namespace SortingTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;
    using Structures.Sorting;

    [TestClass]
    public class Questions
    {
        /// <summary>
        /// Given 2n players, with a grade, from 0 up to 2n, split them in two teams that are most uneven as possible (all the n best players in one team)
        /// </summary>
        [TestMethod]
        public void Uneven()
        {
            var players = new[] { 1, 10, 20, 3, 4, 7, 6, 5, 11, 13, 12, 14, 17, 16, 2, 19, 8, 9, 15, 18 };

            Sorter<int> sorter = new QuickSorter();
            sorter.Sort(players);

            // Assert
            int bestOfWeakest = 0;

            var half = players.GetLength(0)/2 - 1;
            for (int i = 0; i < half; i++)
            {
                if (players[i] > bestOfWeakest)
                    bestOfWeakest = players[i];
            }

            for (int i = half + 1; i < players.GetLength(0) - 1; i++)
            {
                Assert.IsTrue(players[i] >= bestOfWeakest);
            }
        }

        [TestMethod]
        public void MergeSortedArraysNoExtraMemory()
        {
            var smaller = new[] { 0, 2, 3, 4, 7, 8, 10 };
            var bigger = new[] { 0, 1, 2, 5, 6, 20, 30, 31, -1, -1, -1, -1, -1, -1, -1 };

            int n = smaller.GetLength(0);
            int m = bigger.GetLength(0) - n;
            int k = m + n - 1;

            int i = n - 1;
            int j = m - 1;
            while (i >= 0 && j >= 0)
            {
                if (smaller[i] > bigger[j])
                {
                    bigger[k] = smaller[i];
                    i--;
                }
                else
                {
                    bigger[k] = bigger[j];
                    j--;
                }

                k--;
            }

            while (i >= 0)
            {
                bigger[k] = smaller[i];
                i--;
                k--;
            }

            Printer.Print(bigger);
        }
    }


}