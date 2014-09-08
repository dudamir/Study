namespace Structures.Sorting
{
    using System;

    public class BubbleSorter<T> : Sorter<T>
    {
        private readonly Func<T, T, bool> _compare;

        public BubbleSorter(Func<T, T, bool> compare)
        {
            _compare = compare;
        }

        public void Sort(T[] unsorted)
        {
            for (int i = 0; i < unsorted.GetLength(0) - 2; i++)
            {
                if (!_compare(unsorted[i], unsorted[i + 1]))
                {
                    Swapper.Swap(unsorted, i, i + 1);
                }
            }
        }
    }
}