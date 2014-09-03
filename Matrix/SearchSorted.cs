namespace MatrixTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Structures;

    [TestClass]
    public class SearchSorted
    {
        [TestMethod]
        public void SearchLinearTest()
        {
            int[,] sorted = GetSortedMatrix();

            AssertIsSorted(sorted);

            Assert.IsFalse(SearchLinear(sorted, 53));
            Assert.IsTrue(SearchLinear(sorted, 63));
        }

        [TestMethod]
        public void SearchBinaryTest()
        {
            int[,] sorted = GetSortedMatrix();

            AssertIsSorted(sorted);

            Assert.IsFalse(SearchBinary(sorted, 53));
            Assert.IsTrue(SearchBinary(sorted, 63));
        }

        [TestMethod]
        public void SearchDiagonalBinaryTest()
        {
            int[,] sorted = GetSortedMatrix();

            AssertIsSorted(sorted);

            Assert.IsFalse(SearchDiagonalBinary(sorted, 53));
            Assert.IsTrue(SearchDiagonalBinary(sorted, 87));
            Assert.IsTrue(SearchDiagonalBinary(sorted, 77));
        }

        [TestMethod]
        public void SearchQuadTest()
        {
            int[,] sorted = GetSortedMatrix();

            AssertIsSorted(sorted);

            Assert.IsFalse(SearchQuad(sorted, 53));
            Assert.IsTrue(SearchQuad(sorted, 63));
            Assert.IsTrue(SearchDiagonalBinary(sorted, 87));
            Assert.IsTrue(SearchDiagonalBinary(sorted, 77));
        }

        [TestMethod]
        public void SearchLeftDownTest()
        {
            int[,] sorted = GetSortedMatrix();

            AssertIsSorted(sorted);

            Assert.IsFalse(SearchLeftDown(sorted, 53));
            Assert.IsTrue(SearchLeftDown(sorted, 63));
            Assert.IsTrue(SearchLeftDown(sorted, 87));
            Assert.IsTrue(SearchLeftDown(sorted, 77));
        }

        private bool SearchLeftDown(int[,] matrix, int find)
        {
            int len = matrix.GetLength(0);

            int l = 0;
            int c = len - 1;

            while (l < len && c >= 0)
            {
                var current = matrix[l, c];

                if (current == find)
                    return true;

                if (current < find)
                    l++;
                else
                    c--;
            }

            return false;
        }

        private bool SearchQuad(int[,] matrix, int find)
        {
            return SearchQuad(matrix, 0, matrix.GetLength(0) - 1, 0, matrix.GetLength(1) - 1, find);
        }

        private bool SearchQuad(int[,] matrix, int lineLeft, int lineRight, int colLeft, int colRight, int find)
        {
            if ((lineRight - lineLeft) == 1 && (colRight - colLeft) == 1)
            {
                for (int l = lineLeft; l <= lineRight; l++)
                {
                    for (int c = colLeft; c < colRight; c++)
                    {
                        if (matrix[l, c] == find)
                            return true;
                    }
                }

                return false;
            }

            int lineMid = (lineLeft + lineRight)/2;

            int newColLeft = colLeft;
            int newColRight = colRight;

            while ((newColRight - newColLeft) > 1)
            {
                int colMid = (newColLeft + newColRight) / 2;

                var current = matrix[lineMid, colMid];
                if (current == find)
                    return true;

                if (current > find)
                {
                    newColRight = colMid;
                }
                else
                {
                    newColLeft = colMid;
                }
            }

            if (newColLeft == colLeft && matrix[lineMid, newColLeft] == find)
                return true;

            if (newColRight == colRight && matrix[lineMid, newColRight] == find)
                return true;

            return SearchQuad(matrix, lineMid + 1, lineRight, colLeft, newColLeft - 1, find);

        }

        private bool SearchDiagonalBinary(int[,] sorted, int find)
        {
            int c = sorted.GetLength(1) - 1;

            for (int l = 0; l < sorted.GetLength(0); l++)
            {
                var current = sorted[l, c];

                if (current == find)
                    return true;

                if (current < find && BSearchCol(sorted, c, l + 1, sorted.GetLength(0) -1 , find))
                    return true;

                if (current > find && BSearchLine(sorted, l, 0, c - 1, find))
                    return true;
                
                c--;
            }

            return false;
        }

        private bool SearchBinary(int[,] sorted, int find)
        {
            int right = sorted.GetLength(1) - 1;

            for (int l = 0; l < sorted.GetLength(0); l++)
            {
                if (BSearchLine(sorted, l, 0, right, find))
                    return true;
            }

            return false;
        }
        
        private static bool BSearchCol(int[,] sorted, int col, int left, int right, int find)
        {
            if (left > right)
                return false;

            int mid = (left + right) / 2;
            var current = sorted[mid, col];

            if (find == current)
                return true;

            if (find < current)
                return BSearchCol(sorted, col, left, mid - 1, find);

            return BSearchCol(sorted, col, mid + 1, right, find);
        }

        private static bool BSearchLine(int[,] sorted, int line, int left, int right, int find)
        {
            if (left >= right)
                return false;

            var mid = (left + right)/2;
            var current = sorted[line, mid];
            
            if (find == current)
                return true;

            if (find < current)
                return BSearchLine(sorted, line, left, mid - 1, find);

            return BSearchLine(sorted, line, mid + 1, right, find);
        }
        
        private static bool SearchLinear(int[,] sorted, int find)
        {
            for (var l = 0; l < sorted.GetLength(0); l++)
            {
                for (var c = 0; c < sorted.GetLength(1); c++)
                {
                    if (sorted[l, c] == find) 
                        return true;
                }
            }

            return false;
        }

        public void AssertIsSorted(int[,] matrix)
        {
            Printer.Print(matrix);

            for (int l = 0; l < matrix.GetLength(0); l++)
            {
                for (int c = 0; c < matrix.GetLength(0) - 1; c++)
                {
                    if (matrix[l, c] > matrix[l, c + 1])
                        Assert.Fail(
                            "line: {0}. Col {1} = {2} is greater than Col {3} = {4}", l, c, matrix[l,c], c + 1, matrix[l, c + 1]);
                }
            }

            for (int c = 0; c < matrix.GetLength(1); c++)
            {
                for (int l = 0; l < matrix.GetLength(0) - 1; l++)
                {
                    if (matrix[l, c] > matrix[l + 1, c])
                        Assert.Fail(
                            "Col: {0}. Line {1} = {2} is greater than line {3} = {4}", c, l, matrix[l, c], l + 1, matrix[l + 1, c]);
                    
                }
            }
        }

        private static int[,] GetSortedMatrix()
        {
            var ret = new int[10,10];

            ret[0, 0] = 0;
            ret[0, 1] = 1;
            ret[0, 2] = 5;
            ret[0, 3] = 8;
            ret[0, 4] = 10;
            ret[0, 5] = 15;
            ret[0, 6] = 18;
            ret[0, 7] = 25;
            ret[0, 8] = 30;
            ret[0, 9] = 45;

            ret[1, 0] = 1;
            ret[1, 1] = 5;
            ret[1, 2] = 9;
            ret[1, 3] = 14;
            ret[1, 4] = 30;
            ret[1, 5] = 34;
            ret[1, 6] = 40;
            ret[1, 7] = 42;
            ret[1, 8] = 90;
            ret[1, 9] = 100;

            ret[2, 0] = 1;
            ret[2, 1] = 9;
            ret[2, 2] = 14;
            ret[2, 3] = 23;
            ret[2, 4] = 32;
            ret[2, 5] = 45;
            ret[2, 6] = 46;
            ret[2, 7] = 47;
            ret[2, 8] = 101;
            ret[2, 9] = 110;


            ret[3, 0] = 2;
            ret[3, 1] = 12;
            ret[3, 2] = 16;
            ret[3, 3] = 38;
            ret[3, 4] = 39;
            ret[3, 5] = 59;
            ret[3, 6] = 61;
            ret[3, 7] = 63;
            ret[3, 8] = 111;
            ret[3, 9] = 121;

            ret[4, 0] = 2;
            ret[4, 1] = 35;
            ret[4, 2] = 37;
            ret[4, 3] = 40;
            ret[4, 4] = 42;
            ret[4, 5] = 60;
            ret[4, 6] = 62;
            ret[4, 7] = 67;
            ret[4, 8] = 131;
            ret[4, 9] = 132;

            ret[5, 0] = 7;
            ret[5, 1] = 36;
            ret[5, 2] = 41;
            ret[5, 3] = 54;
            ret[5, 4] = 67;
            ret[5, 5] = 89;
            ret[5, 6] = 93;
            ret[5, 7] = 99;
            ret[5, 8] = 150;
            ret[5, 9] = 160;

            ret[6, 0] = 11;
            ret[6, 1] = 45;
            ret[6, 2] = 65;
            ret[6, 3] = 66;
            ret[6, 4] = 87;
            ret[6, 5] = 100;
            ret[6, 6] = 121;
            ret[6, 7] = 130;
            ret[6, 8] = 200;
            ret[6, 9] = 210;

            ret[7, 0] = 12;
            ret[7, 1] = 76;
            ret[7, 2] = 87;
            ret[7, 3] = 90;
            ret[7, 4] = 99;
            ret[7, 5] = 120;
            ret[7, 6] = 200;
            ret[7, 7] = 210;
            ret[7, 8] = 211;
            ret[7, 9] = 300;

            ret[8, 0] = 20;
            ret[8, 1] = 77;
            ret[8, 2] = 98;
            ret[8, 3] = 100;
            ret[8, 4] = 200;
            ret[8, 5] = 300;
            ret[8, 6] = 301;
            ret[8, 7] = 340;
            ret[8, 8] = 345;
            ret[8, 9] = 354;

            ret[9, 0] = 23;
            ret[9, 1] = 92;
            ret[9, 2] = 121;
            ret[9, 3] = 222;
            ret[9, 4] = 322;
            ret[9, 5] = 433;
            ret[9, 6] = 500;
            ret[9, 7] = 540;
            ret[9, 8] = 569;
            ret[9, 9] = 580;

            return ret;
        }
    }
}