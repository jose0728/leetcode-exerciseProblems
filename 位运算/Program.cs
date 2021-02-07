using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 位运算
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = SumNums(4);
            var b = IsPowerOfTwo3(8);
            var c = HammingWeight(11);
        }


        /// <summary>
        /// 连续n个数的和
        /// 求 1 2 ... n ，要求不能使用乘除法、for、while、if、else、switch、case等关键字及条件判断语句（A?B:C）。
        /// </summary>
        /// &&短路代替递归
        /// <param name="n"></param>
        /// <returns></returns>
        public static int SumNums(int n)
        {
            Console.WriteLine("开始：" + n);
            bool a = n > 0 && (n += SumNums(n - 1)) > 0;
            Console.WriteLine("结束：" + n);
            return n;
        }

        /// <summary>
        /// 2的幂
        /// 给定一个整数，编写一个函数来判断它是否是 2 的幂次方。
        /// </summary>
        /// 利用技巧
        /// 对于N为2的幂的数，都有 N&(N-1)=0
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPowerOfTwo(int n)
        {
            return n > 0 && (n & (n - 1)) == 0;
        }

        /// <summary>
        /// 2的幂
        /// 给定一个整数，编写一个函数来判断它是否是 2 的幂次方。
        /// </summary>
        /// 利用技巧
        /// 对于N为2的幂的数，都有 x & (-x)=x
        /// -10的二进制位是10的二进制位通过求补得到
        /// 求补的方法：按位取反加一。技巧法：从右到左的第一个1以及它的右侧的位都不变，它的左侧按位取反
        /// 10 & (-10) = 0000 1010 & 1111 0110 = 0000 00 10
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPowerOfTwo2(int n)
        {
            return n > 0 && (n & (-n)) == n;
        }

        /// <summary>
        /// 2的幂
        /// 给定一个整数，编写一个函数来判断它是否是 2 的幂次方。
        /// 遍历
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPowerOfTwo3(int n)
        {
            if (n == 0) return false;
            while (n % 2 == 0) n /= 2;
            return n == 1;
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

        /// <summary>
        /// 缺失数字（leetcode268题）
        /// 给定一个包含 0, 1, 2, ..., n 中 n 个数的序列，找出 0 .. n 中没有出现在序列中的那个数。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MissingNumber(int[] nums)
        {
            int n = nums.Length;
            int sum = 0;
            foreach (var v in nums)
            {
                sum += v;
            }
            return n * (n + 1) / 2 - sum;
        }

        public static int MissingNumber2(int[] nums)
        {
            Array.Sort(nums);
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i)
                {
                    return i;
                }
            }
            return n;
        }

        public static int MissingNumber3(int[] nums)
        {
            int missing = nums.Length;
            for (int i = 0; i < nums.Length; i++)
            {
                missing ^= i ^ nums[i];
            }
            return missing;
        }

        /// <summary>
        /// 只出现一次的数字（leetcode136题）
        /// 给定一个非空整数数组，除了某个元素只出现一次以外，其余每个元素均出现两次。找出那个只出现了一次的元素。
        /// 任意一个数和0异或仍然为自己：a⊕0 = a
        ///任意一个数和自己异或是0：a⊕a=0
        ///异或操作满足交换律和结合律：a⊕b⊕a=(a⊕a)⊕b=0⊕b=b
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int SingleNumber(int[] nums)
        {
            int ans = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                ans = ans ^ nums[i];
            }
            return ans;
        }
    }
}
