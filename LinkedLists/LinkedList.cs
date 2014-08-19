namespace LinkedLists
{
    public class LinkedList
    {
        public int Size { get; private set; }

        public ListNode Head { get; private set; }

        public void Insert(int value)
        {
            var current = NewNode(value);

            if (Head != null)
            {
                current.Next = Head;
            }

            Head = current;
            Size++;
        }

        private static ListNode NewNode(int value)
        {
            return new ListNode {Value = value};
        }

        public ListNode Find(int value)
        {
            return Find(Head, value);
        }

        private ListNode Find(ListNode node, int value)
        {
            if (node == null || node.Value == value)
            {
                return node;
            }

            return Find(node.Next, value);
        }

        public void Delete(int value)
        {
            if (Head.Value == value)
            {
                Head = Head.Next;
                Size--;
            }

            Delete(Head, value);
        }

        private void Delete(ListNode previous, int value)
        {
            var current = previous.Next;

            if (current == null)
            {
                return;
            }
            
            if (current.Value == value)
            {
                previous.Next = current.Next;
                Size--;
                return;
            }

            Delete(current, value);
        }
    }
}