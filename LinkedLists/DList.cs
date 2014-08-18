namespace LinkedLists
{
    public class DList
    {
        private DNode _head;
        private DNode _tail;

        public void Insert(int value)
        {
            if (Size == 0)
            {
                var node = new DNode(value);
                _head = node;
                _tail = node;
            }
            else
            {
                var node = new DNode(value);

                _tail.Next = node;
                node.Previous = _tail;
                _tail = node;
            }

            Size++;
        }

        public int Size { get; private set; }

        public DNode Head
        {
            get { return _head; }
        }

        public DNode Tail
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

    public class DNode
    {
        public int Value;
        public DNode Previous;
        public DNode Next;

        public DNode(int value)
        {
            Value = value;
        }
    }
}