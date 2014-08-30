namespace Structures.Sorting
{
    using System;

    public class SelectionSorter<T> : Sorter<T>
    {
        private readonly Func<T, T, bool> _compare;

        public SelectionSorter(Func<T, T, bool> compare)
        {
            _compare = compare;
        }

        public void Sort(T[] unsorted)
        {
            var len = unsorted.GetLength(0);

            for (int i = 0; i < len - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < len; j++)
                {
                    if (_compare(unsorted[j], unsorted[min])) min = j;
                }

                if (min != i)
                {
                    var aux = unsorted[i];
                    unsorted[i] = unsorted[min];
                    unsorted[min] = aux;
                }
            }
        }
    }
}