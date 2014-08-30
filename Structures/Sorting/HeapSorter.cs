namespace Structures.Sorting
{
    using System;

    public class HeapSorter<T> : Sorter<T> where T : new()
    {
        private readonly Func<T, T, bool> _compare;

        public HeapSorter(Func<T, T, bool> compare)
        {
            _compare = compare;
        }

        public void Sort(T[] unsorted)
        {
            var heap = new Heap<T>(unsorted, _compare);

            for (int i = 0; i < unsorted.GetLength(0); i++)
            {
                unsorted[i] = heap.Pop();
            }
        }


    }
}