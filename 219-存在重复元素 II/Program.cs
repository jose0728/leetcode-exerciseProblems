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
            //int[] nums = { 1, 2, 3, 4 , 5, 1 };
            //int k = 3;

            int[] nums = { 1, 2, 3, 1, 2, 3 };
            int k = 2;

            var res = ContainsNearbyDuplicate3(nums, k);
        }

        /// <summary>
        /// HashSet-最快
        /// nums[i - k] 
        /// i = 2 -->0
        /// i = 3 -->1
        /// i = 4 -->2
        /// i = 5 -->3
        /// HashSet里面存的是具体的数字
        /// nums[i - k] 可以记录数字添加到hashSet的顺序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Queue-第二快
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool ContainsNearbyDuplicat2(int[] nums, int k)
        {
            if (nums.Length == 0)
                return false;
            Queue<int> numSet = new Queue<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (numSet.Contains(nums[i]))
                    return true;
                numSet.Enqueue(nums[i]);
                //hash的长度如果超过k，那么删除最先添加进来的元素
                if (numSet.Count > k)
                    numSet.Dequeue();
            }
            return false;
        }

        /// <summary>
        /// List-最慢
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool ContainsNearbyDuplicate3(int[] nums, int k)
        {
            if (nums.Length == 0)
                return false;
            List<int> numSet = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (numSet.Contains(nums[i]))
                    return true;
                numSet.Add(nums[i]);
                //hash的长度如果超过k，那么删除最先添加进来的元素
                if (numSet.Count > k)
                    numSet.RemoveAt(0);
            }
            return false;
        }

        /// <summary>
        /// List-最慢
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool ContainsNearbyDuplicate4(int[] nums, int k)
        {
            if (nums.Length == 0)
                return false;
            List<int> numSet = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (numSet.Contains(nums[i]))
                    return true;
                numSet.Add(nums[i]);
                //hash的长度如果超过k，那么删除最先添加进来的元素
                if (numSet.Count > k)
                    numSet.RemoveAt(nums[i - k]);
            }
            return false;
        }
    }
}
