namespace Strings
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AnagramTests
    {
        [TestMethod]
        public void Simple()
        {
            const string First = "amo";
            const string Second = "moa";

            Assert.IsTrue(StringAlgorithms.IsAnagram(First, Second));
        }
        
        [TestMethod]
        public void Casing()
        {
            const string First = "amo";
            const string Second = "AMO";

            Assert.IsTrue(StringAlgorithms.IsAnagram(First, Second));
        }

        [TestMethod]
        public void Not()
        {
            const string First = "amoo";
            const string Second = "moa";

            Assert.IsFalse(StringAlgorithms.IsAnagram(First, Second));
        }

        [TestMethod]
        public void BigChars()
        {
            const string First = "qwertyuiop[]asdfghjkl;'zxcvbnm,./QWERTYUITOP[]ASDFGHJKL;'ZXCVBNM,./";
            const string Second = "qwertyuiop[]asdfghjkl;'zxcvbnm,./QWERTYUITOP[]ASDFGHJKL;'ZXCVBNM,./";

            Assert.IsTrue(StringAlgorithms.IsAnagram(First, Second));
        }
    }
}