using System;
using System.Collections.Generic;

namespace _18_四数之和
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            IList<IList<int>> quadruplets = new List<IList<int>>();
            if (nums == null || nums.Length < 4)
            {
                return quadruplets;
            }
            Array.Sort(nums);
            int length = nums.Length;

            for (int i = 0; i < length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])//去重
                {
                    continue;
                }
                if (nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3] > target)
                {
                    break;
                }
                if (nums[i] + nums[length - 3] + nums[length - 2] + nums[length - 1] < target)
                {
                    continue;
                }
                for (int j = i + 1; j < length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1])//去重
                    {
                        continue;
                    }
                    if (nums[i] + nums[j] + nums[j + 1] + nums[j + 2] > target)
                    {
                        break;
                    }
                    if (nums[i] + nums[j] + nums[length - 2] + nums[length - 1] < target)
                    {
                        continue;
                    }
                    int left = j + 1;
                    int right = length - 1;
                    while (left < right)
                    {
                        int sum = nums[i] + nums[j] + nums[left] + nums[right];
                        if (sum == target)
                        {
                            quadruplets.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });
                            while (left < right && nums[left] == nums[left + 1])
                            {
                                left++;
                            }
                            left++;
                            while (left < right && nums[right] == nums[right - 1])
                            {
                                right--;
                            }
                            right--;
                        }
                        else if (sum < target)
                        {
                            left++;
                        }
                        else
                        {
                            right--;
                        }
                    }
                }
            }
            return quadruplets;
        }
    }
}
