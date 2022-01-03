using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP算法
{
    /// <summary>
    /// KMP算法求解什么类型问题
    /// 字符串匹配。给你两个字符串，寻找其中一个字符串是否包含另一个字符串，如果包含，返回包含的起始位置。
    /// 如下面两个字符串：
    /// "bacbababadababacambabacaddababacasdsd";
    /// "ababaca";
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string s = "aabaabaaf";
            string t = "aabaaf";
            int a = MatchStr(s, t);
        }

        public static int MatchStr(string s, string t)
        {
            char[] s_arr = s.ToCharArray();
            char[] t_arr = t.ToCharArray();
            int[] next = GetNextArray(t_arr);
            int i = 0;
            int j = 0;
            while (i < s_arr.Length && j < t_arr.Length)
            {
                if (j == -1 || s_arr[i] == t_arr[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = next[j];
                }
            }
            if (j == t_arr.Length)
                return i - j;
            else
                return -1;
        }

        /// <summary>
        /// 获取next数组
        /// next数组的作用就是，当前位置主串的字符与模式串当前的字符不匹配了，下一步要拿模式串哪个位置的字符与主串进行匹配
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int[] GetNextArray(char[] t)
        {
            int[] next = new int[t.Length];
            next[0] = -1;
            next[1] = 0;
            int k = 0;
            for (int j = 2; j < t.Length; j++)
            {
                k = next[j - 1];
                while (k != -1)
                {
                    if (t[j - 1] == t[k])
                    {
                        next[j] = k + 1;
                        break;
                    }
                    else
                    {
                        k = next[k];
                    }
                    next[j] = 0;
                }
            }
            return next;
        }
    }
}
