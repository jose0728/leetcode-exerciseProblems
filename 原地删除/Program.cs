using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_原地删除
{
    class Program
    {
        //leetcode 27题
        static void Main(string[] args)
        {
            int[] a = new int[] { 3, 2, 2, 3 };
            int b = DeleteElement2(a,3);
        }

        /// <summary>
        /// 双指针法
        /// 设定一个i指针，下标代表新数组的下标，遍历数组，当元素不是想要删除的元素时，把这个值赋值给arr[i]，i++
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="val"></param>
        public static int DeleteElement1(int[] arr, int val)
        {
            int i = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                if (arr[j] != val)
                {
                    arr[i] = arr[j];
                    i++;
                }
            }
            return i;
        }

        /// <summary>
        /// 方法二：如果是想要删除的元素，那么把它和数组/新数组的最后一个元素换位
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int DeleteElement2(int[] arr, int val)
        {
            int i = 0;
            int n = arr.Length;
            while (i < n)
            {
                if (arr[i] == val)
                {
                    arr[i] = arr[n - 1];
                    n--;
                }
                else
                {
                    i++;
                }
            }
            return n;
        }
    }
}
