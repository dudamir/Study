namespace Structures.Sorting
{
    using System;

    public class InsertionSorter<T> : Sorter<T>
    {
        private readonly Func<T, T, bool> _compare;

        public InsertionSorter(Func<T, T, bool> compare)
        {
            _compare = compare;
        }

        public void Sort(T[] unsorted)
        {
            for (int j = 1; j < unsorted.GetLength(0); j++)
            {
                T key = unsorted[j];

                int i = j - 1;
                while (i >= 0 && !_compare(unsorted[i], key))
                {
                    unsorted[i + 1] = unsorted[i];
                    i--;
                }
                unsorted[i + 1] = key;
            }
        }

        private static void Swap(T[] unsorted, int i, int j)
        {
            T aux = unsorted[i];
            unsorted[i] = unsorted[j];
            unsorted[j] = aux;
        }
    }
}