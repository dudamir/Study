namespace Structures
{
    public class ListNode<T>
    {
        public T Value;

        public ListNode<T> Next;

        public ListNode<T> Nth(int i)
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

        public void InsertAfter(T value)
        {
            Next = new ListNode<T> { Value = value, Next = Next };
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}