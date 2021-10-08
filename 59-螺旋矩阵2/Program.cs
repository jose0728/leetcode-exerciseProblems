using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _59_螺旋矩阵2
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = GenerateMatrix2(3);
        }

        /// <summary>
        /// 考察边界问题
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int[][] GenerateMatrix(int n)
        {
            int[][] res = new int[n][];
            for (int i = 0; i < n; i++)
            {
                res[i] = new int[n];
            }

            int left = 0;
            int right = res[0].Length - 1;
            int top = 0;
            int bottom = res.Length - 1;
            int numEle = n * n;
            int m = 1;

            while (numEle >= 1)
            {
                for (int i = left; i <= right && numEle >= 1; i++)
                {
                    res[top][i] = m++;
                    numEle--;
                }
                top++;
                for (int i = top; i <= bottom && numEle >= 1; i++)
                {
                    res[i][right] = m++;
                    numEle--;
                }
                right--;
                for (int i = right; i >= left && numEle >= 1; i--)
                {
                    res[bottom][i] = m++;
                    numEle--;
                }
                bottom--;
                for (int i = bottom; i >= top && numEle >= 1; i--)
                {
                    res[i][left] = m++;
                    numEle--;
                }
                left++;
            }

            return res;
        }

        public static int[][] GenerateMatrix2(int n)
        {
            int[][] res = new int[n][];
            for (int i = 0; i < n; i++)
            {
                res[i] = new int[n];
            }

            for (int s = 0, e = n - 1, m = 1; s <= e; s++, e--)
            {
                for (int j = s; j <= e; j++) res[s][j] = m++;
                for (int i = s + 1; i <= e; i++) res[i][e] = m++;
                for (int j = e - 1; j >= s; j--) res[e][j] = m++;
                for (int i = e - 1; i >= s + 1; i--) res[i][s] = m++;
            }
            return res;
        }
    }
}
