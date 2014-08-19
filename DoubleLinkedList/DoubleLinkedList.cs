namespace DoubleLinkedList
{
    public class DoubleLinkedList
    {
        private DoubleLinkedNode _head;
        private DoubleLinkedNode _tail;

        public void Insert(int value)
        {
            if (Size == 0)
            {
                var node = new DoubleLinkedNode(value);
                _head = node;
                _tail = node;
            }
            else
            {
                var node = new DoubleLinkedNode(value);

                _tail.Next = node;
                node.Previous = _tail;
                _tail = node;
            }

            Size++;
        }

        public int Size { get; private set; }

        public DoubleLinkedNode Head
        {
            get { return _head; }
        }

        public DoubleLinkedNode Tail
        {
            get { return _tail; }
        }

        public bool Has(int value)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Value == value) return true;

                current = current.Next;
            }

            return false;
        }

        public void Remove(int value)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Value == value)
                {
                    if (current == _head)
                    {
                        _head = current.Next;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                    }

                    if (current == _tail)
                    {
                        _tail = current.Previous;
                    }
                    else
                    {
                        current.Next.Previous = current.Previous;
                    }

                    Size--;
                }

                current = current.Next;
            }
        }
    }

    public class DoubleLinkedNode
    {
        public int Value;
        public DoubleLinkedNode Previous;
        public DoubleLinkedNode Next;

        public DoubleLinkedNode(int value)
        {
            Value = value;
        }
    }
}