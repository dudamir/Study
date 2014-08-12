namespace HashTable
{
    using System.Collections;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BasicHashTables
    {
        [TestMethod]
        public void BasictlCreation()
        {
            var hashtable = new Hashtable();

            hashtable.Add(1, "Joao");

            Assert.AreEqual("Joao", hashtable[1]);
        }
    }
}
