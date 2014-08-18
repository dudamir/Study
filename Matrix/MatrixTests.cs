namespace Matrix
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixTests
    {
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