using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_寻找两个正序数组的中位数
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 1, 2 };
            int[] nums2 = { 3, 4 };
            var c = FindMedianSortedArrays(nums1, nums2);
        }

        /// <summary>
        /// 合成一个数组
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] a = new int[nums1.Length + nums2.Length];
            int lindex = 0, rindex = 0;
            int index = 0;

            while (lindex < nums1.Length && rindex < nums2.Length)
            {
                if (nums1[lindex] < nums2[rindex])
                    a[index++] = nums1[lindex++];
                else
                    a[index++] = nums2[rindex++];
            }

            while (lindex < nums1.Length)
            {
                a[index++] = nums1[lindex++];
            }

            while (rindex < nums2.Length)
            {
                a[index++] = nums2[rindex++];
            }

            if (a.Length % 2 == 0)
                return (double)(a[a.Length / 2 - 1] + a[a.Length / 2]) / 2;
            else
            {
                return a[a.Length / 2];
            }
        }

        /// <summary>
        /// 合成一个数组2
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static double FindMedianSortedArrays2(int[] nums1, int[] nums2)
        {
            double result = 0.0;
            List<double> list = new List<double>();
            foreach (var item in nums1)
            {
                list.Add(double.Parse(item.ToString()));
            }
            foreach (var item in nums2)
            {
                list.Add(double.Parse(item.ToString()));
            }
            list.Sort();
            double[] newArray = list.ToArray();
            if (list.Count() == 1)
            {
                result = list.FirstOrDefault();
                return result;
            }
            if (list.Count() % 2 == 0)
            {
                result = (newArray[list.Count() / 2] + newArray[list.Count() / 2 - 1]) / 2;
            }
            else
            {
                result = newArray[list.Count() / 2];
            }
            return result;
        }
    }
}
