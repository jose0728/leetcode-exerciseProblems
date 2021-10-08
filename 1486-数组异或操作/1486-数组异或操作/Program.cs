using System;

namespace _1486_数组异或操作
{
    class Program
    {
        /// <summary>
        /// 给你两个整数，n 和 start 。
        /// 数组 nums 定义为：nums[i] = start + 2*i（下标从 0 开始）且 n == nums.length 。
        /// 请返回 nums 中所有元素按位异或（XOR）后得到的结果。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            XorOperation(4, 3);
        }

        public static int XorOperation(int n, int start)
        {
            int[] arr = new int[n];
            int res = 0;
            for (int i = 0; i < n; i++)
            {
                arr[i] = start + 2 * i;
            }

            for (int i = 0; i < n; i++)
            {
                res ^= arr[i];
            }

            return res;
        }
    }
}
