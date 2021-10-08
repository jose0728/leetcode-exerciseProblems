using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _796_旋转字符串
{
    class Program
    {
        /// <summary>
        /// 给定两个字符串, A 和 B。
        /// A 的旋转操作就是将 A 最左边的字符移动到最右边。 例如, 若 A = 'abcde'，在移动一次之后结果就是'bcdea' 。
        /// 如果在若干次旋转操作之后，A 能变成B，那么返回True。
        /// A = 'abcde', B = 'cdeab'
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string a = "aa";
            string b = "a";
            var c = RotateString2(a, b);

        }

        /// <summary>
        /// 方法1
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool RotateString(String A, String B)
        {
            if (A.Length != B.Length) return false;
            return (A + A).Contains(B);
        }

        /// <summary>
        /// 方法2：KMP
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool RotateString2(String A, String B)
        {
            if (A == "" && B == "")
                return true;
            var c = MatchStr(A + A, B);
            if (c != -1)
                return true;
            return false;
        }

        public static int MatchStr(string s, string t)
        {
            if (t.Length + t.Length != s.Length)
                return -1;
            char[] s_arr = s.ToCharArray();
            char[] t_arr = t.ToCharArray();
            if (t.Length == 0)
            {
                return -1;
            }
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
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int[] GetNextArray(char[] t)
        {
            int[] next = new int[t.Length];
            next[0] = -1;
            if (t.Length == 1)
                return next;
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
