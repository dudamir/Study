namespace Searching
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
        public class Binary
        {
            [TestMethod]
            public void Simple()
            {
                int[] root = { 0, 1, 2, 3, 4, 6, 9, 12, 23, 43, 55, 66, 67, 87, 100 };

                int result = Search(root, 6);

                Assert.AreEqual(5, result);

            }

            [TestMethod]
            public void DoNotFind()
            {
                int[] root = { 0, 1, 10 };

                int result = Search(root, 6);

                Assert.AreEqual(-1, result);

            }

            [TestMethod]
            public void Larger()
            {
                int[] root = { 0, 1, 10 };

                int result = Search(root, 12);

                Assert.AreEqual(-1, result);

            }

            [TestMethod]
            public void Lower()
            {
                int[] root = { 0, 1, 10 };

                int result = Search(root, -1);

                Assert.AreEqual(-1, result);

            }

            [TestMethod]
            public void FindOne()
            {
                int[] root = { 1 };

                int result = Search(root, 1);

                Assert.AreEqual(0, result);

            }

            [TestMethod]
            public void NotFindOne()
            {
                int[] root = { 0 };

                int result = Search(root, 1);

                Assert.AreEqual(-1, result);

            }

            private int Search(int[] root, int value)
            {
                return Search(root, value, 0, root.Length - 1);
            }

            private int Search(int[] root, int value, int begin, int end)
            {
                if (end < begin)
                {
                    return -1;
                }

                int m = (begin + end)/2;

                if (root[m] == value)
                {
                    return m;
                }
                
                if (root[m] > value)
                {
                    end = m - 1;
                }
                else
                {
                    begin = m + 1;
                }

                return Search(root, value, begin, end);
            }
        } 
}