namespace Strings
{
    static internal class StringAlgorithms
    {
        public static bool HasDupChar(string str)
        {
            var has = new bool[256];
            
            for (int i = 0; i < str.Length; i++)
            {
                int c = str[i];
                
                if (has[c])
                {
                    return true;
                }

                has[c] = true;
            }

            return false;
        }

        public static bool HasDupCharNoAux(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                int c = str[i];

                for (int j = i + 1; j < str.Length; j++)
                {
                    if (str[j] == c)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static string Reverse(string str)
        {
            int len = str.Length;
            var reversed = new char[str.Length];

            for (int i = len - 1; i >= 0; i--)
            {
                reversed[len - 1 - i] = str[i];
            }

            return new string(reversed);
        }

        public static bool AreAnagram(string str, string ana)
        {
            return false;
        }

        public static string RemoveDuplicate(string str)
        {
            var has = new bool[256];
            string newstr = string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];

                if (!has[c])
                {
                    newstr += c;
                    has[c] = true;
                }
            }

            return newstr;
        }
    }
}