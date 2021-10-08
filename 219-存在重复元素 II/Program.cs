using System;
using System.Collections.Generic;

namespace _219_存在重复元素_II
{
    class Program
    {
        /// <summary>
        /// 给定一个整数数组和一个整数 k，判断数组中是否存在两个不同的索引 i 和 j，使得 nums [i] = nums [j]，并且 i 和 j 的差的 绝对值 至多为 k。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //int[] nums = { 1, 2, 3, 1 };
            //int k = 3;

            int[] nums = { 1, 2, 3, 1, 2, 3 };
            int k = 2;

            var res = ContainsNearbyDuplicate(nums, k);
        }

        public static bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (nums.Length == 0)
                return false;
            HashSet<int> numSet = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (numSet.Contains(nums[i]))
                    return true;
                numSet.Add(nums[i]);
                //hash的长度如果超过k，那么删除最先添加进来的元素
                if (numSet.Count > k)
                    numSet.Remove(nums[i - k]);
            }
            return false;
        }
    }
}
