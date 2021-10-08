using System;

namespace _137___只出现一次的数字2
{
    class Program
    {
        /// <summary>
        /// 给你一个整数数组 nums ，除某个元素仅出现 一次 外，其余每个元素都恰出现 三次 。请你找出并返回那个只出现了一次的元素。
        /// 方法一：哈希（此处不写了）
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var res = SingleNumber(new int[] { 3, 5, 3, 3 });
        }

        /// <summary>
        /// 方法二：位运算
        /// 考虑数字的二进制形式，对于出现三次的数字，各 二进制位 出现的次数都是 3 的倍数。
        /// 因此，统计所有数字的各二进制位中 1 的出现次数，并对 3 求余，结果则为只出现一次的数字。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int SingleNumber(int[] nums)
        {
            int res = 0;
            for (int i = 0; i < 32; i++)
            {
                int sum = 0;
                foreach (var item in nums)
                {
                    sum += (item >> i) & 1;
                }

                if (sum % 3 == 1)
                {
                    res |= (1 << i);
                }
            }
            return res;
        }
    }
}
