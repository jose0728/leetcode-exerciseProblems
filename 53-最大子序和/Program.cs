using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _53_最大子序和
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 暴力
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray1(int[] nums)
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
