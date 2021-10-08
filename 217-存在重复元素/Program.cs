using System;
using System.Collections.Generic;

namespace _217_存在重复元素
{
    class Program
    {
        /// <summary>
        /// 给定一个整数数组，判断是否存在重复元素
        /// 如果存在一值在数组中出现至少两次，函数返回 true 。如果数组中每个元素都不相同，则返回 false 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool ContainsDuplicate(int[] nums)
        {
            if (nums.Length == 0)
                return false;
            Array.Sort(nums);

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i - 1] == nums[i])
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 哈希
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool ContainsDuplicate2(int[] nums)
        {
            if (nums.Length == 0)
                return false;
            HashSet<int> numSet = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (numSet.Contains(nums[i]))
                    return true;
                numSet.Add(nums[i]);
            }

            return false;
        }
    }
}
