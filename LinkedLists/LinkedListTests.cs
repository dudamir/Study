namespace LinkedLists
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InsertTests
    {
        [TestMethod]
        public void AddFirstNode()
        {
            var list = new LinkedList();

            list.Insert(10);
            
            Assert.AreEqual(1, list.Size);
            Assert.AreEqual(10, list.Head.Value);
        }

        [TestMethod]
        public void InsertMany()
        {
            var list = new LinkedList();

            list.Insert(10);
            list.Insert(10);
            list.Insert(10);
            list.Insert(10);

            Assert.AreEqual(4, list.Size);
        }
    }
}