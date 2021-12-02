using System;

namespace _268_缺失数字
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = MissingNumber3(new int[] { 1, 2, 3, 5 });
        }

        /// <summary>
        /// 缺失数字（leetcode268题）
        /// 给定一个包含 0, 1, 2, ..., n 中 n 个数的序列，找出 0 .. n 中没有出现在序列中的那个数。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MissingNumber(int[] nums)
        {
            int n = nums.Length;
            int sum = 0;
            foreach (var v in nums)
            {
                sum += v;
            }
            return n * (n + 1) / 2 - sum;
        }

        public static int MissingNumber2(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i)
                {
                    return i;
                }
            }
            return n;
        }

        public static int MissingNumber3(int[] nums)
        {
            int missing = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                missing ^= i ^ nums[i];
            }
            return missing;
        }
    }
}
