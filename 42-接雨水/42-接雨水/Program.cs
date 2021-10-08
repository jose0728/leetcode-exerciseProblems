using System;

namespace _42_接雨水
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
        }

        /// <summary>
        /// 定理一：在某个位置i处，它能存的水，取决于它左右两边的最大值中较小的一个。

        /// 定理二：当我们从左往右处理到left下标时，左边的最大值left_max对它而言是可信的，但right_max对它而言是不可信的。（由于中间状况未知，对于left下标而言，right_max未必就是它右边最大的值）

        /// 定理三：当我们从右往左处理到right下标时，右边的最大值right_max对它而言是可信的，但left_max对它而言是不可信的。
        /// 对于位置left而言，它左边最大值一定是left_max，右边最大值“大于等于”right_max，
        /// 这时候，如果left_max<right_max成立，那么它就知道自己能存多少水了。无论右边将来会不会出现更大的right_max，都不影响这个结果。
        /// 所以当left_max<right_max时，我们就希望去处理left下标，反之，我们希望去处理right下标。
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public static int Trap(int[] height)
        {
            int ans = 0;
            int left = 0, right = height.Length - 1;
            int leftMax = 0, rightMax = 0;
            while (left <= right)
            {
                if (leftMax < rightMax)
                {
                    ans += Math.Max(0, leftMax - height[left]);
                    leftMax = Math.Max(leftMax, height[left]);
                    ++left;
                }
                else
                {
                    ans += Math.Max(0, rightMax - height[right]);
                    rightMax = Math.Max(rightMax, height[right]);
                    --right;
                }
            }
            return ans;
        }
    }
}
