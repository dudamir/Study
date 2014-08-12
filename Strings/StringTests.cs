namespace Strings
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void Repetition()
        {
            const string str = "abc";

            Assert.IsFalse(StringAlgorithms.HasDupChar(str), "{0} has no duplicate chars", str);
        }

        [TestMethod]
        public void RepetitionNoAux()
        {
            const string str = "~!#$^&*()_+1234567890abcdefghijklmnopqrstuvxyz";

            Assert.IsFalse(StringAlgorithms.HasDupCharNoAux(str), "{0} has no duplicate chars", str);
        }
    }
}