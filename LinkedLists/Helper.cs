namespace LinkedLists
{
    using Structures;

    public static class Helper
    {
        internal static LinkedList<int> GetList(int numberOfNodes)
        {
            var list = new LinkedList<int>();

            for (int i = 1; i <= numberOfNodes; i++)
            {
                list.Insert(i);
            }

            return list;
        }
    }
}