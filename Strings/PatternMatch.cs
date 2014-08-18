namespace Strings
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PatternMatch
    {
        [TestMethod]
        public void MatchBegin()
        {
            const string str = "psaiodusaiu saiud saiduais";
            const string pattern = "psa";

            Assert.AreEqual(0, StringAlgorithms.PatternMatch(str, pattern));
        }

        [TestMethod]
        public void MatchEnd()
        {
            const string str = "iodusaiu saiud saiduaispsa";
            const string pattern = "psa";

            Assert.AreEqual(23, StringAlgorithms.PatternMatch(str, pattern));
        }

        [TestMethod]
        public void Equals()
        {
            const string str = "a";
            const string pattern = "a";

            Assert.AreEqual(0, StringAlgorithms.PatternMatch(str, pattern));
        }

        [TestMethod]
        public void DoesNotMatch()
        {
            const string str = "psaiodusaiu saiud saiduais";
            const string pattern = "xy";

            Assert.AreEqual(-1, StringAlgorithms.PatternMatch(str, pattern));
        }

        [TestMethod]
        public void AlmostMatchAtEnd()
        {
            const string str = "psaiodusaiu saiud saiduais";
            const string pattern = "isx";

            Assert.AreEqual(-1, StringAlgorithms.PatternMatch(str, pattern));
        }

        [TestMethod]
        public void PatternIsBigger()
        {
            const string str = "psaiodusaiu saiud saiduais";
            const string pattern = "ppsaiodusaiu saiud saiduaisa";

            Assert.AreEqual(-1, StringAlgorithms.PatternMatch(str, pattern));
        }

    }
}