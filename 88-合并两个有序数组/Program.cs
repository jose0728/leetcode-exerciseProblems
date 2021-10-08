using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _88_合并两个有序数组
{
    class Program
    {
        /// <summary>
        /// 给你两个按 非递减顺序 排列的整数数组 nums1 和 nums2，另有两个整数 m 和 n ，分别表示 nums1 和 nums2 中的元素数目
        /// 请你 合并 nums2 到 nums1 中，使合并后的数组同样按 非递减顺序 排列。
        /// 注意：最终，合并后数组不应由函数返回，而是存储在数组 nums1 中。
        /// 为了应对这种情况，nums1 的初始长度为 m + n，其中前 m 个元素表示应合并的元素，后 n 个元素为 0 ，应忽略。nums2 的长度为 n 。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] nums1 = { 1, 2, 0, 0, 0 };
            int m = 2;
            int[] nums2 = { 3, 5, 6 };
            int n = 3;
            Merge3(nums1, m, nums2, n);
        }

        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public static void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int[] res = new int[m + n];
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < m && j < n)
            {
                if (nums1[i] <= nums2[j])
                {
                    res[k] = nums1[i];
                    i++;
                }
                else if (nums1[i] > nums2[j])
                {
                    res[k] = nums2[j];
                    j++;
                }
                k++;
            }
            while (i < m)
            {
                res[k++] = nums1[i++];
            }
            while (j < n)
            {
                res[k++] = nums2[j++];
            }

            Array.Copy(res, nums1, m + n);
        }

        /// <summary>
        /// 先合并后排序
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public static void Merge2(int[] nums1, int m, int[] nums2, int n)
        {
            for (int i = 0; i < n; i++)
            {
                nums1[m + i] = nums2[i];
            }

            Array.Sort(nums1);
        }

        public static void Merge3(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1;
            int j = n - 1;
            int k = m + n - 1;

            while (i >= 0 && j >= 0)
            {
                nums1[k--] = nums1[i] > nums2[j] ? nums1[i--] : nums2[j--];
            }

            Array.Copy(nums2, 0, nums1, 0, j + 1);
        }
    }
}
