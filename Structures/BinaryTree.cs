namespace Structures
{
    using System;

    public class BinaryTree
    {
        public static BinaryTreeNode Search(BinaryTreeNode root, int predicate)
        {
            if (root == null)
            {
                return null;
            }

            if (root.Value == predicate)
            {
                return root;
            }

            if (root.Value > predicate)
            {
                return Search(root.Left, predicate);
            }

            return Search(root.Right, predicate);
        }

        public static BinaryTreeNode Max(BinaryTreeNode root)
        {
            if (root == null) return null;

            if (root.Right == null)
            {
                return root;
            }

            return Max(root.Right);
        }

        public static void Traverse(BinaryTreeNode root, Action<BinaryTreeNode> process)
        {
            if (root == null)
            {
                return;
            }

            Traverse(root.Left, process);
            process(root);
            Traverse(root.Right, process);
        }

        public static void Insert(BinaryTreeNode root, int i)
        {
            if (root.Value == i)
                return;

            BinaryTreeNode next;
            if (root.Value > i)
            {
                if (root.Left == null)
                {
                    root.Left = new BinaryTreeNode { Value = i };
                    return;
                }

                next = root.Left;
            }
            else
            {
                if (root.Right == null)
                {
                    root.Right = new BinaryTreeNode { Value = i };
                }

                next = root.Right;
            }

            Insert(next, i);
        }
    }

    public class BinaryTreeNode
    {
        public int Value;

        public BinaryTreeNode Left;

        public BinaryTreeNode Right;

        public override string ToString()
        {
            return Value.ToString();
        }
    }

}