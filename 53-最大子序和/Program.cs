using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _53_最大子序和
{
    class Program
    {
        /// <summary>
        /// 给定一个整数数组 nums ，找到一个具有最大和的连续子数组（子数组最少包含一个元素），返回其最大和。
        /// 示例 1：
        /// 输入：nums = [-2,1,-3,4,-1,2,1,-5,4]
        /// 输出：6
        /// 解释：连续子数组[4, -1, 2, 1] 的和最大，为 6 。
        /// 示例 2：
        /// 输入：nums = [1]
        /// 输出：1
        /// 示例 3：
        /// 输入：nums = [0]
        /// 输出：0
        /// 示例 4：
        /// 输入：nums = [-1]
        /// 输出：-1
        /// 示例 5：
        /// 输入：nums = [-100000]
        /// 输出：-100000
        /// 提示：
        /// 1 <= nums.length <= 105
        /// -104 <= nums[i] <= 104
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int res = MaxSubArray1(nums);

        }

        /// <summary>
        /// 暴力
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MaxSubArray1(int[] nums)
        {
            int res = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                int sum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    sum += nums[j];
                    res = Math.Max(res, sum);
                }
            }
            return res;
        }

        /// <summary>
        /// 动态规划
        /// 关键：理解题意，找到一个具有最大和的连续子数组，“连续”、“子数组”而不是“子序列”
        /// dp[i]代表：当前下标是i时的最大连续子数组和
        /// nums[i]一定会被选取
        /// 如果数组的值全部大于0，那么dp[i] = dp[i-1]+nums[i]
        /// 如果数组包含负数，那么dp[i-1]有可能小于0
        /// dp[i-1]>0时，dp[i] = dp[i-1]+nums[i]
        /// dp[i-1]<0时，dp[i]=nums[i]
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray2(int[] nums)
        {
            int[] dp = new int[nums.Length + 1];
            dp[0] = nums[0];

            int max = nums[0];
            for (int i = 1; i < nums.Length; ++i)
            {
                dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i]);
                max = Math.Max(dp[i], max);
            }
            return max;
        }

    }
}
