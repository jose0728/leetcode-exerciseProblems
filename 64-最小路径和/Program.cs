using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _64_最小路径和
{
    class Program
    {
        /// <summary>
        /// /给定一个包含非负整数的 m x n 网格 grid ，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
        /// s说明：每次只能向下或者向右移动一步。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[][] ab2 = new int[][] { new int[3] { 1, 2, 3 }, new int[3] { 4, 5, 6 } };
            int b = MinPathSum(ab2);
        }

        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int MinPathSum(int[][] grid)
        {
            if (grid == null || grid.Count() == 0)
            {
                return 0;
            }

            int[,] dp = new int[grid.Length, grid[0].Length];
            dp[0, 0] = grid[0][0];
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (i == 0 && j == 0) continue;
                    else if (i == 0) dp[i, j] = dp[i, j - 1] + grid[i][j];
                    else if (j == 0) dp[i, j] = dp[i - 1, j] + grid[i][j];
                    else dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
                }
            }
            return dp[grid.Length - 1, grid[0].Length - 1];
        }
    }
}
