namespace MatrixTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;

    [TestClass]
    public class Questions
    {
        /// <summary>
        /// For each zero found in a matrix of integers, fill its collunm and its row with zeros.
        /// </summary>
        [TestMethod]
        public void FillWithZeros()
        {
            var matrix = new int[7,5];
                
            Matrix.Fill(matrix);

            matrix[2, 2] = 0;

            var rowsToZero = new Dictionary<int, int>();
            var colsToZero = new Dictionary<int, int>();
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    if (matrix[r, c] != 0) 
                        continue;
                    
                    if (!rowsToZero.ContainsKey(r))
                        rowsToZero.Add(r, 0);

                    if (!colsToZero.ContainsKey(r))
                        colsToZero.Add(r, 0);
                }
            }

            int[] rows = rowsToZero.Keys.ToArray();

            for (int i = 0; i < rows.GetLength(0); i++)
            {
                int r = rows[i];

                for (int c = 0; c < n; c++)
                {
                    matrix[r, c] = 0;
                }
            }

            int[] cols = colsToZero.Keys.ToArray();

            for (int i = 0; i < cols.GetLength(0); i++)
            {
                int c = cols[i];

                for (int r = 0; r < m; r++)
                {
                    matrix[r, c] = 0;
                }
            }

            // The whole colunm is zeroed
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                Assert.AreEqual(0, matrix[r,2]);
            }

            // The whole row is zeroed
            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                Assert.AreEqual(0, matrix[2, c]);
            }
        }

        /// <summary>
        /// Rotate a matrix 90 degrees.
        /// </summary>
        [TestMethod]
        public void Rotate90Degrees()
        {
            Assert.Inconclusive("not implemented.");
        }

        /// <summary>
        /// Identify the largest sub squares of 1's in a matrix of 0's and 1's
        /// </summary>
        [TestMethod]
        public void SubSquares()
        {
            Assert.Inconclusive("not implemented.");
        }

        /// <summary>
        /// Implement matrix multiplication.
        /// </summary>
        [TestMethod]
        public void Multiplication()
        {
            var a = new int[5, 3];

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

            var result = new int[5,4];

            Assert.AreEqual(18, result[0, 0]);
            Assert.AreEqual(11, result[4, 3]);
        }


    }
}