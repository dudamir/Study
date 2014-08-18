namespace LinkedLists
{
    public class LinkedList
    {
        private ListNode _head;

        public LinkedList(ListNode head)
        {
            _head = head;
        }

        public void Insert(int value)
        {
            if (_head == null)
            {
                _head = NewNode(value);
            }
            else
            {
                var current = _head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = NewNode(value);
            }
        }

        public void Remove(int value)
        {
            if (_head.Value == value)
            {
                _head = _head.Next;
            }
            else
            {
                var current = _head;

                while (current.Next != null)
                {
                    if (current.Next.Value == value)
                    {
                        current.Next = current.Next.Next;
                        break;
                    }
                }
            }
        }

        private static ListNode NewNode(int value)
        {
            return new ListNode {Value = value};
        }
    }
}