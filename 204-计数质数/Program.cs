using System;

namespace _204_计数质数
{
    class Program
    {
        /// <summary>
        /// 统计所有小于非负整数 n 的质数的数量
        /// 输入：n = 10
        /// 输出：4
        /// 解释：小于 10 的质数一共有 4 个, 它们是 2, 3, 5, 7 。
        /// </summary>
        /// <param name="args"></param>
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
            //for (int i = 2; i < n; i++)//直接判断从2到n-1是否存在n的约数即可
            //for (int i = 2; i <= Math.Sqrt(n); i++)//上述判断方法，明显存在效率极低的问题。对于每个数n，其实并不需要从2判断到n-1，我们知道，一个数若可以进行因数分解，那么分解时得到的两个数一定是一个小于等于sqrt(n)，一个大于等于sqrt(n),不需要遍历到n-1，遍历到sqrt(n)即可，因为若sqrt(n)左侧找不到约数，那么右侧也一定找不到约数
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
