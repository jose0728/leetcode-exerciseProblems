using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 买卖股票的最佳时机
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 7, 5, 3, 6, 4 };
            int b = MaxProfit1(a);
        }

        /*
        思路：题目只问最大利润，没有问这几天具体哪一天买、哪一天卖，因此可以考虑使用 动态规划 的方法来解决。
        买卖股票有约束，根据题目意思，有以下两个约束条件：

        条件 1：你不能在买入股票前卖出股票；
        条件 2：最多只允许完成一笔交易。
        因此 当天是否持股 是一个很重要的因素，而当前是否持股和昨天是否持股有关系，为此我们需要把 是否持股 设计到状态数组中。

        状态定义：

        dp[i][j]：下标为 i 这一天结束的时候，手上持股状态为 j 时，我们持有的现金数。

        j = 0，表示当前不持股；
        j = 1，表示当前持股。
        注意：这个状态具有前缀性质，下标为 i 的这一天的计算结果包含了区间 [0, i] 所有的信息，因此最后输出 dp[len - 1][0]。

        说明：

        使用「现金数」这个说法主要是为了体现 买入股票手上的现金数减少，卖出股票手上的现金数增加 这个事实；
        「现金数」等价于题目中说的「利润」，即先买入这只股票，后买入这只股票的差价；
        因此在刚开始的时候，我们的手上肯定是有一定现金数能够买入这只股票，即刚开始的时候现金数肯定不为 00，但是写代码的时候可以设置为 0。极端情况下（股价数组为 [5, 4, 3, 2, 1]），此时不发生交易是最好的（这一点是补充说明，限于我的表达，希望不要给大家造成迷惑）。
        推导状态转移方程：

        dp[i][0]：规定了今天不持股，有以下两种情况：
        昨天不持股，今天什么都不做；
        昨天持股，今天卖出股票（现金数增加），

        dp[i][1]：规定了今天持股，有以下两种情况：
        昨天持股，今天什么都不做（现金数增加）；
        昨天不持股，今天买入股票（注意：只允许交易一次，因此手上的现金数就是当天的股价的相反数）。
        状态转移方程请见 参考代码 2。

        知识点：

        多阶段决策问题：动态规划常常用于求解多阶段决策问题；
        无后效性：每一天是否持股设计成状态变量的一维。状态设置具体，推导状态转移方程方便。
         */

        /// <summary>
        /// 动态规划例题1
        /// 给定一个数组，它的第 i 个元素是一支给定股票第 i 天的价格。
        /// 如果你最多只允许完成一笔交易（即买入和卖出一支股票一次），设计一个算法来计算你所能获取的最大利润。
        /// 注意：你不能在买入股票前卖出股票
        /// </summary>
        /// <returns></returns>
        public static int MaxProfit1(int[] prices)
        {
            int len = prices.Length;
            // 特殊判断
            if (len < 2)
            {
                return 0;
            }
            int[,] dp = new int[len, 2];

            // 初始化：不持股显然为 0，持股就需要减去第 1 天（下标为 0）的股价
            dp[0, 0] = 0;
            dp[0, 1] = -prices[0];

            // 从第 2 天开始遍历
            for (int i = 1; i < len; i++)
            {
                // dp[i][0] 下标为 i 这天结束的时候，不持股，手上拥有的现金数
                // dp[i][1] 下标为 i 这天结束的时候，持股，手上拥有的现金数
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], -prices[i]);
            }
            return dp[len - 1, 0];
        }

        /// <summary>
        /// 暴力解法
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfit2(int[] prices)
        {
            int len = prices.Length;
            if (len < 2)
            {
                return 0;
            }

            // 有可能不发生交易，因此结果集的初始值设置为 0
            int res = 0;

            // 枚举所有发生一次交易的股价差
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = i + 1; j < len; j++)
                {
                    res = Math.Max(res, prices[j] - prices[i]);
                }
            }
            return res;
        }

        /// <summary>
        /// 动态规划例题2
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfit3(int[] prices)
        {
            int len = prices.Length;
            // 特殊判断
            if (len < 2)
            {
                return 0;
            }

            // 0：持有现金
            // 1：持有股票
            // 状态转移：0 → 1 → 0 → 1 → 0 → 1 → 0
            int[,] dp = new int[len, 2];

            // dp[i][0] 下标为 i 这天结束的时候，持有现金，手上拥有的现金数
            // dp[i][1] 下标为 i 这天结束的时候，持有股票，手上拥有的现金数
            dp[0, 0] = 0;
            dp[0, 1] = -prices[0];

            // 从第 2 天开始遍历
            for (int i = 1; i < len; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] - prices[i]);
            }
            return dp[len - 1, 0];
        }
    }
}
