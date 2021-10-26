using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _343_整数拆分
{
    class Program
    {
        /// <summary>
        /// 给定一个正整数 n，将其拆分为至少两个正整数的和，并使这些整数的乘积最大化。 返回你可以获得的最大乘积。
        /// 示例 1:
        /// 输入: 2
        /// 输出: 1
        /// 解释: 2 = 1 + 1, 1 × 1 = 1。
        /// 示例 2:
        /// 输入: 10
        /// 输出: 36
        /// 解释: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36。
        /// 说明: 你可以假设 n 不小于 2 且不大于 58。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var a = IntegerBreak(10);
        }

        /// <summary>
        /// 整数拆分
        /// 动态规划
        /// 将 i 拆分成 j 和 i-j 的和，且 i-j 不再拆分成多个正整数，此时的乘积是 j×(i−j)
        /// 将 i 拆分成 j 和 i-j 的和，且 i-j 继续拆分成多个正整数，此时的乘积是 j×dp[i−j]
        /// 状态：设dp[i]为将i拆分为若干个整数时，这些整数的最大乘积
        /// 初始状态：dp[0] = dp[1] = 0
        /// 状态转移方程：dp[i] = Math.Max(j*(i-j),j*dp[i-j])
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int IntegerBreak(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = dp[1] = 0;
            for (int i = 2; i <= n; i++)
            {
                int curMax = 0;
                for (int j = 1; j < i; j++)
                {
                    curMax = Math.Max(curMax, Math.Max(j * (i - j), j * dp[i - j]));
                }
                dp[i] = curMax;
            }
            return dp[n];
        }
    }
}
