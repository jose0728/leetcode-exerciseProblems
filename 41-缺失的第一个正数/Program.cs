using System;
using System.Collections.Generic;

namespace _41_缺失的第一个正数
{
    class Program
    {
        /// <summary>
        /// 给你一个未排序的整数数组 nums ，请你找出其中没有出现的最小的正整数。
        /// 请你实现时间复杂度为 O(n) 并且只使用常数级别额外空间的解决方案。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var a = firstMissingPositive2(new int[] { 3, 4, -1, 1, 7 });
        }

        /// <summary>
        /// 直接解法+排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FirstMissingPositive(int[] nums)
        {
            int res = 1;
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                {
                    if (nums[i] == res)
                        res++;
                    else if (nums[i] > res)
                        break;
                }

            }
            return res;
        }

        /// <summary>
        /// 哈希
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FirstMissingPositive1(int[] nums)
        {
            Dictionary<int, int> dics = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!dics.ContainsKey(nums[i]))
                    dics.Add(nums[i], i);
            }

            for (int i = 1; i <= nums.Length + 1; i++)
            {
                if (!dics.ContainsKey(i))
                    return i;
            }
            return nums.Length + 1;
        }

        /// <summary>
        /// 原地哈希
        /// 首先通过数学分析明确，缺失的正数和数组长度n的关系
        /// 两种可能：
        /// 1、缺失的正数落 在[1，n]中间，意味着，数组中必然有不在[1，n] 的数字或在[1，n]范围内的重复数字。
        /// 2、缺失的正数大小超出了n，说明数组必然包括[1，n] 区间的所有数字，无其他数字。
        /// 基于以上逻辑分析，可以原地修改数组，将原本数组中不在[1，n] 的数字修改为n+1，以排除负数和0的影响。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int firstMissingPositive2(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n; ++i)
            {
                if (nums[i] <= 0)
                {
                    nums[i] = n + 1;
                }
            }
            for (int i = 0; i < n; ++i)
            {
                int num = Math.Abs(nums[i]);
                //遍历当前数组，如果当前值的绝对值处于[1,n]中,说明之前没有遇到这个正数，将其置为负数，标识这个正数没有缺失  
                if (num <= n)
                {
                    nums[num - 1] = -Math.Abs(nums[num - 1]);
                }
            }
            //经过遍历，所有[1,n]的正数对应的数组位置的值都为负数
            for (int i = 0; i < n; ++i)
            {
                //遍历数组，如果发现有位置大于0，说明数组之前没有这个值，输出该值
                if (nums[i] > 0)
                {
                    return i + 1;
                }
            }
            //如果数组都为负数，那缺失的值为数组长度+1
            return n + 1;
        }

    }
}
