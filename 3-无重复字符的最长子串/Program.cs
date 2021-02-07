using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_无重复字符的最长子串
{
    /// <summary>
    /// 给定一个字符串，请你找出其中不含有重复字符的 最长子串的长度。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string s = "pewkew";
            int a = LengthOfLongestSubstring2(s);
        }

        /// <summary>
        /// 方法1
        /// 滑动窗口
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring(string s)
        {
            int count = 0;
            List<Object> list = new List<Object>();
            char[] array = s.ToCharArray();
            int length = s.Count();
            for (int i = 0; i < length; i++)
            {
                char c = array[i];
                while (list.IndexOf(c) >= 0)
                {
                    list.RemoveAt(0);
                }
                list.Add(c);
                count = list.Count() > count ? list.Count() : count;
            }
            return count;
        }

        /// <summary>
        /// 方法2
        /// 滑动窗口
        /// start不动，end向后移动
        /// 当end遇到重复字符，start应该放在上一个重复字符的后一位，同时记录最长长度
        /// 用哈希字典的key来判断是否重复，用value来记录该字符的下一个不重复的位置
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLongestSubstring2(string s)
        {
            int n = s.Length, ans = 0;
            List<SMap> list = new List<SMap>();
            for (int start = 0, end = 0; end < n; end++)
            {
                var tmp = list.FirstOrDefault(o => o.Value == s[end]);
                if (tmp != null)
                {
                    start = Math.Max(start, tmp.Index);
                    tmp.Index = end + 1;

                }
                else
                {
                    list.Add(new SMap { Value = s[end], Index = end + 1 });
                }
                ans = Math.Max(ans, end - start + 1);
            }
            return ans;
        }
    }

    public class SMap
    {
        public char Value { get; set; }
        public int Index { get; set; }
    }
}
