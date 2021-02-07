using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMP算法
{
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
