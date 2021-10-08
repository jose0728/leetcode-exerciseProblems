using System;

namespace _16_最接近的三数之和
{
    class Program
    {
        /// <summary>
        /// 给定一个包括 n 个整数的数组 nums 和 一个目标值 target。找出 nums 中的三个整数，使得它们的和与 target 最接近。返回这三个数的和。假定每组输入只存在唯一答案。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] nums = { -1, 2, 1, -4 };
            int target = 1;
            int res = ThreeSumClosest(nums, target);
        }

        public static int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);// -4 -1 1 2
            int ans = nums[0] + nums[1] + nums[2];

            //每一次的nums[i]都要和两个指针处的值求和
            for (int i = 0; i < nums.Length; i++)
            {
                int start = i + 1;
                int end = nums.Length - 1;
                while (start < end)
                {
                    int sum = nums[start] + nums[end] + nums[i];
                    if (Math.Abs(target - sum) < Math.Abs(target - ans))
                    {
                        ans = sum;
                    }
                    if (sum > target)
                    {
                        end--;
                    }
                    else if (sum < target)
                    {
                        start++;
                    }
                    else
                    {
                        return ans;
                    }
                }
            }
            return ans;
        }
    }
}
