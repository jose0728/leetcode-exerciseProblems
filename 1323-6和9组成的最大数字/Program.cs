using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1323_6和9组成的最大数字
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Maximum69Number(9669);
        }

        public static int Maximum69Number(int num)
        {
            char[] chars = num.ToString().ToArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == '6')
                {
                    chars[i] = '9';
                    break;
                }
            }
            var a = new string(chars);
            return int.Parse(a);
        }
    }
}
