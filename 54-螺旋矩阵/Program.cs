using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _54_螺旋矩阵
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] a = new int[3][];
            a[0] = new int[] { 0, 1, 2, 3 };
            a[1] = new int[] { 4, 5, 6, 7 };
            a[2] = new int[] { 8, 9, 10, 11 };
            var b = SpiralOrder(a);
        }

        private static IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> result = new List<int>();
            if (matrix == null || matrix.Length == 0) return result;
            int left = 0;
            int right = matrix[0].Length - 1;
            int top = 0;
            int bottom = matrix.Length - 1;
            int numEle = matrix.Length * matrix[0].Length;
            while (numEle >= 1)
            {
                for (int i = left; i <= right && numEle >= 1; i++)
                {
                    result.Add(matrix[top][i]);
                    numEle--;
                }
                top++;
                for (int i = top; i <= bottom && numEle >= 1; i++)
                {
                    result.Add(matrix[i][right]);
                    numEle--;
                }
                right--;
                for (int i = right; i >= left && numEle >= 1; i--)
                {
                    result.Add(matrix[bottom][i]);
                    numEle--;
                }
                bottom--;
                for (int i = bottom; i >= top && numEle >= 1; i--)
                {
                    result.Add(matrix[i][left]);
                    numEle--;
                }
                left++;
            }
            return result;
        }
    }
}
