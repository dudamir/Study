namespace Heaptests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;

    [TestClass]
    public class BasicOperations
    {
        [TestMethod]
        public void Insert()
        {
            var heap = GetHeapOfIntegers();
            heap.Insert(100);
            heap.Insert(200);
            heap.Insert(300);
            heap.Insert(20);
            heap.Insert(10);

            Printer.Print(heap);
        }

        [TestMethod]
        public void Pop()
        {
            var heap = GetHeapOfIntegers();
            heap.Insert(100);
            heap.Insert(200);
            heap.Insert(300);
            heap.Insert(20);
            heap.Insert(10);

            int result = heap.Pop();

            Assert.AreEqual(10, result);

            Printer.Print(heap);
        }

        private static Heap<int> GetHeapOfIntegers()
        {
            return new Heap<int>((i, j) => i < j);
        }
    }
}