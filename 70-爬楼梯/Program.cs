using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _70_爬楼梯
{
    class Program
    {
        /// <summary>
        /// 假设你正在爬楼梯。需要 n 阶你才能到达楼顶。
        /// 每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？
        /// 注意：给定 n 是一个正整数。
        /// 示例 1：
        /// 输入： 2
        /// 输出： 2
        /// 解释： 有两种方法可以爬到楼顶。
        /// 1.  1 阶 + 1 阶
        /// 2.  2 阶
        /// 示例 2：
        /// 输入： 3
        /// 输出： 3
        /// 解释： 有三种方法可以爬到楼顶。
        /// 1.  1 阶 + 1 阶 + 1 阶
        /// 2.  1 阶 + 2 阶
        /// 3.  2 阶 + 1 阶
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

        }

        /// <summary>
        /// 动态规划1
        /// dp[i]表示能到达第i阶的方法总数
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
