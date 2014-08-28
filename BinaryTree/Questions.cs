namespace BinaryTree
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;

    [TestClass]
    public class Questions
    {
        [TestMethod]
        public void TransformsIntoLinkedList()
        {
            var root = new BinaryTreeNode { Value = 2 };
            BinaryTree.Insert(root, 5);
            BinaryTree.Insert(root, 20);
            BinaryTree.Insert(root, 4);
            BinaryTree.Insert(root, 34);
            BinaryTree.Insert(root, 43);

            Printer.Print(root);

            LinkedList<int> result = ConvertToLinkedList(root);

            Printer.Print(result);
        }


        private LinkedList<int> ConvertToLinkedList(BinaryTreeNode root)
        {
            var result = new LinkedList<int>();

            result.Insert(root.Value);

            if (root.Left == null && root.Right == null)
            {
                return result;
            }

            if (root.Left != null)
            {
                ConvertToLinkedList(root.Left, result);
            }

            if (root.Right != null)
            {
               ConvertToLinkedList(root.Right, result);
            }

            return result;
        }

        private void ConvertToLinkedList(BinaryTreeNode root, LinkedList<int> result)
        {
            result.Insert(root.Value);

            if (root.Left != null)
            {
                ConvertToLinkedList(root.Left, result);
            }

            if (root.Right != null)
            {
                ConvertToLinkedList(root.Right, result);
            }
        }
    }
}