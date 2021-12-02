using System;

namespace _231_2的幂
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = IsPowerOfTwo3(8);
        }

        /// <summary>
        /// 2的幂
        /// 给定一个整数，编写一个函数来判断它是否是 2 的幂次方。
        /// </summary>
        /// 利用技巧
        /// 对于N为2的幂的数，都有 N&(N-1)=0
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPowerOfTwo(int n)
        {
            return n > 0 && (n & (n - 1)) == 0;
        }

        /// <summary>
        /// 2的幂
        /// 给定一个整数，编写一个函数来判断它是否是 2 的幂次方。
        /// </summary>
        /// 利用技巧
        /// 对于N为2的幂的数，都有 x & (-x)=x
        /// -10的二进制位是10的二进制位通过求补得到
        /// 求补的方法：按位取反加一。技巧法：从右到左的第一个1以及它的右侧的位都不变，它的左侧按位取反
        /// 10 & (-10) = 0000 1010 & 1111 0110 = 0000 00 10
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPowerOfTwo2(int n)
        {
            return n > 0 && (n & (-n)) == n;
        }

        /// <summary>
        /// 2的幂
        /// 给定一个整数，编写一个函数来判断它是否是 2 的幂次方。
        /// 遍历
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPowerOfTwo3(int n)
        {
            if (n == 0) return false;
            while (n % 2 == 0) n /= 2;
            return n == 1;
        }
    }
}
