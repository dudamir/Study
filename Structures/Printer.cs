namespace Structures
{
    using System;

    public static class Printer
    {
        public static void Print(LinkedList<int> result)
        {
            result.Iterate(n => Console.WriteLine(n.Value));
        }

        public static void Print(BinaryTreeNode root)
        {
            BinaryTree.Traverse(root, n => Console.WriteLine(n.Value));
        }
    }
}