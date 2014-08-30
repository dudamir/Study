namespace HeapTests
{
    using System.Collections;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;
    using Structures.Sorting;

    [TestClass]
    public class HeapTreeConversion
    {
        [TestMethod]
        public void HeapIntoTree()
        {
            int[] heap = { 0, 10, 20, 30, 22, 27, 35, 39, 0, 0, 25, 28, 0, 0, 0, 40, 0, 0, 0, 0, 24 };

            BinaryTreeNode root = ConvertHeapToTree(heap);

            Printer.Print(root);
        }

        [TestMethod]
        public void TreeIntoHeap()
        {
            var root = GetUnbalancedTree();

            int[] heap = ConvertTreeToHeap(root);

            Printer.Print(heap);
        }

        [TestMethod]
        public void BalanceTree()
        {
            var root = GetUnbalancedTree();

            int[] heap = ConvertTreeToHeap(root);

            BinaryTreeNode balanced = ConvertToBalancedTree(heap);

            Printer.Print(balanced);
        }

        private static BinaryTreeNode ConvertToBalancedTree(int[] heap)
        {
            var sorter = new SelectionSorter<int>((i, j) => i < j);

            sorter.Sort(heap);
            var list = heap.ToList();

            list.RemoveAll(i => i == 0);

            var array = list.ToArray();
            return ConvertToBalancedTree(array, 0, array.GetLength(0) - 1);
        }

        private static BinaryTreeNode ConvertToBalancedTree(int[] heap, int left, int right)
        {
            if (left >= right)
                return null;

            int mid = (left + right)/2;

            var node = new BinaryTreeNode();
            node.Value = heap[mid];
            node.Left = ConvertToBalancedTree(heap, left, mid - 1);
            node.Right = ConvertToBalancedTree(heap, mid + 1, right);

            return node;
        }

        private static int[] ConvertTreeToHeap(BinaryTreeNode root)
        {
            var array = new ArrayList();

            ConvertTreeToHeap(root, array, 1);

            int j = array.Count - 1;
            
            while ((int)array[j] == 0)
            {
                array.RemoveAt(j);
                j--;
            }

            return (int[]) array.ToArray(typeof (int));

        }

        private static void ConvertTreeToHeap(BinaryTreeNode node, ArrayList array, int position)
        {
            if (position >= array.Count)
            {
                for (int i = array.Count; i <= position; i++)
                {
                    array.Add(0);
                }
            }

            if (node == null)
            {
                array[position] = 0;
                return;
            }

            array[position] = node.Value;

            ConvertTreeToHeap(node.Left, array, position * 2);
            ConvertTreeToHeap(node.Right, array, position * 2 + 1);
        }

        private static BinaryTreeNode ConvertHeapToTree(int[] heap, int position = 1)
        {
            if (position >= heap.GetLength(0))
            {
                return null;
            }

            if (heap[position] == 0)
            {
                return null;
            }

            var node = new BinaryTreeNode { Value = heap[position] };

            node.Left = ConvertHeapToTree(heap, position*2);
            node.Right = ConvertHeapToTree(heap, position*2 + 1);

            return node;
        }

        private static BinaryTreeNode GetUnbalancedTree()
        {
            var root = new BinaryTreeNode
            {
                Value = 10,
                Left = new BinaryTreeNode
                {
                    Value = 20,
                    Left = new BinaryTreeNode { Value = 22 },
                    Right = new BinaryTreeNode
                    {
                        Value = 27,
                        Left = new BinaryTreeNode
                        {
                            Value = 25,
                            Left = new BinaryTreeNode { Value = 24 }
                        },
                        Right = new BinaryTreeNode { Value = 28 }
                    }
                },
                Right = new BinaryTreeNode
                {
                    Value = 30,
                    Left = new BinaryTreeNode { Value = 35 },
                    Right = new BinaryTreeNode
                    {
                        Value = 39,
                        Right = new BinaryTreeNode { Value = 40 }
                    }
                }
            };
            return root;
        }
    }
}