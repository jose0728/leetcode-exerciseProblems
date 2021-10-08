using System;
using System.Collections.Generic;

namespace _41_缺失的第一个正数
{
    class Program
    {
        static void Main(string[] args)
        {
           var a = FirstMissingPositive2(new int[] { 3, 4, -1, 1 });
        }

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
        /// 置换
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FirstMissingPositive2(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n; ++i)
            {
                while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i])
                {
                    int temp = nums[nums[i] - 1];
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = temp;
                }
            }
            for (int i = 0; i < n; ++i)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }
            return n + 1;
        }

        public int firstMissingPositive3(int[] nums)
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
                if (num <= n)
                {
                    nums[num - 1] = -Math.Abs(nums[num - 1]);
                }
            }
            for (int i = 0; i < n; ++i)
            {
                if (nums[i] > 0)
                {
                    return i + 1;
                }
            }
            return n + 1;
        }

    }
}
