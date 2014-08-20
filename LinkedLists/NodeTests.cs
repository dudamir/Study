namespace LinkedLists
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;

    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Get()
        {
            var first = GetList(50);

            ListNode<int> node = first.Nth(10);

            Assert.AreEqual(10, node.Value);
        }

        [TestMethod]
        public void InsertAfter()
        {
            var first = GetList(50);

            ListNode<int> node = first.Nth(10);

            var next = node.Next;

            node.InsertAfter(40);

            Assert.AreEqual(node.Next.Value, 40);
            Assert.AreEqual(node.Next.Next, next);

        }


        private static ListNode<int> GetList(int total)
        {
            var first = new ListNode<int> { Value = 1 };
            ListNode<int> current = first;
            
            for (int position = 2; position <= total; position++)
            {
                current.InsertAfter(position);
                current = current.Next;
            }

            return first;
        }
    }
}
