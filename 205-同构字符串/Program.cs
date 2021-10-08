using System;
using System.Collections.Generic;

namespace _205_同构字符串
{
    class Program
    {
        /// <summary>
        /// 给定两个字符串 s 和 t，判断它们是否是同构的。
        /// 如果 s 中的字符可以按某种映射关系替换得到 t ，那么这两个字符串是同构的。
        /// 每个出现的字符都应当映射到另一个字符，同时不改变字符的顺序。
        /// 不同字符不能映射到同一个字符上，相同字符只能映射到同一个字符上，字符可以映射到自己本身。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var res = IsIsomorphic("fop", "baa");
        }

        public static bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> s2tDic = new Dictionary<char, char>();
            Dictionary<char, char> t2sDic = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                var x = s[i];
                var y = t[i];
                if (s2tDic.ContainsKey(x) && s2tDic[x] != y || t2sDic.ContainsKey(y) && t2sDic[y] != x)
                    return false;
                if (!s2tDic.ContainsKey(x))
                {
                    s2tDic.Add(x, y);
                }
                if (!t2sDic.ContainsKey(y))
                {
                    t2sDic.Add(y, x);
                }
            }
            return true;
        }
    }
}
