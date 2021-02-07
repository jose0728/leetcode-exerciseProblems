using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _300_最大上升子序列
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 10, 9, 2, 5, 3, 7, 101, 18};
            int b = LengthOfLIS(a);
        }

        /// <summary>
        /// 动态规划
        /// 状态定义：dp[i]的值代表 nums 前 i 个数字的最长子序列长度
        /// 转移方程： dp[i] = max(dp[i], dp[j] + 1) for j in [0, i)。
        /// 初始状态：
        /// dp[i] dp[i] 所有元素置 11，含义是每个元素都至少可以单独成为子序列，此时长度都为 11。
        /// 返回值：返回 dpdp 列表最大值，即可得到全局最长上升子序列长度。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int[] dp = new int[nums.Length];
            dp[0] = 1;
            int max = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
                max = Math.Max(max, dp[i]);
            }
            return max;
        }
    }
}
