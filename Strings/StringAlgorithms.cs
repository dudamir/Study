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
    }
}