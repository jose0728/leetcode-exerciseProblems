using System;
using System.Collections.Generic;
using System.Linq;

namespace _136__只出现一次的数字
{
    class Program
    {
        /// <summary>
        /// 给定一个非空整数数组，除了某个元素只出现一次以外，其余每个元素均出现两次。找出那个只出现了一次的元素。
        /// 说明：你的算法应该具有线性时间复杂度。 你可以不使用额外空间来实现吗？
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 位运算
        /// 任何数和0做异或运算，结果仍然是原来的数：a⊕0 = a
        /// 任何数和其自身做异或运算，结果是 0：a⊕a=0
        /// 异或运算满足交换律和结合律：a⊕b⊕a=(a⊕a)⊕b=0⊕b=b
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int SingleNumber(int[] nums)
        {
            int res = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                res ^= nums[i];
            }
            return res;
        }

        public static int SingleNumber2(int[] nums)
        {
            List<int> dic = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.Contains(nums[i]))
                {
                    dic.Remove(nums[i]);
                    continue;
                }
                dic.Add(nums[i]);
            }
            return dic.FirstOrDefault();
        }
    }
}
