namespace LinkedLists
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DeleteTests
    {
        [TestMethod]
        public void DeleteNotExisting()
        {
            var list = Helper.GetList(10);

            list.Delete(20);

            Assert.AreEqual(10, list.Size);
        }

        [TestMethod]
        public void DeleteExisting()
        {
            var list = Helper.GetList(10);

            list.Delete(7);

            Assert.AreEqual(9, list.Size);
        }

        [TestMethod]
        public void DeleteTail()
        {
            var list = Helper.GetList(10);

            list.Delete(1);

            Assert.AreEqual(9, list.Size);

        }

        [TestMethod]
        public void DeleteHead()
        {
            var list = Helper.GetList(10);

            list.Delete(10);

            Assert.AreEqual(9, list.Size);

        }
    }
}