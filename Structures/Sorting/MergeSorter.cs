namespace Structures.Sorting
{
    using System;

    public class MergeSorter<T> : Sorter<T>
    {
        private readonly Func<T, T, bool> _compare;

        public MergeSorter(Func<T, T, bool> compare)
        {
            _compare = compare;
        }

        public void Sort(T[] unsorted)
        {
            if (unsorted.GetLength(0) == 0)
                return;

            var sorted = Sort(unsorted, 0, unsorted.GetLength(0) - 1);

            for (int i = 0; i < unsorted.GetLength(0); i++)
            {
                unsorted[i] = sorted[i];
            }
        }

        public T[] Sort(T[] unsorted, int left, int right)
        {
            if (left == right)
            {
                return new[] { unsorted[left] };
            }

            if (Math.Abs(left - right) == 1)
            {
                var a = unsorted[left];
                var b = unsorted[right];

                if (_compare(a, b))
                {
                    return new[] { a, b };
                }
                
                return new []{b, a};
            }

            int mid = (left + right)/2;

            var lsorted = Sort(unsorted, left, mid);
            var rsorted = Sort(unsorted, mid + 1, right);

            return Merge(lsorted, rsorted);
        }

        private T[] Merge(T[] left, T[] right)
        {
            var lLength = left.GetLength(0);
            var rLength = right.GetLength(0);

            var result = new T[lLength + rLength];

            int l = 0;
            int r = 0;
            int z = 0;

            while (z < result.Length)
            {
                if ((l < lLength 
                        && r < rLength 
                        && _compare(left[l], right[r]))
                    || (r == rLength)
                        && (l < lLength))
                {
                    result[z] = left[l];
                    l++;
                }
                else
                {
                    result[z] = right[r];
                    r++;
                }

                z++;
            }

            return result;
        }
    }
}