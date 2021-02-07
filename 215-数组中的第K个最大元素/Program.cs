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
