namespace UnionFind
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class QuickUnionTests
    {
        [TestMethod]
        public void UnionTests()
        {
            var union = new QuickUnion(10);

            union.Union(5, 8);

            Assert.IsTrue(union.Connected(5, 8));
            Assert.IsFalse(union.Connected(5, 9));
        }
    }

    public class QuickUnion
    {
        private readonly int[] _list;

        public QuickUnion(int size)
        {
             _list = new int[size];

            for (int i = 0; i < _list.GetLength(0); i++)
            {
                _list[i] = i;
            }
        }

        public void Union(int a, int b)
        {
            int aroot = Root(a);

            _list[b] = aroot;
        }

        public bool Connected(int a, int b)
        {
            int aroot = Root(a);
            int broot = Root(b);

            return aroot == broot;
        }

        private int Root(int i)
        {
            int current = i;
            
            while (_list[current] != current)
            {
                current = _list[current];
            }

            return current;
        }
    }
}