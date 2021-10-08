using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_三数之和
{
    class Program
    {
        /// <summary>
        /// 给你一个包含 n 个整数的数组 nums，判断 nums 中是否存在三个元素 a，b，c ，使得 a + b + c = 0 ？请你找出所有和为 0 且不重复的三元组。
        /// 注意：答案中不可以包含重复的三元组。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] a = new int[] { -1, 0, 1, 2, -1, -4 };
            List<List<int>> b = ThreeSum(a);
        }

        public static List<List<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            List<List<int>> list = new List<List<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                int target = 0 - nums[i];
                int l = i + 1;
                int r = nums.Length - 1;
                if (nums[i] > 0) break;
                if (i == 0 || nums[i] != nums[i - 1])
                {
                    while (l < r)
                    {
                        if (nums[l] + nums[r] == target)
                        {
                            List<int> curr = new List<int>();
                            curr.Add(nums[i]);
                            curr.Add(nums[l]);
                            curr.Add(nums[r]);
                            list.Add(curr);
                            while (l < r && nums[l] == nums[l + 1]) l++;
                            while (l < r && nums[r] == nums[r - 1]) r--;
                            l++;
                            r--;
                        }
                        else if (nums[l] + nums[r] < target)
                        {
                            l++;
                        }
                        else
                        {
                            r--;
                        }
                    }
                }
            }
            return list;
        }
    }
}
