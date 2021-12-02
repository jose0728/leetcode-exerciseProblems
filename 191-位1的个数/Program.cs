using System;

namespace _191_位1的个数
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = HammingWeight(11);
        }

        /// <summary>
        /// 位1的个数
        /// 编写一个函数，输入是一个无符号整数，返回其二进制表达式中数字位数为 ‘1’ 的个数（也被称为汉明重量）。
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int HammingWeight(uint n)
        {
            int bits = 0;
            int mask = 1;
            for (int i = 0; i < 32; i++)
            {
                if ((n & mask) != 0)
                {
                    bits++;
                }
                mask <<= 1;
            }
            return bits;
        }

        /// <summary>
        /// 从右边开始去掉1,去掉几个就一共几个
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int HammingWeight2(int n)
        {
            int count = 0;
            while (n > 0)
            {
                n &= (n - 1);
                ++count;
            }
            return count;
        }
    }
}
