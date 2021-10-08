using System;

namespace _204_计数质数
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = CountPrimes2(17);
        }

        /// <summary>
        /// 枚举 超时！！！
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int CountPrimes(int n)
        {
            int count = 0;
            for (int i = 2; i < n; i++)
            {
                count += IsPrimes(i) ? 1 : 0;
            }
            return count;
        }

        public static bool IsPrimes(int n)
        {
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 埃及筛
        /// 从小到大遍历每个数，如果这个数为质数，则将其所有的倍数都标记为合数（除了该质数本身）
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int CountPrimes2(int n)
        {
            int count = 0;
            bool[] primes = new bool[n + 1];

            for (int i = 2; i < n; i++)
            {
                if (primes[i])
                    continue;
                count++;
                for (int j = 2; i * j < n; ++j)
                {
                    primes[i * j] = true;
                }
            }
            return count;
        }
    }
}
