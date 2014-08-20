namespace DictionariesTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;

    [TestClass]
    public class InsertTests
    {
        [TestMethod]
        public void InsertFirst()
        {
            var dic = new Dictionary();

            dic.Insert(1, "Joao");

            Assert.AreEqual("Joao", dic.Search(1));
            Assert.AreEqual(1, dic.Length());
        }

        [TestMethod]
        public void InsertMany()
        {
            var dic = new Dictionary();

            dic.Insert(1, "Joao");
            dic.Insert(2, "Maria");
            dic.Insert(3, "José");

            Assert.AreEqual("Joao", dic.Search(1));
            Assert.AreEqual("Maria", dic.Search(2));
            Assert.AreEqual("José", dic.Search(3));
            Assert.AreEqual(3, dic.Length());
        }

        [TestMethod]
        public void InsertDuplicateKey()
        {
            var dic = new Dictionary();
            string exMessage = string.Empty;

            dic.Insert(1, "Joao");

            try
            {
                dic.Insert(1, "Maria");
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
            }

            Assert.AreEqual("Cannot insert a duplicated index in the dictionary", exMessage);
            Assert.AreEqual(1, dic.Length());
        }
    }
}