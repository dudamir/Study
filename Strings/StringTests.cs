namespace Strings
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void MalFormed()
        {
            const string s = ")";

            Assert.IsFalse(StringAlgorithms.WellFormed(s));
        }

        [TestMethod]
        public void MalFormed2()
        {
            const string s = "(";

            Assert.IsFalse(StringAlgorithms.WellFormed(s));
        }

        [TestMethod]
        public void WellFormed()
        {
            const string s = "()";

            Assert.IsTrue(StringAlgorithms.WellFormed(s));
        }

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

        [TestMethod]
        public void Reverse()
        {
            const string str = "1209381298983928093246    abcasbdjhasdoiquweiudiouedi";
            char[] charArray = str.ToCharArray();

            Array.Reverse(charArray);

            var expected = new string(charArray);

            Assert.AreEqual(expected, StringAlgorithms.Reverse(str));
        }

        [TestMethod]
        public void RemoveDuplicate()
        {
            const string str = "mmmm";

            Assert.AreEqual("m", StringAlgorithms.RemoveDuplicate(str));
        }
    }
}