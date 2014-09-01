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
            for (int i = 1; i < unsorted.GetLength(0); i++)
            {
                int j = i;

                while (j > 0 && _compare(unsorted[j], unsorted[j - 1]))
                {
                    Swap(unsorted, j, j - 1);
                    j--;
                }
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