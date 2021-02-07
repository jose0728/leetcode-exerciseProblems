using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _343_整数拆分
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = IntegerBreak(10);
        }

        /// <summary>
        /// 整数拆分
        /// 动态规划
        /// </summary>
        /// 将 i 拆分成 j 和 i-j 的和，且 i-j 不再拆分成多个正整数，此时的乘积是 j×(i−j)
        /// 将 i 拆分成 j 和 i-j 的和，且 i-j 继续拆分成多个正整数，此时的乘积是 j×dp[i−j]
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
