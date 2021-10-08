using System;

namespace _242_有效的字母异位词
{
    class Program
    {
        /// <summary>
        /// 给定两个字符串 s 和 t ，编写一个函数来判断 t 是否是 s 的字母异位词。
        /// 注意：若 s 和 t 中每个字符出现的次数都相同，则称 s 和 t 互为字母异位词。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string s = "anagram";
            string t = "nagaram";
            var res = IsAnagram(s, t);
        }

        /// <summary>
        /// 哈希
        /// 先添加进去，再减，正好等于0，若某个位置小于零了，那么不是有效的字母异位词
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            int[] arr = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i] - 'a']++;
            }

            for (int i = 0; i < t.Length; i++)
            {
                arr[t[i] - 'a']--;
                if (arr[t[i] - 'a'] < 0)
                    return false;
            }
            return true;
        }

    }
}
