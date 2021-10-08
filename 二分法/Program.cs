using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二分法
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] piles = { 3, 6, 7, 11 };
            int H = 8;
            var a = MinEatingSpeed(piles, H);
            var b = MySqr4(8);

            int[] nuns = { 3, 4, 5, 0, 1 };
            var c = FindMin2(nuns);

            int[] nuns1 = { 1, 1, 1, 0, 1 };
            var d = FindMin3(nuns1);
        }

        /// <summary>
        /// 爱吃香蕉的阿珂（leetcode875题）
        /// 珂珂喜欢吃香蕉。这里有 N 堆香蕉，第 i 堆中有 piles[i] 根香蕉。警卫已经离开了，将在 H 小时后回来。
        /// 珂珂可以决定她吃香蕉的速度 K （单位：根/小时）。
        /// 每个小时，她将会选择一堆香蕉，从中吃掉 K 根。如果这堆香蕉少于 K 根，她将吃掉这堆的所有香蕉，然后这一小时内不会再吃更多的香蕉。  
        /// 珂珂喜欢慢慢吃，但仍然想在警卫回来前吃掉所有的香蕉。
        /// 返回她可以在 H 小时内吃掉所有香蕉的最小速度 K（K 为整数）。
        /// </summary>
        /// <param name="piles"></param>
        /// <param name="H"></param>
        /// <returns></returns>
        public static int MinEatingSpeed(int[] piles, int H)
        {
            int min = 1;
            int max = MaxV(piles);
            //我们要找符合条件的最小值
            while (min < max)
            {
                int mid = (min + max) / 2;
                if (CanEatFinish(piles, H, mid))
                {//如果能吃完，说明可能还可以吃的更慢
                    max = mid;//这里要注意，因为是能吃完，所以mid也符合条件
                }
                else
                {//不能吃完，说明需要吃的更快一点
                    min = mid + 1;//这里要注意，因为不能吃完，所以mid不符合条件
                }
            }
            return min;
        }

        /// <summary>
        /// 找出香蕉堆中的最大值
        /// </summary>
        /// <param name="piles"></param>
        /// <returns></returns>
        private static int MaxV(int[] piles)
        {
            int temp = 0;
            foreach (int v in piles)
            {
                temp = Math.Max(v, temp);
            }
            return temp;
        }

        /// <summary>
        /// 能否在H小时以速度K吃完香蕉
        /// </summary>
        /// <param name="piles">香蕉</param>
        /// <param name="H">H小时</param>
        /// <param name="K">速度K</param>
        /// <returns></returns>
        private static bool CanEatFinish(int[] piles, int H, int K)
        {
            int h = 0;
            //foreach (int p in piles)
            //{
            //    h += (p - 1) / K + 1;
            //}
            foreach (int p in piles)
            {
                h += (int)Math.Ceiling(p * 1.0 / K);
            }

            return h <= H;
        }

        /// <summary>
        /// x的平方根（leetcode69题）
        /// 二分法
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int MySqrt(int x)
        {
            if (x == 0) return 0;
            if (x == 1) return 1;
            long left = 1;
            long right = x / 2;
            while (left <= right)
            {
                long mid = (left + right) / 2;
                if (mid * mid == x)
                    return (int)mid;
                else if (mid * mid < x)
                    left = (int)(mid + 1);
                else
                    right = (int)(mid - 1);
            }
            return (int)right;
        }

        /// <summary>
        /// x的平方根（leetcode69题）
        /// 暴力解法
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int MySqr2(int x)
        {
            long res = 1;
            while (res * res <= x)
            {
                res++;
            }
            return (int)(res - 1);
        }

        public static int MySqr3(int x)
        {
            return (int)Math.Sqrt(x);
        }

        public static int MySqr4(int x)
        {
            if (x == 0)
                return 0;
            if (x == 1)
                return 1;
            long left = 1;
            long right = x / 2;

            while (left < right)
            {
                long mid = (right - left) / 2 + left;
                if (mid < x / mid)
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return (int)left;
        }

        /// <summary>
        /// 第一个错误的版本（leetcode278题）
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (IsBadVersion(mid))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        /// <summary>
        /// 是否是坏的版本
        /// 此处模拟假的代码
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsBadVersion(int n)
        {
            return true;
        }

        /// <summary>
        /// 旋转排序数组最小值Ⅰ（leetcode153题）
        /// 已知一个长度为 n 的数组，预先按照升序排列，经由 1 到 n 次 旋转 后，得到输入数组。例如，原数组 nums = [0,1,2,4,5,6,7] 在变化后可能得到：
        /// 若旋转 4 次，则可以得到[4, 5, 6, 7, 0, 1, 2]
        /// 若旋转 7 次，则可以得到[0, 1, 2, 4, 5, 6, 7]
        /// 注意，数组[a[0], a[1], a[2], ..., a[n - 1]] 旋转一次 的结果为数组[a[n - 1], a[0], a[1], a[2], ..., a[n - 2]] 。
        /// 给你一个元素值 互不相同 的数组 nums ，它原来是一个升序排列的数组，并按上述情形进行了多次旋转。请你找出并返回数组中的 最小元素 。
        /// 二分法（官方题解）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMin(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            int left = 0;
            int right = nums.Length - 1;

            //如果没有旋转过，那nums[right]必定大于nums[0]，nums[0]是最小元素
            if (nums[right] > nums[0])
            {
                return nums[0];
            }

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                //特判
                if (nums[mid] > nums[mid + 1])
                {
                    return nums[mid + 1];
                }

                //特判
                if (nums[mid - 1] > nums[mid])
                {
                    return nums[mid];
                }

                if (nums[mid] > nums[0])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }

            }
            return -1;
        }

        /// <summary>
        /// 旋转排序数组最小值Ⅰ（leetcode153题）
        /// 二分法（另一种方法）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMin2(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            int left = 0;
            int right = nums.Length - 1;

            if (nums[right] > nums[left])
            {
                return nums[0];
            }

            while (left < right)
            {
                int mid = (right + left) / 2;

                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }

            }
            return nums[left];
        }

        /// <summary>
        /// 旋转排序数组中的最小值Ⅱ（leetcode154题）
        /// 已知一个长度为 n 的数组，预先按照升序排列，经由 1 到 n 次 旋转 后，得到输入数组。例如，原数组 nums = [0,1,4,4,5,6,7] 在变化后可能得到：
        /// 若旋转 4 次，则可以得到[4, 5, 6, 7, 0, 1, 4]
        /// 若旋转 7 次，则可以得到[0, 1, 4, 4, 5, 6, 7]
        /// 注意，数组[a[0], a[1], a[2], ..., a[n - 1]] 旋转一次 的结果为数组[a[n - 1], a[0], a[1], a[2], ..., a[n - 2]] 。
        /// 给你一个可能存在 重复 元素值的数组 nums ，它原来是一个升序排列的数组，并按上述情形进行了多次旋转。请你找出并返回数组中的 最小元素 。
        /// 二分法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMin3(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            int left = 0;
            int right = nums.Length - 1;

            if (nums[right] > nums[left])
            {
                return nums[0];
            }

            while (left < right)
            {
                int mid = (right + left) / 2;

                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else if (nums[mid] < nums[right])
                {
                    right = mid;
                }
                else
                {
                    right--;
                }
            }
            return nums[left];
        }

        /**
         * 整体思路：
         * (1)先找到每个房屋离加热器的最短距离（即找出离房屋最近的加热器）；
         *  (2)在所有距离中选出最大的一个即为最小覆盖半径。记住是选一个最大的距离。
         * 二分查找的思路
         * 针对每个房屋都有四中可能性
         * 1，房屋的位置刚好有一个加热器，那么加热器离房屋的距离就是0
         * 2，房屋的左边没有加热器，右边有加热器，那最小距离是：加热器位置 - 房屋的位置
         * 3，房屋的左边有加热器，右边没有，那最小距离是：房屋的位置 - 加热器的位置
         * 4，房屋的左右都有加热器，那最小距离是： Min（房屋离左侧加热器的距离，房屋离右侧加热器的距离）
         */
        /// <summary>
        /// 供暖器（leetcode475题）
        /// 冬季已经来临。 你的任务是设计一个有固定加热半径的供暖器向所有房屋供暖。
        /// 在加热器的加热半径范围内的每个房屋都可以获得供暖。
        /// 现在，给出位于一条水平线上的房屋 houses 和供暖器 heaters 的位置，请你找出并返回可以覆盖所有房屋的最小加热半径。
        /// 说明：所有供暖器都遵循你的半径标准，加热的半径也一样。
        /// </summary>
        /// <param name="houses"></param>
        /// <param name="heaters"></param>
        /// <returns></returns>
        public static int FindRadius(int[] houses, int[] heaters)
        {
            Array.Sort(heaters);

            int[] distances = new int[houses.Length];
            for (int i = 0; i < houses.Length; i++)
            {
                int left = 0;
                int right = heaters.Length - 1;

                //找到离本房子最近的加热器
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (heaters[mid] > houses[i])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid;
                    }
                }
                if (heaters[left] == houses[i])
                {
                    distances[i] = 0;
                }
                else if (heaters[left] > houses[i] && left == 0)
                {
                    // 如果加热器在房屋的右边且房屋的左边没有加热器了
                    distances[i] = heaters[left] - houses[i];
                }
                else if (heaters[left] < houses[i] && left == heaters.Length - 1)
                {
                    // 如果加热器在房屋的左边，且房屋的右边没有加热器了
                    distances[i] = houses[i] - heaters[left];
                }
                else
                {
                    // 如果房屋两边都有加加热器
                    distances[i] = Math.Min((heaters[left + 1] - houses[i]), (houses[i] - heaters[left]));
                }
            }

            Array.Sort(distances);
            return distances[distances.Length - 1];
        }
    }
}
