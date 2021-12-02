using System;
using System.Collections.Generic;

namespace _151_翻转字符串里的单词
{
    class Program
    {
        static void Main(string[] args)
        {

            ReverseWords("the sky is blue");
        }

        public static string ReverseWords(string s)
        {
            string res = string.Empty;
            if (s.Length == 0 || s.Trim().Length == 0)
                return "";
            s = s.Trim();
            int n = s.Length;
            Stack<string> tmp = new Stack<string>();
            char[] arr = s.ToCharArray();
            string word = string.Empty;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] != ' ')
                {
                    word += arr[i];
                    if (i == n - 1 || arr[i + 1] == ' ')
                    {
                        tmp.Push(word);
                        word = string.Empty;
                    }
                }
            }

            while (tmp.Count > 0)
            {
                res += tmp.Peek() + " ";
                tmp.Pop();
            }

            return res.Trim();
        }
    }
}
