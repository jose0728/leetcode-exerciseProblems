using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 不同路径
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            var a = program.uniquePaths(7, 3);
            int[][] obstacleGrid = new int[3][];
            obstacleGrid[0] = new int[] { 0, 0, 0 };
            obstacleGrid[1] = new int[] { 0, 1, 0 };
            obstacleGrid[2] = new int[] { 0, 0, 0 };
            var b = program.uniquePathsWithObstacles(obstacleGrid);
        }

        /// <summary>
        /// 62. 不同路径（leetcode62题）
        /// 动态规划
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int uniquePaths(int m, int n)
        {
            int[,] dp = new int[m, n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    dp[i, j] = 1;
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
            return dp[m - 1, n - 1];
        }

        /// <summary>
        /// 63. 不同路径（leetcode63题）
        /// 动态规划
        /// </summary>
        /// <param name="obstacleGrid"></param>
        /// <returns></returns>
        public int uniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;
            int[,] dp = new int[m, n];
            if (obstacleGrid[0][0] != 1)
            {
                dp[0, 0] = 1;
            }
            for (int j = 1; j < n; j++)
            {
                dp[0, j] = obstacleGrid[0][j] == 1 ? 0 : dp[0, j - 1];
            }
            for (int i = 1; i < m; i++)
            {
                dp[i, 0] = obstacleGrid[i][0] == 1 ? 0 : dp[i - 1, 0];
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i, j] = obstacleGrid[i][j] == 1 ? 0 : dp[i - 1, j] + dp[i, j - 1];
                }
            }
            return dp[m - 1, n - 1];
        }

    }
}
