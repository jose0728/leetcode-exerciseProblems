using System;

namespace _461_汉明距离
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = HammingDistance2(1, 4);
        }

        /// <summary>
        /// 汉明距离
        /// 本体最后取二进制数的1的个数
        /// 把所有位置都移到右边，然后判断是不是1
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int HammingDistance(int x, int y)
        {
            int xor = x ^ y;
            int dis = 0;
            while (xor != 0)
            {
                if (xor % 2 == 1)
                    dis += 1;
                xor = xor >> 1;
            }

            return dis;
        }

        /// <summary>
        /// 汉明距离
        /// 布赖恩·克尼根算法
        /// 遇到最右边的 1 后，如果可以跳过中间的 0，直接跳到下一个 1，效率会高很多
        /// 当我们在 number 和 number-1 上做 AND 位运算时，原数字 number 的最右边等于 1 的比特会被移除。
        /// 所以这个算法对于1和4这个用例只走了2次
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int HammingDistance2(int x, int y)
        {
            int xor = x ^ y;
            int dis = 0;
            while (xor != 0)
            {
                dis += 1;
                xor = xor & (xor - 1);
            }

            return dis;
        }
    }
}
