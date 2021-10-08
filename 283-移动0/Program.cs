using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _283_移动0
{
    class Program
    {
        /// <summary>
        /// 给定一个数组 nums，编写一个函数将所有 0 移动到数组的末尾，同时保持非零元素的相对顺序。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] a = new int[] { 0, 1, 0, 3, 12 };
            MoveZero2(a);
        }

        /// <summary>
        /// 双指针法
        /// i为慢指针，j为快指针
        /// nums[j]如果遇到0直接往前走，当nums[j]!=0，时，把这个值赋值给此时的nums[i]
        /// 相当于一直把0往后面换
        /// </summary>
        /// <param name="nums"></param>
        public static void MoveZero1(int[] nums)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != 0)
                {
                    int tmp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = tmp;
                    i++;
                }
            }
        }

        /// <summary>
        /// 先把所有的元素移到左边，再补0
        /// </summary>
        /// <param name="nums"></param>
        public static void MoveZero2(int[] nums)
        {
            int i = 0;
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != 0)
                {
                    nums[i++] = nums[j];
                }
            }
            while (i < nums.Length)
            {
                nums[i++] = 0;
            }
        }
    }
}
