using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 最小堆;

namespace _215_数组中的第K个最大元素
{
    class Program
    {
        /// <summary>
        /// 给定整数数组 nums 和整数 k，请返回数组中第 k 个最大的元素。
        /// 请注意，你需要找的是数组排序后的第 k 个最大的元素，而不是第 k 个不同的元素。
        /// 示例 1:
        /// 输入: [3,2,1,5,6,4]
        /// 和 k = 2
        /// 输出: 5
        /// 示例 2:
        /// 输入: [3,2,3,1,2,4,5,5,6]
        /// 和 k = 4
        /// 输出: 4
        /// 提示：
        /// 1 <= k <= nums.length <= 104
        /// -104 <= nums[i] <= 104
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            int[] a = { 3, 2, 1, 5, 6, 4 };
            int b = FindKthLargest(a, 3);
        }

        /// <summary>
        /// 最大堆
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int FindKthLargest(int[] nums, int k)
        {
            int heapSize = nums.Length;
            BuildMaxHeap(nums, heapSize);
            for (int i = nums.Length - 1; i >= nums.Length - k + 1; --i)
            {
                Swap(nums, 0, i);
                --heapSize;
                MaxHeapify(nums, 0, heapSize);
            }
            return nums[0];
        }

        public static void BuildMaxHeap(int[] a, int heapSize)
        {
            for (int i = heapSize / 2; i >= 0; --i)
            {
                MaxHeapify(a, i, heapSize);
            }
        }

        public static void MaxHeapify(int[] a, int i, int heapSize)
        {
            int l = i * 2 + 1, r = i * 2 + 2, largest = i;
            if (l < heapSize && a[l] > a[largest])
            {
                largest = l;
            }
            if (r < heapSize && a[r] > a[largest])
            {
                largest = r;
            }
            if (largest != i)
            {
                Swap(a, i, largest);
                MaxHeapify(a, largest, heapSize);
            }
        }

        public static void Swap(int[] a, int i, int j)
        {
            int temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
}
