using System;
using System.Collections.Generic;

namespace _22_括号生成
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateParenthesis2(2);
        }
        public static IList<string> GenerateParenthesis(int n)
        {
            IList<string> res = new List<string>();
            var str = "";
            Trackback(n, n, str, res);
            return res;
        }

        public static void Trackback(int left, int right, string curStr, IList<string> list)
        {
            if (left == 0 && right == 0)
            {
                list.Add(curStr);
                return;
            }

            // 剪枝
            if (left < 0 || right < 0) return;
            if (left > right) return;

            if (left > 0)
            {
                Trackback(left - 1, right, curStr + "(", list);
            }
            if (right > 0)
            {
                Trackback(left, right - 1, curStr + ")", list);
            }
        }
        public static List<String> GenerateParenthesis2(int n)
        {
            List<string> combinations = new List<string>();
            GenerateAll(new char[2 * n], 0, combinations);
            return combinations;
        }

        public static void GenerateAll(char[] current, int pos, List<string> result)
        {
            if (pos == current.Length)
            {
                if (Valid(current))
                {
                    result.Add(new string(current));
                }
            }
            else
            {
                current[pos] = '(';
                GenerateAll(current, pos + 1, result);
                current[pos] = ')';
                GenerateAll(current, pos + 1, result);
            }
        }

        public static bool Valid(char[] current)
        {
            int balance = 0;
            foreach (char c in current)
            {
                if (c == '(')
                {
                    ++balance;
                }
                else
                {
                    --balance;
                }
                if (balance < 0)
                {
                    return false;
                }
            }
            return balance == 0;
        }
    }
}
