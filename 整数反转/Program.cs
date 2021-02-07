using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 整数反转
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 2147483647;
            int b = Reverse(a);
        }

        /// <summary>
        /// 主要判断有没有越界
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int Reverse(int x)
        {
            int res = 0;
            while (x != 0)
            {
                int tmp = x % 10;
                if (res > int.MaxValue / 10 || (res == int.MaxValue / 10 && tmp > 7))
                    return 0;
                if (res < int.MinValue / 10 || (res == int.MinValue / 10 && tmp < -8))
                    return 0;
                res = res * 10 + tmp;
                x /= 10;
            }
            return res;
        }
    }
}
