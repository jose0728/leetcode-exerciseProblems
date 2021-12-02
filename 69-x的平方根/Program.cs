using System;

namespace _69_x的平方根
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = MySqr4(8);
        }

        /// <summary>
        /// x的平方根（leetcode69题）
        /// 二分法
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int MySqrt(int x)
        {
            if (x == 0) return 0;
            if (x == 1) return 1;
            long left = 1;
            long right = x / 2;
            while (left <= right)
            {
                long mid = (left + right) / 2;
                if (mid * mid == x)
                    return (int)mid;
                else if (mid * mid < x)
                    left = (int)(mid + 1);
                else
                    right = (int)(mid - 1);
            }
            return (int)right;
        }

        /// <summary>
        /// x的平方根（leetcode69题）
        /// 暴力解法
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int MySqr2(int x)
        {
            long res = 1;
            while (res * res <= x)
            {
                res++;
            }
            return (int)(res - 1);
        }

        public static int MySqr3(int x)
        {
            return (int)Math.Sqrt(x);
        }

        public static int MySqr4(int x)
        {
            if (x == 0)
                return 0;
            if (x == 1)
                return 1;
            long left = 1;
            long right = x / 2;

            while (left < right)
            {
                long mid = (right - left) / 2 + left;
                if (mid < x / mid)
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return (int)left;
        }
    }
}
