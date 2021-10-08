using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_有效的括号
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "{[]}";
            var b = IsValid(s);
        }

        /// <summary>
        /// 栈的使用
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValid(string s)
        {
            if (s.Length == 0 || s.Length % 2 != 0)
                return false;

            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> keyValues = new Dictionary<char, char>();
            keyValues.Add(')', '(');
            keyValues.Add(']', '[');
            keyValues.Add('}', '{');

            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (keyValues.ContainsKey(ch))
                {
                    if (stack.Count() == 0 || stack.Peek() != keyValues[ch])
                        return false;
                    else
                        stack.Pop();
                }
                else
                {
                    stack.Push(ch);
                }
            }

            return stack.Count() == 0 ? true : false;
        }
    }
}
