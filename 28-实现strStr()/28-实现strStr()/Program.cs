using System;

namespace _28_实现strStr__
{
    class Program
    {
        static void Main(string[] args)
        {
            string haystack = "hello", needle = "ll";
            StrStr(haystack, needle);
        }

        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public static int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0)
                return 0;
            int left = 0;
            int right = 0;
            int index = 0;
            while (right < haystack.Length && index < needle.Length)
            {
                if (haystack[right] != needle[index])
                {
                    left++;
                    right = left;
                    index = 0;
                }
                else
                {
                    right++;
                    index++;
                }
            }
            return index == needle.Length ? left : -1;
        }
    }
}
