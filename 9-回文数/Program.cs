using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 回文数
{
    class Program
    {
        static void Main(string[] args)
        {
            bool a = IsPalindrome(12321);
        }

        /// <summary>
        /// 用到反转数字
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            int cur = 0;
            int num = x;
            while (num != 0)
            {
                cur = cur * 10 + num % 10;
                num /= 10;
            }
            return x == cur;
        }
    }
}
