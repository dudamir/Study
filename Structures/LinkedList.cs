namespace Structures
{
    using System;
    using System.Collections;

    public class LinkedList<T>
    {
        private int _size;
        private ListNode<T> _head;

        public void Insert(T value)
        {
            var current = NewNode(value);

            if (_head != null)
            {
                current.Next = _head;
            }

            _head = current;
            _size++;
        }

        public void Delete(T value)
        {
            if (_head.Value.Equals(value))
            {
                _head = _head.Next;
                _size--;
            }

            if (_head == null)
            {
                return;
            }

            Delete(_head, value);
        }

        public ListNode<T> Find(T value)
        {
            return Find(_head, value);
        }

        public int Length()
        {
            return _size;
        }

        public ListNode<T> Head()
        {
            return _head;
        }

        private static ListNode<T> NewNode(T value)
        {
            return new ListNode<T> { Value = value };
        }

        private ListNode<T> Find(ListNode<T> node, T value)
        {
            if (node == null || node.Value.Equals(value))
            {
                return node;
            }

            return Find(node.Next, value);
        }

        private void Delete(ListNode<T> previous, T value)
        {
            var current = previous.Next;

            if (current == null)
            {
                return;
            }
            
            if (current.Value.Equals(value))
            {
                previous.Next = current.Next;
                _size--;
                return;
            }

            Delete(current, value);
        }

        public void Iterate(Action<ListNode<T>> action)
        {
            var current = _head;

            while (current != null)
            {
                action(current);

                current = current.Next;
            }
        }

        public void Reverse()
        {
            var c = Swap(null, _head);

            _head = c;
        }

        public void RemoveDuplicates()
        {
            var exist = new Hashtable();

            ListNode<T> previous = _head;
            var current = _head.Next;
            while (current != null)
            {
                if (exist.ContainsKey(current.Value))
                {
                    if (previous != null)
                        previous.Next = current.Next;
                }
                else
                {
                    exist[current.Value] = true;
                    previous = current;
                }

                current = current.Next;
            }
        }

        public void RemoveDuplicatesNoAux()
        {
            var current = _head;

            while (current != null)
            {
                var compare = _head.Next;
                ListNode<T> previous = _head;

                while (compare != null)
                {
                    if (current.Value.Equals(compare.Value))
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        previous = compare;
                    }

                    compare = compare.Next;
                }

                current = current.Next;
            }
        }

        private ListNode<T> Swap(ListNode<T> previous, ListNode<T> current)
        {
            var next = current.Next;

            current.Next = previous;

            if (next == null) return current;

            return Swap(current, next);
        }
    }
}