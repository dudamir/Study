namespace LinkedLists
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DListTests
    {
        [TestMethod]
        public void InsertFirstNode()
        {
            var list = new DList();

            list.Insert(5);
            Assert.AreEqual(1, list.Size);
            Assert.AreEqual(5, list.Head.Value);
        }

        [TestMethod]
        public void InsertAnotherNode()
        {
            var list = new DList();

            list.Insert(5);
            list.Insert(6);

            Assert.AreEqual(2, list.Size);
            Assert.AreEqual(6, list.Tail.Value);
        }

        [TestMethod]
        public void RemoveHead()
        {
            var list = new DList();

            list.Insert(5);
            list.Insert(6);

            list.Remove(5);

            Assert.AreEqual(1, list.Size);
            Assert.AreEqual(6, list.Head.Value);
        }
        
        [TestMethod]
        public void RemoveHeadAndTail()
        {
            var list = new DList();

            list.Insert(5);

            list.Remove(5);

            Assert.AreEqual(0, list.Size);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        public void RemoveDuplicate()
        {
            var list = new DList();

            list.Insert(6);
            list.Insert(5);
            list.Insert(6);

            list.Remove(6);

            Assert.AreEqual(1, list.Size);
            Assert.AreEqual(5, list.Tail.Value);
            Assert.AreEqual(5, list.Head.Value);
        }

        [TestMethod]
        public void RemoveTail()
        {
            var list = new DList();

            list.Insert(5);
            list.Insert(6);

            list.Remove(6);

            Assert.AreEqual(1, list.Size);
            Assert.AreEqual(5, list.Tail.Value);
        }

        [TestMethod]
        public void RemoveNode()
        {
            var list = new DList();

            list.Insert(5);
            list.Insert(6);
            list.Insert(20);
            list.Insert(1);
            list.Insert(2);
            list.Insert(21);
            list.Insert(50);
            list.Insert(600);
            list.Insert(3423);

            list.Remove(600);
            
            Assert.AreEqual(8, list.Size);
            Assert.IsFalse(list.Has(600));
        }
    }
}