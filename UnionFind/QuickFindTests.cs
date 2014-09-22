namespace UnionFind
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class QuickFindTests
    {
        [TestMethod]
        public void UnionTests()
        {
            var union = new QuickFind(10);

            union.Union(5, 8);

            Assert.IsTrue(union.Connected(5, 8));
            Assert.IsFalse(union.Connected(5, 9));
        }
    }

    public class QuickFind
    {
        private readonly int[] _list;

        public QuickFind(int size)
        {
            _list = new int[size];

            for (int i = 0; i < _list.GetLength(0); i++)
            {
                _list[i] = i;
            }
        }

        public void Union(int a, int b)
        {
            int oldId = _list[a]; 
            int newId = _list[b];

            for (int i = 0; i < _list.GetLength(0); i++)
            {
                if (_list[i] == oldId)
                    _list[i] = newId;
            }
        }

        public bool Connected(int a, int b)
        {
            return _list[a] == _list[b];
        }
    }
}