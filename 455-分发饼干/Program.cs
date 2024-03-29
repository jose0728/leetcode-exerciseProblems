﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _455_分发饼干
{
    class Program
    {
        /// <summary>
        /// 假设你是一位很棒的家长，想要给你的孩子们一些小饼干。但是，每个孩子最多只能给一块饼干。
        /// 对每个孩子 i，都有一个胃口值 g[i]，这是能让孩子们满足胃口的饼干的最小尺寸；并且每块饼干 j，都有一个尺寸 s[j] 。
        /// 如果 s[j] >= g[i]，我们可以将这个饼干 j 分配给孩子 i ，这个孩子会得到满足。你的目标是尽可能满足越多数量的孩子，并输出这个最大数值。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] g = { 1, 2, 3 };
            int[] s = { 1, 1 };
            int a = FindContentChildren2(g,s);
        }

        /// <summary>
        /// 贪心算法
        /// 如果最小的饼干可以满足肚子最小的孩子，那就给他吃，同时比较下一个
        /// 如果最小的饼干不能满足肚子最小的孩子，那就扔掉饼干，看看下一个饼干能不能给他吃。（放弃的是饼干）
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int FindContentChildren(int[] g, int[] s)
        {
            if (g == null || s == null)
                return 0;
            Array.Sort(g);
            Array.Sort(s);

            int gi = 0;
            int si = 0;
            while (gi < g.Length && si < s.Length)
            {
                if (g[gi] <= s[si])
                {
                    gi++;
                }
                si++;
            }
            return gi;
        }

        /// <summary>
        /// 贪心算法2
        /// 如果最大的饼干可以满足肚子最大的孩子，那就给他吃，同时比较下一个。
        /// 如果最大的饼干不可以满足肚子最大的孩子，那就让他饿着，然后看看能不能满足第二个孩子（放弃的是孩子）。
        /// 通俗点：有多少饼干被吃了
        /// </summary>
        /// <param name="g"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int FindContentChildren2(int[] g, int[] s)
        {
            if (g == null || s == null)
                return 0;
            Array.Sort(g);
            Array.Reverse(g);
            Array.Sort(s);
            Array.Reverse(s);

            int gi = 0;
            int si = 0;
            while (gi < g.Length && si < s.Length)
            {
                if (g[gi] <= s[si])
                {
                    si++;
                }
                gi++;
            }
            return si;
        }
    }
}
