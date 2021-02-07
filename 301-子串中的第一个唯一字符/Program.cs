using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _387_子串中的第一个唯一字符
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "leetcode";
            int a = FirstUniqChar(s);
        }

        public static int FirstUniqChar(string s)
        {
            int[] nums = new int[26];
            char[] chars = s.ToCharArray();
            foreach (var item in chars)
            {
                nums[item - 'a']++;
            }
            for (int i = 0; i < chars.Length; i++)
            {
                if (nums[chars[i] - 'a'] == 1)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int FirstUniqChar2(string s)
        {
            char[] chars = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                char c = chars[i];
                if (s.IndexOf(c) == s.LastIndexOf(c))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
