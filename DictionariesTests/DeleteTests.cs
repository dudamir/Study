namespace DictionariesTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;

    [TestClass]
    public class DeleteTests
    {
        [TestMethod]
        public void DeleteUnique()
        {
            var list = new Dictionary();
            list.Insert(1, "joão");

            list.Delete(1);

            Assert.IsNull(list.Search(1));
            Assert.AreEqual(0, list.Length());
        }

        [TestMethod]
        public void DeleteExisting()
        {
            var list = new Dictionary();
            list.Insert(1, "joão");
            list.Insert(2, "maria");
            list.Insert(3, "daniel");
            list.Insert(4, "joana");

            list.Delete(2);

            Assert.IsNull(list.Search(2));
            Assert.AreEqual(3, list.Length());
            
        }

        [TestMethod]
        public void DeleteLast()
        {
            var list = new Dictionary();
            list.Insert(1, "joão");
            list.Insert(2, "maria");
            list.Insert(3, "daniel");
            list.Insert(4, "joana");

            list.Delete(4);

            Assert.IsNull(list.Search(4));
            Assert.AreEqual(3, list.Length());
        }

        [TestMethod]
        public void DeleteNotExisting()
        {
            var list = new Dictionary();
            list.Insert(1, "joão");
            list.Insert(2, "maria");
            list.Insert(3, "daniel");
            list.Insert(4, "joana");

            list.Delete(6);

            Assert.AreEqual(4, list.Length());
        }
    }
}