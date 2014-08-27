namespace Arrays
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Questions
    {
        /// <summary>
        /// Given an array of ranges, please merge the overlapping ones. 
        /// For example, four ranges [5, 13], [27, 39], [8, 19], [31, 37] (in blue in  Figure1) are merged into two ranges, which are [5, 19] and [27, 39] (in green in Figure 1).
        /// </summary>
        [TestMethod]
        public void MergingRanges()
        {
            var arrayOfRanges = new[]
            {
                new Range {Start = 5, End = 13 },
                new Range {Start = 27, End = 39 },
                new Range {Start = 8, End = 19 },
                new Range {Start = 31, End = 37 },
            };

            Range[] merged = Merge(arrayOfRanges);

            PrintRanges(merged);
        }

        private static Range[] Merge(Range[] ranges)
        {
            var sorted = ranges.OrderBy(r => r.Start).ToArray();
            var result = new Range[ranges.GetLength(0)];
            int c = 0;

            for (int i = 0; i < sorted.GetLength(0); i++)
            {
                if (i == 0)
                {
                    result[c] = sorted[i];
                    continue;
                }

                if (sorted[i].Start <= result[c].End)
                {
                    if (sorted[i].End > result[c].End)
                        result[c].End = sorted[i].End;
                }
                else
                {
                    c++;
                    result[c] = sorted[i];
                }
            }

            return result;
        }

        private static void PrintRanges(Range[] merged)
        {
            foreach (var range in merged)
            {
                if (range != null) Console.WriteLine("Start: {0} End : {1}", range.Start, range.End);
            }
        }
    }

    public class Range
    {
        public int Start;
        public int End;
    }
}