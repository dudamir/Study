namespace Arrays
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Looping
    {
        [TestMethod]
        public void PrintPrimes()
        {
            int n = 20;
            
            var prime = GetPrimes(n);

            for (int i = 0; i < prime.Length; i++)
            {
                if (prime[i])
                {
                    Console.Write("{0}, ", i);
                }
            }
        }

        [TestMethod]
        public void PrintPascal()
        {
            int n = 10;
            var triangle = new int[n][];

            for (int i = 0; i < n; i++)
            {
                triangle[i] = new int[i + 1];
                triangle[i][0] = 1;

                for (int j = 1; j < i; j++)
                {
                    triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
                }
                triangle[i][i] = 1;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("{0} ", triangle[i][j]);
                }
                
                Console.WriteLine();
            }
        }

        private static bool[] GetPrimes(int n)
        {
            var prime = new bool[n + 1];

            for (int i = 2; i <= n; i++)
            {
                prime[i] = true;
            }

            for (int divisor = 2; divisor * divisor <= n; divisor++)
            {
                if (prime[divisor])
                {
                    for (int i = 2 * divisor; i <= n; i = i + divisor)
                    {
                        prime[i] = false;
                    }
                }
            }

            return prime;
        }
    }
}
