using System;
using System.Text;

namespace _13_罗马数字转整数
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "IV";
            var b = RomanToInt(s);
        }

        public static int RomanToInt(string s)
        {
            char[] sh = s.ToCharArray();
            int preNum = GetValue(sh[0]);
            int sum = 0;
            for (int i = 1; i < sh.Length; i++)
            {
                if (preNum < GetValue(sh[i]))
                {
                    sum -= preNum;
                }
                else 
                {
                    sum += preNum;
                }
                preNum = GetValue(sh[i]);
            }
            sum += preNum;
            return sum;
        }

        private static int GetValue(char ch)
        {
            switch (ch)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: return 0;
            }
        }
    }
}
