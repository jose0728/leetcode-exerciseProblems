using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _74_搜索二维矩阵
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[] { 1, 3, 5, 7 };
            matrix[1] = new int[] { 10, 11, 16, 20 };
            matrix[2] = new int[] { 23, 30, 34, 60 };
            var c = SearchMatrix(matrix, 3);
        }

        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix.Length < 1) return false;
            int row = GetRow(matrix, target);
            return Find(matrix[row], target);
        }

        public static int GetRow(int[][] matrix, int target)
        {
            int top = 0;
            int bottom = matrix.Length - 1;
            int col = matrix[0].Length - 1;
            while (top < bottom)
            {
                int mid = (top + bottom) / 2;
                if (matrix[mid][col] < target)
                    top = mid + 1;
                else
                    bottom = mid;
            }
            return top;
        }

        public static bool Find(int[] data, int target)
        {
            int l = 0, r = data.Length - 1;
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (data[mid] == target)
                    return true;
                else if (data[mid] < target)
                    l = mid + 1;
                else
                    r = mid - 1;
            }
            return false;
        }

    }
}
