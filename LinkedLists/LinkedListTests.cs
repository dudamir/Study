namespace LinkedLists
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;

    [TestClass]
    public class InsertTests
    {
        [TestMethod]
        public void AddFirstNode()
        {
            var list = new LinkedList<int>();

            list.Insert(10);
            
            Assert.AreEqual(1, list.Length());
            Assert.IsNotNull(list.Find(10));
        }

        [TestMethod]
        public void InsertMany()
        {
            var list = new LinkedList<int>();

            list.Insert(10);
            list.Insert(10);
            list.Insert(10);
            list.Insert(10);

            Assert.AreEqual(4, list.Length());
        }
    }
}