namespace Strings
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Questions
    {
        /// <summary>
        /// Reverse the words in a sentence—i.e., “My name is Chris” becomes “Chris is name My.” Optimize for time and space.
        /// </summary>
        [TestMethod]
        public void ReverseSentence()
        {
            const string Sentence = "     ";

            string result = StringAlgorithms.ReverseSentence(Sentence);

            Assert.AreEqual("     ", result);
        }
         
    }
}