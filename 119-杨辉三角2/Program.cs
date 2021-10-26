using System;
using System.Collections.Generic;

namespace _119_杨辉三角2
{
    class Program
    {
        /// <summary>
        /// 给定一个非负索引 rowIndex，返回「杨辉三角」的第 rowIndex 行。
        /// 在「杨辉三角」中，每个数是它左上方和右上方的数的和
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            GetRow2(3);
        }

        /// <summary>
        /// 先理解题意
        /// 再模拟找规律
        /// 只与上一行有关，找一个list存储上一行
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
