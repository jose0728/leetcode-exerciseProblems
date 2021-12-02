using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26_删除重复数组中的重复项
{
    class Program
    {
        //leetcode 26题
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 1, 2, 3, 4, 5, 5, 5, 6 };
            int b = DeleteRepeatElement(a);
        }

        /// <summary>
        /// 双指针法
        /// i慢指针
        /// j快指针
        /// 如果相邻两个元素不相等，慢指针要加一，并且把当前nums[j]的值赋给nums[i]，否则，快指针j一直往下加
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int DeleteRepeatElement(int[] nums)
        {
            if (nums.Length == 0) return 0;
            int i = 0;//慢指针
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }
    }
}
