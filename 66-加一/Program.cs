using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _66_加一
{
    class Program
    {
        /// <summary>
        /// 给定一个由 整数 组成的 非空 数组所表示的非负整数，在该数的基础上加一。
        /// 最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。
        /// 你可以假设除了整数 0 之外，这个整数不会以零开头。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] a = { 9, 9, 7 };
            int[] b = PlusOne(a);
        }

        public static int[] PlusOne(int[] digits)
        { 
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i]++;
                digits[i] %= 10;
                if (digits[i] != 0)
                {
                    return digits;
                }
            }
            digits = new int[digits.Length + 1];
            digits[0] = 1;
            return digits;
        }
    }
}
