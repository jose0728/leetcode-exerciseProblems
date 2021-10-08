using System;
using System.Collections.Generic;

namespace _169_多数元素
{
    class Program
    {
        /// <summary>
        /// 给定一个大小为 n 的数组，找到其中的多数元素。多数元素是指在数组中出现次数 大于n/2的元素。
        /// 你可以假设数组是非空的，并且给定的数组总是存在多数元素。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static int MajorityElement(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }

        public static int MajorityElement2(int[] nums)
        {
            Dictionary<int, int> numsDic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (numsDic.ContainsKey(nums[i]))
                {
                    numsDic[nums[i]] = numsDic[nums[i]] + 1;
                }
                else
                {
                    numsDic.Add(nums[i], 1);
                }
                if (numsDic[nums[i]] > nums.Length / 2)
                    return nums[i];
            }
            return 0;
        }
    }
}
