using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _66_加一
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 3, 2, 1 };
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
