using System;

namespace _55_跳跃游戏
{
    class Program
    {
        /// <summary>
        /// 给定一个非负整数数组 nums ，你最初位于数组的 第一个下标 。
        /// 数组中的每个元素代表你在该位置可以跳跃的最大长度。
        /// 判断你是否能够到达最后一个下标。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var res = CanJump(new int[] { 3, 2, 1, 0, 4 });
            //var res1 = CanJump1(new int[] { 2, 3, 1, 1, 4 });
        }

        /// <summary>
        /// 想象你是那个在格子上行走的小人，格子里面的数字代表“能量”，你需要“能量”才能继续行走
        /// 把每个值当作能量，如果当前格子的能量大于你手中的，那么就替换为这个大的，取更大的“能量”！ 如果你有更多的能量，你就可以走的更远啦！
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CanJump(int[] nums)
        {
            if (nums.Length == 0)
            {
                return true;
            }
            int cur = nums[0];
            int i = 1;
            for (; cur != 0 && i < nums.Length; i++)
            {
                cur--;
                if (cur < nums[i])
                    cur = nums[i];
            }

            return i == nums.Length;
        }

        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CanJump1(int[] nums)
        {
            if (nums.Length == 0)
            {
                return true;
            }
            int rightmost = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                // 不断更新能走到的最远地方
                rightmost = Math.Max(rightmost, i + nums[i]);
                // 如果更新后位置不变，说明遇到了0
                if (rightmost <= i)
                    return false;
            }

            return rightmost >= nums.Length - 1;
        }

        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CanJump2(int[] nums)
        {
            if (nums.Length == 0)
            {
                return true;
            }

            // 起始位置是否能跳到当前位置
            bool[] dp = new bool[nums.Length];
            // 初始值
            dp[0] = true;

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    // 转移方程：i前面的点只要有一个能跳到当前节点就说明当前节点可达
                    if (dp[j] && (j + nums[j] >= i))
                    {
                        dp[i] = true;
                        break;
                    }
                }
            }

            return dp[nums.Length - 1];
        }
    }
}
