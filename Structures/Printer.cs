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

        public static void Print(int[] numbers)
        {
            foreach (var i in numbers)
            {
                Console.WriteLine(i);
            }
        }

        public static void Print<T>(Heap<T> numbers) where T : new()
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers.Get(i));
            }
        }

        public static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}