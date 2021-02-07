using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _650_只有两个键的键盘
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            var b = MinSteps(a);
        }

        /// <summary>
        /// 只有两个键的键盘（leetcode650题）
        /// 1、质数次数为其本身。
        /// 2、合数次数为将其分解到所有不能再分解的质数的操作次数的和。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int MinSteps(int n)
        {
            int ans = 0;
            int d = 2;
            while (n > 1)
            {
                while (n % d == 0)
                {
                    ans += d;
                    n /= d;
                }
                d++;
            }
            return ans;
        }
    }
}
