using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _58_最后一个单词的长度
{
    class Program
    {
        /// <summary>
        /// 给你一个字符串 s，由若干单词组成，单词前后用一些空格字符隔开。返回字符串中最后一个单词的长度。
        /// 单词 是指仅由字母组成、不包含任何空格字符的最大子字符串。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //string s = "a ";
            string s = "   fly me   to   the moon  ";
            int a = LengthOfLastWord3(s);
        }

        public static int LengthOfLastWord(string s)
        {
            var index = s.Trim().LastIndexOf(" ");
            var resLength = s.Trim().Substring(index + 1).Length;
            return resLength;
        }

        public static int LengthOfLastWord2(string s)
        {
            string[] words = s.TrimEnd().TrimStart().Split(' ');
            if (words.Length < 1) return 0;
            return words[words.Length - 1].Length;
        }

        /// <summary>
        /// 双指针法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LengthOfLastWord3(string s)
        {
            if (s == "" || s.Length == 0)
                return 0;
            int end = s.Length - 1;
            while (end >= 0 && s[end] == ' ')
            {
                end--;
            }
            if (end < 0)
            {
                return 0;
            }
            int start = end;
            while (start >= 0 && s[start] != ' ')
            {
                start--;
            }
            return end - start;
        }
    }
}
