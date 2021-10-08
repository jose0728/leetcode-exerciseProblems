using System;
using System.Collections.Generic;

namespace _119_杨辉三角2
{
    class Program
    {
        static void Main(string[] args)
        {
            GetRow2(3);
        }

        /// <summary>
        /// 只与上一行有关
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static IList<int> GetRow(int rowIndex)
        {
            IList<int> pre = new List<int>();
            for (int i = 0; i <= rowIndex; i++)
            {
                IList<int> cur = new List<int>();
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        cur.Add(1);
                    }
                    else
                    {
                        cur.Add(pre[j - 1] + pre[j]);
                    }
                }
                pre = cur;
            }
            return pre;
        }

        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static IList<int> GetRow2(int rowIndex)
        {
            IList<int> res = new List<int>();
            int[,] dp = new int[rowIndex + 1, rowIndex + 1];

            dp[0, 0] = 1;

            for (int i = 1; i <= rowIndex; i++)
            {
                dp[i, 0] = dp[i, i] = 1;
                for (int j = 1; j < i; j++)
                {
                    dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
                }
            }

            for (var j = 0; j <= rowIndex; j++)
            {
                res.Add(dp[rowIndex, j]);
            }

            return res;
        }
    }
}
