using System;

namespace _278_第一个错误的版本
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 第一个错误的版本（leetcode278题）
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (IsBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        /// <summary>
        /// 是否是坏的版本
        /// 此处模拟假的代码
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsBadVersion(int n)
        {
            return true;
        }
    }
}
