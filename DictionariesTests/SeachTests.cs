namespace DictionariesTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;

    [TestClass]
    public class SeachTests
    {
        [TestMethod]
        public void SearchExisting()
        {
            var list = new Dictionary();
            list.Insert(1, "joão");
            list.Insert(2, "maria");
            list.Insert(3, "claudia");

            Assert.AreEqual("maria", list.Search(2));
        }

        [TestMethod]
        public void SearchNotExisting()
        {
            var list = new Dictionary();
            list.Insert(1, "joão");
            list.Insert(2, "maria");
            list.Insert(3, "claudia");

            Assert.IsNull(list.Search(4));
        }

        [TestMethod]
        public void SearchEmptyList()
        {
            var list = new Dictionary();

            Assert.IsNull(list.Search(4));
        }
    }
}