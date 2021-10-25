using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _650_只有两个键的键盘
{
    class Program
    {
        /// <summary>
        /// 最初记事本上只有一个字符 'A' 。你每次可以对这个记事本进行两种操作：
        /// Copy All（复制全部）：复制这个记事本中的所有字符（不允许仅复制部分字符）。
        /// Paste（粘贴）：粘贴 上一次 复制的字符。
        /// 给你一个数字 n ，你需要使用最少的操作次数，在记事本上输出 恰好 n 个 'A' 。返回能够打印出 n 个 'A' 的最少操作次数。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int a = 50;
            var b = MinSteps2(a);
        }

        /// <summary>
        /// 只有两个键的键盘（leetcode650题）
        /// 数学法
        /// 先模拟
        /// 1 不需要操作
        /// 2 需要复制一次、粘贴一次，共2次
        /// 3 需要复制一次、粘贴二次，共3次
        /// 4 需要复制一次、粘贴三次，共4次 或 复制一次、粘贴一次、再复制一次、再粘贴一次，共4次
        /// 因此得出结论
        /// 1、质数需要分解的次数为其本身。
        /// 2、合数需要分解的次数为：将其分解到所有不能再分解的质数的操作次数的和。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int MinSteps(int n)
        {
            int ans = 0;
            int d = 2;
            while (n > 1)
            {
                while (n % d == 0)
                {
                    ans += d;
                    n /= d;
                }
                d++;
            }
            return ans;
        }

        /// <summary>
        /// 动态规划
        /// 题意分析： 题目的意思是说，初始情况下只有一个A的情况下，如何能够得到n个A，其中能用的操作只有复制和粘贴，并且粘贴只能粘贴最近一次copy的内容。
        /// 动态规划： 首先，我们可以先尝试一些较小的数，体会一下其中的规律，我尝试了一下11以内，然后首先发现：
        /// 所有的素数的操作次数都是自身的n，
        /// 然后比如8，我们只需要在有4个A的时候，复制一下再粘贴，那么就能得到8个A，为了方便我们的描述，我们设dp[i] 表示得到i个A所需要的操作次数，那么dp[8] = dp[4] + 2，8是偶数，
        /// 我们再看9，我们在得到3个A的时候，复制一次，再粘贴两次就得到了9个A，即 dp[9] = dp[3] + 3，
        /// 从这里，我们其实就可以窥出一些端倪了，首先得到 i 个A和得到j个A有关，(j<i)，也就是说具有最优子结构，因此使用动态规划。
        /// 但是j的选取我们并不知道，但是必须满足能整除i，即 i%j=0 。在这个的前提下，取选择最小的一个，因此算法如下：
        /// dp[i]表示得到i个A需要的最小的操作次数，状态转移方程：
        /// dp[i] = min(dp[i], dp[j] + i/j)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int MinSteps2(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 0;

            for (int i = 2; i <= n; i++)
            {
                dp[i] = i;
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        dp[i] = Math.Min(dp[i], dp[j] + i / j);
                    }
                }
            }
            return dp[n];
        }
    }
}
