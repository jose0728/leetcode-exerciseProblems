using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _70_爬楼梯
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        /// <summary>
        /// 动态规划1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int ClimbStairs1(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }

        /// <summary>
        /// 动态规划优化
        /// dp[i]只与过去的两项有关，没必要存下所有计算过的dp项
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int ClimbStairs2(int n)
        {
            int p = 0, q = 0, r = 0;
            for (int i = 1; i <= n; i++)
            {
                p = q;
                q = r;
                r = p + q;
            }
            return r;
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int ClimbStairs3(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            if (n == 1)
            {
                return 1;
            }
            return ClimbStairs3(n - 1) + ClimbStairs3(n - 2);
        }
    }
}
