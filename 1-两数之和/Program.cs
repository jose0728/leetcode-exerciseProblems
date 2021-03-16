using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_两数之和
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 2, 13, 11, 7 };
            int[] b = TwoNums(a, 9);
        }

        /// <summary>
        /// 双指针法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] TwoNums(int[] nums, int target)
        {
            int[] numsbak = new int[nums.Length];
            Array.Copy(nums, numsbak, nums.Length);
            Array.Sort(nums);
            int a = -1, b = -1;
            for (int i = 0, j = nums.Length - 1; i < nums.Length - 1 && j > i;)
            {
                if (nums[i] + nums[j] > target)
                {
                    j--;
                }
                else if (nums[i] + nums[j] < target)
                {
                    i++;
                }
                else
                {
                    a = nums[i];
                    b = nums[j];
                    break;
                }
            }

            int x = -1, y = -1;
            for (int i = 0; i < numsbak.Length; i++)
            {
                if (numsbak[i] == a && x == -1)
                {
                    x = i;
                    continue;
                }

                if (numsbak[i] == b && y == -1)
                {
                    y = i;
                }

                if (x > -1 && y > -1)
                {
                    break;
                }
            }

            return new int[] { x, y };
        }

        /// <summary>
        /// Hashmap(java)-->c# Dictionary
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] Method2(int[] nums, int target)
        {
            Dictionary<int, int> hashtable = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; ++i)
            {
                if (hashtable.ContainsKey(target - nums[i]))
                {
                    int a = 0;
                    hashtable.TryGetValue(target - nums[i], out a);
                    return new int[] { a, i };
                }
                hashtable.Add(nums[i], i);
            }
            return new int[0];
        }

        /// <summary>
        /// 暴力解法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] Method3(int[] nums, int target)
        {
            int[] result = new int[2];
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[0] = i;
                        result[1] = j;
                        return result;
                    }
                }
            }
            return null;
        }
    }
}
