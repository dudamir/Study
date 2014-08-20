﻿namespace Structures
{
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

        internal ListNode<T> Head()
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
    }
}