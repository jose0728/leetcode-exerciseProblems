using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大数打印
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = PrintNumbers2(3);
        }

        public static int[] PrintNumbers1(int n)
        {
            int len = (int)Math.Pow(10, n);
            int[] res = new int[len - 1];
            for (int i = 1; i < len; i++)
            {
                res[i - 1] = i;
            }
            return res;
        }

        public static int[] PrintNumbers2(int n)
        {
            int l = 0;
            for (int i = 0; i < n; i++)
            {
                l = l * 10 + 9;
            }
            int[] res = new int[l];
            for (int i = 1; i <= l; i++)
            {
                res[i - 1] = i;
            }
            return res;
        }
    }
}
