using System;

namespace _172_阶乘后的零
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = TrailingZeroes(103);
        }

        public static int TrailingZeroes(int n)
        {
            int count = 0;
            while (n >= 5)
            {

                count += n / 5;
                n /= 5;
            }
            return count;
        }
    }
}
