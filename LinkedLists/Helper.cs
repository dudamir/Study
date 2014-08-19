namespace LinkedLists
{
    public static class Helper
    {
        internal static LinkedList GetList(int numberOfNodes)
        {
            var list = new LinkedList();

            for (int i = 1; i <= numberOfNodes; i++)
            {
                list.Insert(i);
            }

            return list;
        }
    }
}