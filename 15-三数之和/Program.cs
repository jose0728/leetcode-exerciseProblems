using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_三数之和
{
    class Program
    {
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
