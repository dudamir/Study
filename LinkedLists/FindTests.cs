namespace LinkedLists
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindTests
    {
        [TestMethod]
        public void FindNotExisting()
        {
            var list = Helper.GetList(10);

            var node = list.Find(12);

            Assert.IsNull(node);
        }

        [TestMethod]
        public void FindFirst()
        {
            var list = Helper.GetList(10);

            var node = list.Find(1);

            Assert.AreEqual(1, node.Value);

        }

        [TestMethod]
        public void FindMiddle()
        {
            var list = Helper.GetList(10);

            var node = list.Find(5);

            Assert.AreEqual(5, node.Value);

        }

        [TestMethod]
        public void FindLast()
        {
            var list = Helper.GetList(10);

            var node = list.Find(10);

            Assert.AreEqual(10, node.Value);
        }
    }
}