using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _344_反转字符串
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] s = { 'h', 'e', 'l', 'l', 'o' };
            ReverseString2(s);
        }

        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="s"></param>
        public static void ReverseString(char[] s)
        {
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                char tmp = s[i];
                s[i] = s[j];
                s[j] = tmp;
                i++;
                j--;
            }
        }

        /// <summary>
        /// 栈
        /// </summary>
        /// <param name="s"></param>
        public static void ReverseString2(char[] s)
        {
            Stack<char> ss = new Stack<char>();
            foreach (var item in s)
            {
                ss.Push(item);
            }
            for(int i = 0; i < s.Length; i++)
            {
                s[i] = ss.Pop();
            }
        }
    }
}
