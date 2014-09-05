namespace Structures.Sorting
{
    public class QuickSorter : Sorter<int>
    {
        public void Sort(int[] unsorted)
        {
            Sort(unsorted, 0, unsorted.GetLength(0)- 1);
        }

        private void Sort(int[] unsorted, int low, int high)
        {
            if ((high - low) <= 0) return;

            int p = Partition(unsorted, low, high);

            Sort(unsorted, low, p - 1);
            Sort(unsorted, p + 1, high);
        }

        private static int Partition(int[] unsorted, int low, int high)
        {
            int pivot = high;
            int pValue = unsorted[pivot];
            int firstHigher = low;

            for (var i = low; i < high; i++)
            {
                if (unsorted[i] >= pValue) continue;
                
                Swap(unsorted, i, firstHigher);
                firstHigher++;
            }

            Swap(unsorted, firstHigher, pivot);

            return firstHigher;
        }

        private static void Swap(int[] unsorted, int i, int j)
        {
            if (i == j) return;

            var aux = unsorted[i];
            unsorted[i] = unsorted[j];
            unsorted[j] = aux;
        }
    }
}