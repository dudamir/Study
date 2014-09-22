namespace UnionFind
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WeightedQuickUnionTests
    {
        [TestMethod]
        public void UnionTests()
        {
            var union = new WeightedQuickUnion(10);

            union.Union(5, 8);

            Assert.IsTrue(union.Connected(5, 8));
            Assert.IsFalse(union.Connected(5, 9));
        }
    }

    public class WeightedQuickUnion
    {
        private readonly int[] _list;
        private readonly int[] _height;

        public WeightedQuickUnion(int size)
        {
            _list = new int[size];
            _height = new int[size];

            for (int i = 0; i < _list.GetLength(0); i++)
            {
                _list[i] = i;
                _height[i] = 1;
            }
        }

        public void Union(int a, int b)
        {
            int aroot = Root(a);
            int broot = Root(b);

            if (_height[aroot] < _height[broot])
            {
                _list[aroot] = broot;
                _height[broot] += _height[aroot];
            }
            else
            {
                _list[broot] = aroot;
                _height[aroot] += _height[broot];
            }
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