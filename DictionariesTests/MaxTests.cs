namespace DictionariesTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;

    [TestClass]
    public class MaxTests
    {
        [TestMethod]
        public void MaxZero()
        {
            var dic = new Dictionary();

            Assert.AreEqual(0, dic.Max());
        }

        [TestMethod]
        public void MaxUnique()
        {
            var dic = new Dictionary();
            
            dic.Insert(1, "joão");
            
            Assert.AreEqual(1, dic.Max());
        }

        [TestMethod]
        public void MaxUnorderInsert()
        {
            var dic = new Dictionary();

            dic.Insert(3, "joão");
            dic.Insert(1, "joão");
            dic.Insert(2, "joão");

            Assert.AreEqual(3, dic.Max());
        }

        [TestMethod]
        public void MaxRemoving()
        {
            var dic = new Dictionary();

            dic.Insert(3, "joão");
            dic.Insert(1, "joão");
            dic.Insert(2, "joão");
            dic.Delete(3);
            
            Assert.AreEqual(2, dic.Max());
        }
    }
}