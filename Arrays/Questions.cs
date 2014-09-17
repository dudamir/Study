namespace Arrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Questions
    {
        /// <summary>
        /// Find the max subarray (sum) from a full array
        /// </summary>
        [TestMethod]
        public void FindMaxSubArray()
        {
            // var array = new[] { 2, -4, 1, 1, -5, 4 };
            // var array = new[] { 1, 2, 1, 4, 5, 4 };
            // var array = new[] { -1, 1, 1, 1, -2, -1 };
            var array = new[] { 1, -1, -1, -1, -1, -2, -1 };

            Range maxSubArray = MaxSubArray(array, 0, array.GetLength(0) - 1);

            Assert.AreEqual(0, maxSubArray.Start);
            Assert.AreEqual(0, maxSubArray.End);
            Assert.AreEqual(1, maxSubArray.Sum);
        }

        private Range MaxSubArray(int[] array, int left, int right)
        {
            if (left == right)
                return new Range { Start = left, End = right, Sum = array[left] };

            int mid = (left + right)/2;

            var leftRange = MaxSubArray(array, left, mid);
            var rightRange = MaxSubArray(array, mid + 1, right);
            var crossRange = MaxCrossSubArray(array, left, right, mid);

            if (leftRange.Sum > rightRange.Sum && leftRange.Sum > crossRange.Sum)
                return leftRange;

            if (rightRange.Sum > crossRange.Sum)
                return rightRange;

            return crossRange;
        }

        private Range MaxCrossSubArray(int[] array, int left, int right, int mid)
        {
            int begin = mid;
            int end = mid;
            int sum = array[mid];
            int subsum = sum;

            for (int i = mid -1; i >= left; i--)
            {
                subsum += array[i];

                if (subsum > sum)
                {
                    sum = subsum;
                    begin = i;
                }
            }

            subsum = sum;
            for (int i = mid + 1; i <= right; i++)
            {
                subsum += array[i];

                if (subsum > sum)
                {
                    sum = subsum;
                    end = i;
                }
            }

            return new Range { Start = begin, End = end, Sum = sum };
        }

        /// <summary>
        /// Calculate the median of two sorted arrays in O(logn)
        /// </summary>
        [TestMethod]
        public void MedianTwoSortedArrays()
        {
            int[] a = { 10, 20, 30, 40 };
            int[] b = { 10, 20, 30, 40 };

            int median = FindMedian(a, b);

            Assert.AreEqual(25, median);

            a = new [] { 10, 20, 30, 40, 50 };
            b = new [] { 10, 20, 30, 40 };

            median = FindMedian(a, b);

            Assert.AreEqual(30, median);

            a = new[] { 10, 20, 30, 40 };
            b = new[] { 50, 60, 70, 80 };

            median = FindMedian(a, b);

            Assert.AreEqual(45, median);

            a = new[] { 10, 20, 30, 40 };
            b = new[] { 50, 60, 70, 80, 90 };

            median = FindMedian(a, b);

            Assert.AreEqual(50, median);
        }

        private static int FindMedian(int[] a, int[] b)
        {
            return MergeMedian(a, b);
        }

        private static int MergeMedian(int[] a, int[] b)
        {
            var alen = a.GetLength(0);
            var blen = b.GetLength(0);

            int l = alen + blen;

            int h = l/2;

            int m = -1;
            int m2 = -1;

            int z = 0;
            int w = 0;

            for (int i = 0; i <= h; i++)
            {
                m = m2;
                if (z == alen)
                {
                    m2 = b[w];
                    w++;
                }
                else if (w == blen)
                {
                    m2 = a[z];
                    z++;
                }
                else
                {
                    if (a[z] < b[w])
                    {
                        m2 = a[z];
                        z++;
                    }
                    else
                    {
                        m2 = b[w];
                        w++;
                    }
                }
            }

            if (h*2 == l)
            {
                return (m + m2)/2;
            }

            return m2;
        }

        private int Median(int[] a, int left, int right)
        {
            int size = (right - left) + 1;
            int m = (left + right)/2;


            if (size%2 == 0)
                return (a[m] + a[m + 1])/2;

            return a[m];
        }

        /// <summary>
        /// Given an array size n, find the element that repeats more than n/k times.
        /// </summary>
        [TestMethod]
        public void ElementWithNkRepeats()
        {
            int[] a = { 1, 2, 2, 1, 1, 2, 4, 4 };
            int k = 4;

            int n = a.GetLength(0);
            int numOfCandidates = n/(n/k + 1);

            var candidates = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var cand = a[i];

                if (candidates.ContainsKey(cand))
                {
                    candidates[cand]++;
                    continue;
                }

                if (candidates.Count < numOfCandidates)
                {
                    candidates.Add(cand, 1);
                }
                else
                {
                    var keys = candidates.Keys.ToList();

                    for (int j = 0; j < keys.Count; j++)
                    {
                        candidates[keys[j]]--;
                    }
                }
            }

            var keys1 = candidates.Keys.ToList();

            for (int j = 0; j < keys1.Count; j++)
            {
                candidates[keys1[j]] = 0;
            }

            for (int i = 0; i < n; i++)
            {
                var cand = a[i];

                if (candidates.ContainsKey(cand))
                    candidates[cand]++;
            }

            foreach (var candidate in candidates)
            {
                if (candidate.Value <= n/k)
                    candidates.Remove(candidate.Key);
            }

            Assert.AreEqual(2, candidates.Count());
            Assert.IsTrue(candidates.ContainsKey(2));
            Assert.IsTrue(candidates.ContainsKey(1));
        }

        /// <summary>
        /// Given an array size n, find the element that repeats more than n/2 times.
        /// </summary>
        [TestMethod]
        public void ElementWith2NRepeats()
        {
            int[] a = { 1, 2, 2, 1, 1, 2, 4, 4 };

            int m = Majority(a);

            Assert.AreEqual(2, m);
        }

        static int Majority(int[] array)
        {
            int counter = 0;
            int current = -1;

            for(int i = 0; i < array.GetLength(0); i++)
            {
                if (counter == 0)
                {
                    current = array[i];
                    counter = 1; 
                }
                else
                {
                    if (array[i] == current)
                        counter++;
                    else
                        counter--;
                }
            }
            
            return current;
        }

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
                new Range {Start = 31, End = 37 }
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
        public int Sum;
    }
}