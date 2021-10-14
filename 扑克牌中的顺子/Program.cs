using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 扑克牌中的顺子
{
    class Program
    {
        /// <summary>
        /// 从若干副扑克牌中随机抽 5 张牌，判断是不是一个顺子，即这5张牌是不是连续的。2～10为数字本身，A为1，J为11，Q为12，K为13，而大、小王为 0 ，可以看成任意数字。A 不能视为 14。
        /// 输入: [1,2,3,4,5]
        /// 输出: True
        /// 输入: [0,0,1,2,5]
        /// 输出: True
        /// 限制：
        /// 数组长度为 5 
        /// 数组的数取值为[0, 13] .
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5 };
            int[] b = { 1, 3, 5, 0, 0 };
            int[] c = { 1, 4, 5, 0, 0 };
            int[] d = { 4, 1, 6, 0, 0 };
            var e = IsStraight(d);
        }

        /// <summary>
        /// 排序+遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool IsStraight(int[] nums)
        {
            if (nums.Length == 0)
                return false;
            int sum = 0;
            foreach (var item in nums)
            {
                if (item == 0)
                {
                    sum++;
                }
            }

            Array.Sort(nums);

            for (int i = sum + 1; i < nums.Length; i++)
            {
                sum -= nums[i] - nums[i - 1] - 1;
                if (sum < 0 || nums[i] == nums[i - 1])
                    return false;
            }
            return true;
        }
    }
}
