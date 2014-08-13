namespace LinkedLists
{
    public class ListNode
    {
        public int Value;

        public ListNode Next;

        public ListNode Nth(int i)
        {
            if (i < 0 || Next == null)
            {
                return null;
            }

            if (i == 1)
            {
                return this;
            }

            return Next.Nth(i - 1);
        }

        public void InsertAfter(int i)
        {
            Next = new ListNode { Value = i, Next = Next };
        }
    }
}