namespace LinkedLists
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;

    [TestClass]
    public class Questions
    {
        [TestMethod]
        public void FindLoop()
        {
            var linkedList = new Structures.LinkedList<int>();

            linkedList.Insert(2);
            linkedList.Insert(3);
            linkedList.Insert(4);
            linkedList.Insert(5);
            linkedList.Insert(10);
            linkedList.Insert(12);
            linkedList.Insert(13);
            linkedList.Insert(14);
            linkedList.Insert(20);
            linkedList.Insert(30);

            ListNode<int> fail = linkedList.Find(13);

            fail.Next = fail;

            ListNode<int> loop = FindLoopNode(linkedList);

            Assert.AreEqual(fail.Value, loop.Value);
        }

        private static ListNode<int> FindLoopNode(Structures.LinkedList<int> linkedList)
        {
            var slow = linkedList.Head();
            var fast = linkedList.Head();

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;

                if (slow == fast)
                    return slow;
            }

            return null;

            // var dic = new Dictionary<ListNode<int>, int>();

            // return FindLoopNode(linkedList.Head(), dic);
        }

        private static ListNode<int> FindLoopNode(ListNode<int> node, Dictionary<ListNode<int>, int> exists)
        {
            if (node == null || exists.ContainsKey(node.Next))
            {
                return node;
            }

            exists.Add(node, node.Value);

            return FindLoopNode(node.Next, exists);
        }


        [TestMethod]
        public void Reverse()
        {
            var linkedList = new Structures.LinkedList<int>();

            linkedList.Insert(2);
            linkedList.Insert(3);
            linkedList.Insert(4);
            linkedList.Insert(5);

            linkedList.Reverse();
            linkedList.Iterate(c => Console.WriteLine(c.Value));
        }

        [TestMethod]
        public void ReverseNoRecursion()
        {
            var linkedList = new Structures.LinkedList<int>();

            linkedList.Insert(2);
            linkedList.Insert(3);
            linkedList.Insert(4);
            linkedList.Insert(5);

            Printer.Print(linkedList);

            linkedList.ReverseNoRecursion();

            Printer.Print(linkedList);
        }

        [TestMethod]
        public void RemoveDuplicates()
        {
            var linkedList = new Structures.LinkedList<int>();

            linkedList.Insert(5);
            linkedList.Insert(5);
            linkedList.Insert(5);
            linkedList.Insert(5);

            linkedList.RemoveDuplicatesNoAux();


            linkedList.Iterate(c => Console.WriteLine(c.Value));
        }

        [TestMethod]
        public void MiddleNode()
        {
            var linkedList = new Structures.LinkedList<int>();

            linkedList.Insert(1);
            linkedList.Insert(2);
            linkedList.Insert(3);
            linkedList.Insert(4);
            linkedList.Insert(5);

            ListNode<int> mid = linkedList.Middle();

            Assert.AreEqual(3, mid.Value);
        }
    }
}