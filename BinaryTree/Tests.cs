namespace BinaryTree
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;

    [TestClass]
    public class TestClass
    {

        [TestMethod]
        public void Print()
        {
            var root = new BinaryTreeNode
            {
                Value = 6, 
                Left = new BinaryTreeNode
                {
                    Value = 2, 
                    Left = new BinaryTreeNode { Value = 1 }, 
                    Right = new BinaryTreeNode { Value = 3 }
                },
                Right = new BinaryTreeNode
                {
                    Value = 9,
                    Left = new BinaryTreeNode
                    {
                        Value = 8,
                        Left = new BinaryTreeNode {  Value = 7 }
                    },
                    Right = new BinaryTreeNode
                    {
                        Value = 12,
                        Left = new BinaryTreeNode {  Value = 10 },
                        Right = new BinaryTreeNode
                        {
                            Value = 15,
                            Right = new BinaryTreeNode { Value  = 17 }
                        }
                    }
                }
            };

            Print(root);
        }

        [TestMethod]
        public void Insert()
        {
            var root = new BinaryTreeNode { Value = 2 };
            BinaryTree.Insert(root, 5);
            BinaryTree.Insert(root, 20);
            BinaryTree.Insert(root, 4);
            BinaryTree.Insert(root, 34);
            BinaryTree.Insert(root, 43);

            Print(root);
        }

        private static void Print(BinaryTreeNode root)
        {
            BinaryTree.Traverse(root, n => Console.WriteLine(n.Value));
        }
    }
}