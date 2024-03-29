﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大数打印
{
    class Program
    {
        /// <summary>
        /// 剑指offer17题
        /// 输入数字 n，按顺序打印出从 1 到最大的 n 位十进制数。比如输入 3，则打印出 1、2、3 一直到最大的 3 位数 999。
        /// 示例 1:
        /// 输入: n = 1
        /// 输出: [1,2,3,4,5,6,7,8,9]
        /// 说明：
        /// 用返回一个整数列表来代替打印
        /// n 为正整数
        /// </summary>
        static void Main(string[] args)
        {
            int[] a = PrintNumbers1(3);
        }

        public static int[] PrintNumbers1(int n)
        {
            int len = (int)Math.Pow(10, n);
            int[] res = new int[len - 1];
            for (int i = 1; i < len; i++)
            {
                res[i-1] = i;
            }
            return res;
        }

        public static int[] PrintNumbers2(int n)
        {
            int l = 0;
            for (int i = 0; i < n; i++)
            {
                l = l * 10 + 9;
            }
            int[] res = new int[l];
            for (int i = 1; i <= l; i++)
            {
                res[i - 1] = i;
            }
            return res;
        }
    }
}
