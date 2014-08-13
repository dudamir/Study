namespace LinkedLists
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Run
    {
        [TestMethod]
        public void Get()
        {
            var first = GetList(50);

            ListNode node = first.Nth(10);

            Assert.AreEqual(10, node.Value);
        }

        [TestMethod]
        public void InsertAfter()
        {
            var first = GetList(50);

            ListNode node = first.Nth(10);

            var next = node.Next;

            node.InsertAfter(40);

            Assert.AreEqual(node.Next.Value, 40);
            Assert.AreEqual(node.Next.Next, next);

        }
        
        private static ListNode GetList(int total)
        {
            var first = new ListNode { Value = 1 };
            ListNode current = first;
            
            for (int position = 2; position <= total; position++)
            {
                current.InsertAfter(position);
                current = current.Next;
            }

            return first;
        }
    }
}
