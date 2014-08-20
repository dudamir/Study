namespace Structures
{
    using System;

    public class Dictionary
    {
        private readonly LinkedList<DictionaryItem> _list = new LinkedList<DictionaryItem>();

        public object Search(int key)
        {
            ListNode<DictionaryItem> current = _list.Head();

            while (current != null)
            {
                var dictionaryItem = current.Value;

                if (dictionaryItem.Key == key)
                    return dictionaryItem.Value;
                
                current = current.Next;
            }

            return null;
        }

        public void Insert(int key, object value)
        {
            var current = Search(key);

            if (current != null)
            {
                throw new ApplicationException("Cannot insert a duplicated index in the dictionary");
            }

            _list.Insert(new DictionaryItem(key, value));
        }

        public void Delete(int key)
        {
            _list.Delete(new DictionaryItem(key, ""));
        }

        public int Max()
        {
            int max = 0;

            Iterate(max, GetMax);

            return max;
        }

        private T Iterate<T>(int max, Action<int, ListNode<DictionaryItem>> action)
        {
            var current = _list.Head();

            while (current != null)
            {
                action(max, current);

                current = current.Next;
            }
        }

        private static int GetMax(int max, ListNode<DictionaryItem> current)
        {
            var currentKey = current.Value.Key;

            if (currentKey > max)
            {
                max = currentKey;
            }
            return max;
        }

        public int Min()
        {
            return 0;
        }

        public object Predecessor(int key)
        {
            return null;
        }

        public object Sucessor(int key)
        {
            return null;
        }

        public int Length()
        {
            return _list.Length();
        }
    }
}