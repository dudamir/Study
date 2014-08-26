namespace LinkedLists
{
    using System;
    using System.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;

    [TestClass]
    public class Questions
    {
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
        public void RemoveDuplicates()
        {
            var linkedList = new LinkedList<int>();

            linkedList.Insert(5);
            linkedList.Insert(5);
            linkedList.Insert(5);
            linkedList.Insert(5);

            linkedList.RemoveDuplicatesNoAux();


            linkedList.Iterate(c => Console.WriteLine(c.Value));
        }
    }
}