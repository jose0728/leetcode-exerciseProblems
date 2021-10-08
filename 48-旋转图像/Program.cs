using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _48_旋转图像
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] a = new int[4][];
            a[0] = new int[] { 1, 2, 3, 4 };
            a[1] = new int[] { 5, 6, 7, 8 };
            a[2] = new int[] { 9, 10, 11, 12 };
            a[3] = new int[] { 13, 14, 15, 16 };
            var b = Rotate(a);
        }

        /// <summary>
        /// 考察边界问题
        /// 一层层的从外到内旋转每一圈，每一圈交换这四个顶点的值
        /// 每一圈的交换次数由s < y控制
        /// 此方法的思路要基于4*4的矩阵才能推断出来，3*3推断不出来
        /// </summary>
        /// <param name="matrix"></param>
        public static int[][] Rotate(int[][] matrix)
        {
            int temp;
            for (int x = 0, y = matrix[0].Length - 1; x < y; x++, y--)
            {
                for (int s = x, e = y; s < y; s++, e--)
                {
                    temp = matrix[x][s];
                    matrix[x][s] = matrix[e][x];
                    matrix[e][x] = matrix[y][e];
                    matrix[y][e] = matrix[s][y];
                    matrix[s][y] = temp;
                };
            }
            return matrix;
        }

        /// <summary>
        /// 先上下翻转，再沿对角线翻转
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static int[][] Rotate2(int[][] matrix)
        {
            int n = matrix.Length;
            //上下翻转
            for (int i = 0; i < n / 2; i++)
            {
                int[] tmp = matrix[i];
                matrix[i] = matrix[n - i - 1];
                matrix[n - i - 1] = tmp;
            }
            //对角线翻转
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int tmp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = tmp;
                }
            }
            return matrix;
        }
    }
}
