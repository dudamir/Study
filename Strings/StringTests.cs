namespace Strings
{
    using System;

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
        public void Anagram()
        {
            const string str = "amo";
            const string ana = "moa";

            Assert.IsTrue(StringAlgorithms.AreAnagram(str, ana));
        }

        [TestMethod]
        public void RemoveDuplicate()
        {
            const string str = "mmmm";

            Assert.AreEqual("m", StringAlgorithms.RemoveDuplicate(str));
        }
    }
}