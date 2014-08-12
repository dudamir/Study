namespace String
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string str = "abcd";

            bool result =  StringAlg.HasOnlyUniqueNoStructure(str);

            Console.WriteLine("{0} has only unique chars: {1}", str, result);
            Console.ReadKey();
        }
    }

    internal class StringAlg
    {
        public static bool HasOnlyUnique(string str)
        {
            var chars = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                
                if (chars.ContainsKey(c))
                    return false;

                chars.Add(c, 1);
            }

            return true;
        }

        public static bool HasOnlyUniqueNoStructure(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];

                for (int j = i + 1; j < str.Length; j++)
                {
                    if (str[j] == c)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
