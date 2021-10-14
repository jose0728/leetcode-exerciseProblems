using System;
using System.Collections.Generic;

namespace _118_杨辉三角
{
    class Program
    {
        /// <summary>
        /// 给定一个非负整数 numRows，生成「杨辉三角」的前 numRows 行。
        /// 在「杨辉三角」中，每个数是它左上方和右上方的数的和。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Generate(5);
        }
        
        /// <summary>
        /// 先理解题意
        /// 画出三角形
        /// 三角形变形
        /// 找规律
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> res = new List<IList<int>>();
            for (int i = 0; i < numRows; i++)
            {
                IList<int> row = new List<int>();
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0 || j == i)
                    {
                        row.Add(1);
                    }
                    else {
                        row.Add(res[i - 1][j - 1] + res[i - 1][j]);
                    }
                }
                res.Add(row);
            }
            return res;
        }
    }
}
