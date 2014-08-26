namespace Structures
{
    public class HashSet
    {
        public static int GetHashKey(string s)
        {
            int key = 0;
            
            for (int i = 0; i < s.Length; i++)
            {
                key += s[i];
            }

            return key;
        }
    }
}