using System;
using System.Collections.Generic;
using System.Text;

namespace _17_电话号码的字母组合
{
    class Program
    {
        static void Main(string[] args)
        {
            LetterCombinations("23");
        }

        /// <summary>
        /// 回溯
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static IList<string> LetterCombinations(string digits)
        {
            IList<string> res = new List<string>();

            if (digits.Length == 0)
                return res;

            Dictionary<char, string> dics = new Dictionary<char, string>
            {
                { '2',"abc"},
                { '3',"def"},
                { '4',"ghi"},
                { '5',"jkl"},
                { '6',"mno"},
                { '7',"pqrs"},
                { '8',"tuv"},
                { '9',"wxyz"}
            };

            Backtrack(digits, res, dics, 0, "");
            return res;
        }

        public static void Backtrack(string digits, IList<string> combinations, Dictionary<char, string> dics, int index, string builder)
        {
            if (index == digits.Length)
            {
                combinations.Add(builder.ToString());
            }
            else
            {
                //每次要匹配的第一个字符
                char dight = digits[index];
                //这个字符对应的字母字符串
                var str = dics[dight];
                var count = str.Length;
                for (int j = 0; j < count; j++)
                {
                    Backtrack(digits, combinations, dics, index + 1, builder + str[j]);
                }
            }
        }
    }
}
