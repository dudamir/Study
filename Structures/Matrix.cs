namespace Structures
{
    using System;

    public class Matrix
    {
        public static void IterateLineCol<T>(T[,] matrix, Action<T> doit)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    doit(matrix[i, j]);
                }
            }
        }

        public static void Fill(int[,] matrix)
        {
            int x = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = x;
                    x++;
                }
            }
        }

        public static void FillBinary(int[,] matrix)
        {
            var random = new Random();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(0, 2);
                }
            }
        }
    }
}