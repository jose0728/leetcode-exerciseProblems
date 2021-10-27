using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _120_三角形最小路径和
{
    class Program
    {
        /// <summary>
        /// 给定一个三角形 triangle ，找出自顶向下的最小路径和。
        /// 每一步只能移动到下一行中相邻的结点上。
        /// 相邻的结点 在这里指的是 下标 与 上一层结点下标 相同或者等于 上一层结点下标 + 1 的两个结点。也就是说，如果正位于当前行的下标 i ，那么下一步可以移动到下一行的下标 i 或 i + 1 。
        /// 示例 1：
        /// 输入：triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
        /// 输出：11
        /// 解释：如下面简图所示：
        /// 2
        /// 3 4
        /// 6 5 7
        /// 4 1 8 3
        /// 自顶向下的最小路径和为 11（即，2 + 3 + 5 + 1 = 11）。
        /// 示例 2：
        /// 输入：triangle = [[-10]]
        /// 输出：-10
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Random rd = new Random();
            IList<IList<int>> triangle = new List<IList<int>>();
            int num = 4;
            for (int i = 0; i < num; i++)
            {
                IList<int> subList = new List<int>();
                subList.Add(rd.Next(1, 10));
                for (int j = 0; j < i; j++)
                {
                    subList.Add(rd.Next(1, 10));
                }
                triangle.Add(subList);
            }

            int b = MinimumTotal(triangle);
        }

        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="triangle"></param>
        /// <returns></returns>
        public static int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle == null || triangle.Count() == 0)
            {
                return 0;
            }

            int row = triangle.Count();
            int column = triangle.ElementAt(row - 1).Count();
            //dp[i][j]代表包含第i行第j列元素的最小路径和
            int[,] dp = new int[row, column];

            dp[0, 0] = triangle.ElementAt(0).ElementAt(0);

            for (int i = 1; i < row; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0)
                    {
                        // 最左端特殊处理
                        dp[i, j] = dp[i - 1, j] + triangle.ElementAt(i).ElementAt(j);
                    }
                    else if (j == i)
                    {
                        // 最右端特殊处理
                        dp[i, j] = dp[i - 1, j - 1] + triangle.ElementAt(i).ElementAt(j);
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j], dp[i - 1, j - 1]) + triangle.ElementAt(i).ElementAt(j);
                    }
                }
            }

            int res = int.MaxValue;
            for (int i = 0; i < column; i++)
            {
                res = Math.Min(res, dp[row - 1, i]);
            }
            return res;
        }
    }
}
