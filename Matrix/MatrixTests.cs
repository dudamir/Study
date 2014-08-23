namespace Matrix
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixTests
    {
        [TestMethod]
        public void Zeros()
        {
            var m = new int[10,8];

            Fill(m);

            m[0, 0] = 0;

            int lines = m.GetLength(0);
            int cols = m.GetLength(1);
            var lToZero = new bool[lines];
            var cToZero = new bool[cols];


            for (int l = 0; l < lines; l++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (m[l, c] == 0)
                    {
                        lToZero[l] = true;
                        cToZero[c] = true;
                    }
                }
            }

            for (int i = 0; i < lines; i++)
            {
                if (lToZero[i])
                {
                    for (int c = 0; c < cols; c++)
                    {
                        m[i, c] = 0;
                    }
                }
            }

            for (int i = 0; i < cols; i++)
            {
                if (cToZero[i])
                {
                    for (int l = 0; l < lines; l++)
                    {
                        m[l, i] = 0;
                    }
                }
            }

            Print(m);
        }

        [TestMethod]
        public void Rotate90()
        {
            var matrix = new int[4,3];

            Fill(matrix);

            var lines = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            var newMatrix = new int[cols, lines];

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    newMatrix[cols - 1 - j, i] = matrix[i, j];
                }
            }


            Print(matrix);
            Print(newMatrix);
        }

        private static void Fill(int[,] matrix)
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

        private static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0, 2} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        [TestMethod]
        public void Multiplication()
        {
            var a = new int[5,3];

            a[0, 0] = 4;
            a[0, 1] = 5;
            a[0, 2] = 6;

            a[1, 0] = 1;
            a[1, 1] = 2;
            a[1, 2] = 3;

            a[2, 0] = 2;
            a[2, 1] = 4;
            a[2, 2] = 1;

            a[3, 0] = 1;
            a[3, 1] = 1;
            a[3, 2] = 1;

            a[4, 0] = 2;
            a[4, 1] = 0;
            a[4, 2] = 1;

            var b = new int[3, 4];

            b[0, 0] = 3;
            b[0, 1] = 1;
            b[0, 2] = 4;
            b[0, 3] = 5;

            b[1, 0] = 0;
            b[1, 1] = 1;
            b[1, 2] = 0;
            b[1, 3] = 2;

            b[2, 0] = 1;
            b[2, 1] = 1;
            b[2, 2] = 1;
            b[2, 3] = 1;

            int[,] result = Multiply(a, b);

            Assert.AreEqual(18, result[0,0]);
            Assert.AreEqual(11, result[4,3]);
        }

        private int[,] Multiply(int[,] a, int[,] b)
        {
            var nrows = a.GetLength(0);
            var ncolls = b.GetLength(1);
            var even = a.GetLength(1);

            var result = new int[nrows, ncolls];

            for (int r = 0; r < nrows; r++)
            {
                for (int c = 0; c < ncolls; c++)
                {
                    for (int i = 0; i < even; i++)
                    {
                        result[r,c] += a[r,i] * b[i,c];
                    }
                }
            }

            return result;
        }
    }
}