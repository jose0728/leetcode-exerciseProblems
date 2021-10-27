using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _300_最大上升子序列
{
    class Program
    {
        /// <summary>
        /// 给你一个整数数组 nums ，找到其中最长严格递增子序列的长度。
        /// 子序列是由数组派生而来的序列，删除（或不删除）数组中的元素而不改变其余元素的顺序。例如，[3,6,2,7]
        /// 是数组[0, 3, 1, 6, 2, 2, 7] 的子序列。
        /// 示例 1：
        /// 输入：nums = [10,9,2,5,3,7,101,18]
        /// 输出：4
        /// 解释：最长递增子序列是[2, 3, 7, 101]，因此长度为 4 。
        /// 示例 2：
        /// 输入：nums = [0,1,0,3,2,3]
        /// 输出：4
        /// 示例 3：
        /// 输入：nums = [7,7,7,7,7,7,7]
        /// 输出：1
        /// 提示：
        /// 1 <= nums.length <= 2500
        /// -104 <= nums[i] <= 104
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] a = { 10, 9, 2, 5, 3, 7, 101, 18 };
            int b = LengthOfLIS(a);
        }

        /// <summary>
        /// 动态规划
        /// 状态定义：dp[i]的值代表 nums 前 i 个数字的最长子序列长度
        /// 转移方程： dp[i] = max(dp[i], dp[j] + 1) for j in [0, i)。
        /// 初始状态：
        /// dp[i]所有元素置1，含义是每个元素都至少可以单独成为子序列，此时长度都为 1。
        /// 返回值：返回 dp列表最大值，即可得到全局最长上升子序列长度。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int[] dp = new int[nums.Length];
            dp[0] = 1;
            int max = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                dp[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
                max = Math.Max(max, dp[i]);
            }
            return max;
        }
    }
}
