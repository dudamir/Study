namespace String
{
    using System;

    class Program
    {
        static void Main()
        {
            string str = "qwertyuiopããsdfghjklzxcvbnm~!@1234567890";

            bool result = StringAlg.HasOnlyUnique(str);

            Console.WriteLine("{0} has only unique chars: {1}", str, result);
            Console.ReadKey();
        }
    }

    internal class StringAlg
    {
        public static bool HasOnlyUnique(string str)
        {
            var has = new bool[256];

            for (int i = 0; i < str.Length; i++)
            {
                int cs = str[i];
                
                if (has[cs])
                    return false;

                has[cs] = true;;
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
