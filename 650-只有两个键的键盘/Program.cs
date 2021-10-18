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
            int a = 3;
            var b = MinSteps(a);
        }

        /// <summary>
        /// 只有两个键的键盘（leetcode650题）
        /// 1、质数次数为其本身。
        /// 2、合数次数为将其分解到所有不能再分解的质数的操作次数的和。
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
    }
}
