using System;

namespace _153_旋转排序数组最小值Ⅰ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nuns = { 3, 4, 5, 0, 1 };
            var a = FindMin2(nuns);
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
    }
}
