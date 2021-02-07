using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 扑克牌中的顺子
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5 };
            int[] b = { 1, 3, 5, 0, 0 };
            int[] c = { 1, 4, 5, 0, 0 };
            int[] d = { 4, 1, 6, 0, 0 };
            var e = IsStraight(d);
        }

        /// <summary>
        /// 
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
