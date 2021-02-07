using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_整数转罗马数字
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = IntToRoman(950);
        }

        public static string IntToRoman(int num)
        {
            int[] nums = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] romans = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int index = 0;
            StringBuilder result = new StringBuilder();
            while (index < 13)
            {
                if (num >= nums[index])
                {
                    result.Append(romans[index]);
                    num -= nums[index];
                }
                else
                {
                    index++;
                }

                if (num == 0)
                    break;
            }
            return result.ToString();
        }
    }
}
