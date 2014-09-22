namespace UnionFind
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnionFindTests
    {
        [TestMethod]
        public void UnionTests()
        {
            var union = new UnionList(10);

            union.Union(5, 8);

            Assert.IsTrue(union.IsConnected(5, 8));
            Assert.IsFalse(union.IsConnected(5, 9));
        }
    }

    public class UnionList
    {
        private readonly int[] _list;

        public UnionList(int size)
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

        public bool IsConnected(int a, int b)
        {
            return _list[a] == _list[b];
        }
    }
}