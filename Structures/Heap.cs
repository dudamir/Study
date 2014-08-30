namespace Structures
{
    using System;
    using System.Collections.Generic;

    public class Heap<T> where T : new()
    {
        private readonly Func<T, T, bool> _compare;
        private readonly List<T> _heap = new List<T>();

        public Heap(Func<T, T, bool> compare)
        {
            _compare = compare;
            _heap.Add(new T());
        }

        public Heap(T[] data, Func<T, T, bool> compare)
        {
            _compare = compare;
            _heap.Add(new T());

            var length = data.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                _heap.Add(data[i]);
            }

            for (int i = length/2; i >= 1; i--)
            {
                BalanceDown(_heap, i);
            }
        }

        public int Length
        {
            get { return _heap.Count - 1; }
        }

        public void Insert(T value)
        {
            _heap.Add(value);

            BalanceUp(_heap, Length);
        }

        private void BalanceUp(List<T> heap, int position)
        {
            if (position == 1)
                return;

            int p = position / 2;

            if (_compare(heap[p], heap[position]))
                return;

            Swap(heap, p, position);

            BalanceUp(heap, p);
        }

        private void BalanceNoRec(List<T> heap, int position)
        {
            while (position > 1)
            {
                int p = position/2;

                if (_compare(heap[p], heap[position]))
                    return;

                Swap(heap, p, position);

                position = p;
            }
        }

        private static void Swap(List<T> heap, int i, int j)
        {
            T aux = heap[i];
            heap[i] = heap[j];
            heap[j] = aux;
        }

        public T Get(int i)
        {
            return _heap[i + 1];
        }

        public T Pop()
        {
            if (Length <= 0) throw new Exception();

            var pop = _heap[1];

            _heap[1] = _heap[Length];

            _heap.RemoveAt(Length);
            
            BalanceDown(_heap, 1);

            return pop;
        }

        private void BalanceDown(List<T> heap, int position)
        {
            int left = position*2;
            int rigth = left + 1;

            if (left > Length)
                return;

            int min = position;
            if (_compare(heap[left], heap[position]))
            {
                min = left;
            }

            if (rigth <= Length && _compare(heap[rigth], heap[min]))
            {
                min = rigth;
            }

            if (min != position)
            {
                Swap(heap, min, position);
                BalanceDown(heap, min);
            }
        }
    }
}