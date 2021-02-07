using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _438_找到字符串中所有字母的异位词
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "cbaebabacd";
            string p = "abc";
            var a = FindAnagrams(s, p);
        }

        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static List<int> FindAnagrams(string s, string p)
        {
            List<int> resultList = new List<int>();
            // 计算字符串p中各元素的出现次数
            int[] pFreq = new int[26];
            for (int i = 0; i < p.Length; i++)
            {
                pFreq[p[i] - 'a']++;
            }

            // 窗口区间为[start,end]
            int start = 0, end = -1;
            while (start < s.Length)
            {
                // 还有剩余元素未考察，且窗口内字符串长度小于字符串p的长度
                // 则扩大窗口右侧边界
                if (end + 1 < s.Length && end - start + 1 < p.Length)
                {
                    end++;
                }
                else
                {
                    // 右侧边界不能继续扩大或窗口内字符串长度等于字符串p的长度
                    // 则缩小左侧边界
                    start++;
                }
                // 当窗口内字符串长度等于字符串p的长度时，则判断其是不是字符串p的字母异位词子串
                if (end - start + 1 == p.Length && IsAnagrams(s.Substring(start, p.Length), pFreq))
                {
                    resultList.Add(start);
                }
            }
            return resultList;
        }

        /// <summary>
        /// 判断当前子串是不是字符串p的字母异位词s
        /// </summary>
        /// <param name="window"></param>
        /// <param name="pFreq"></param>
        /// <returns></returns>
        private static bool IsAnagrams(string window, int[] pFreq)
        {
            // 计算窗口内字符串各元素的出现次数
            int[] windowFreq = new int[26];
            for (int i = 0; i < window.Length; i++)
            {
                windowFreq[window[i] - 'a']++;
            }
            // 比较窗口内各元素的出现次数和字符串p中各元素的出现次数是否一样
            // 如果都一样，则说明窗口内的字符串是字符串p的字母异位词子串
            // 如果不一样，则说明不是其子串
            for (int j = 0; j < 26; j++)
            {
                if (windowFreq[j] != pFreq[j])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
