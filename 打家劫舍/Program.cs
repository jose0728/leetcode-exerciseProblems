using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _198_打家劫舍
{
    class Program
    {
        /// <summary>
        /// 你是一个专业的小偷，计划偷窃沿街的房屋。每间房内都藏有一定的现金，影响你偷窃的唯一制约因素就是相邻的房屋装有相互连通的防盗系统，
        /// 如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警。
        /// 给定一个代表每个房屋存放金额的非负整数数组，计算你不触动警报装置的情况下 ，一夜之内能够偷窃到的最高金额。
        /// 示例 1：
        /// 输入：[1,2,3,1]
        /// 输出：4
        /// 解释：偷窃 1 号房屋(金额 = 1) ，然后偷窃 3 号房屋(金额 = 3)。
        /// 偷窃到的最高金额 = 1 + 3 = 4 。
        /// 示例 2：
        /// 输入：[2,7,9,3,1]
        /// 输出：12
        /// 解释：偷窃 1 号房屋(金额 = 2), 偷窃 3 号房屋(金额 = 9)，接着偷窃 5 号房屋(金额 = 1)。
        /// 偷窃到的最高金额 = 2 + 9 + 1 = 12 。
        /// 提示：
        /// 1 <= nums.length <= 100
        /// 0 <= nums[i] <= 400
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 1 };
            int b = Rob2(a);
        }

        /// <summary>
        /// 动态规划法一
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Rob(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            if (nums.Length == 1)
            {
                return nums[0];
            }
            //dp[i]代表小偷到第i家偷到的最大钱
            int[] dp = new int[nums.Length + 1];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[1], dp[0]);
            int res = dp[1];
            for (int i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
                res = Math.Max(res, dp[i]);
            }

            return res;
        }

        /// <summary>
        /// 动态规划法二
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int Rob2(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            if (nums.Length == 1)
            {
                return nums[0];
            }
            //dp[i][0]代表小偷不偷第i家最多能偷多少钱
            //dp[i][1]代表小偷偷第i家最多能偷多少钱
            int[,] dp = new int[nums.Length, 2];
            dp[0, 0] = 0;
            dp[0, 1] = nums[0];
            int result = dp[0, 1];
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
                dp[i, 1] = dp[i - 1, 0] + nums[i];
                result = Math.Max(dp[i, 0], dp[i, 1]);
            }

            return result;
        }
    }
}
