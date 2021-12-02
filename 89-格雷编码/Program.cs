using System;
using System.Collections.Generic;

namespace _89_格雷编码
{
    class Program
    {
        /// <summary>
        /// 格雷编码是一个二进制数字系统，在该系统中，两个连续的数值仅有一个位数的差异。
        /// 给定一个代表编码总位数的非负整数 n，打印其格雷编码序列。即使有多个不同答案，你也只需要返回其中一种。格雷编码序列必须以 0 开头。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            GrayCode(3);
        }

        /// <summary>
        /// 镜像法
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IList<int> GrayCode(int n)
        {
            var res = new List<int> { 0 };
            if (n == 0)
            {
                return res;
            }

            for (int i = 0; i < n; i++)
            {
                double add = Math.Pow(2, i);//要加的数
                for (int j = res.Count - 1; j >= 0; j--)
                {
                    res.Add((int)add + res[j]);
                }
            }
            return res;
        }
    }
}
