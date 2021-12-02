using System;
using System.Collections.Generic;
using System.Text;

namespace _49_字母异位词分组
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
            var res = GroupAnagrams(str);
        }

        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> dics = new Dictionary<string, List<string>>();

            if (strs.Length == 0)
                return new List<IList<string>>();

            foreach (var item in strs)
            {
                var array = item.ToCharArray();
                Array.Sort(array);
                var str = new string(array);
                if (dics.ContainsKey(str))
                {
                    var list = dics[str];
                    list.Add(item);
                    dics[str] = list;
                }
                else
                {
                    dics.Add(str, new List<string> { item });
                }
            }

            return new List<IList<string>>(dics.Values);
        }

        public static IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            Dictionary<string, List<string>> dics = new Dictionary<string, List<string>>();

            if (strs.Length == 0)
                return new List<IList<string>>();

            foreach (var item in strs)
            {
                int[] counts = new int[26];
                for (int i = 0; i < item.Length; i++)
                {
                    counts[item[i] - 'a']++;
                }

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < 26; i++)
                {
                    if (counts[i] != 0)
                    {
                        stringBuilder.Append((char)('a' + i));//出现次数大于 0 的字母
                        stringBuilder.Append(counts[i]);//出现次数
                    }
                }

                string key = stringBuilder.ToString();
                if (dics.ContainsKey(key))
                {
                    var list = dics[key];
                    list.Add(item);
                    dics[key] = list;
                }
                else 
                {
                    dics.Add(key, new List<string> { item });
                }
            }

            return new List<IList<string>>(dics.Values);
        }
    }
}
