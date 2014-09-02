namespace Structures
{
    using System;

    public class Matrix
    {
        public static void IterateLineCol(int[,] matrix, Action<int> doit)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    doit(matrix[i,j]); 
                }
            }
        }
    }
}