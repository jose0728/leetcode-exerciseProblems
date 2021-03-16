using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 旋转数组
{
    class Program
    {
        //leetcode 189题
        //要求使用空间复杂度为 O(1) 的 原地 算法
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int[] b = RotateArr1(arr, 3);
        }

        /// <summary>
        /// 暴力解法
        /// pervious的作用：每一次记录调整后数组的最后一个数字，作为交换的
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int[] RotateArr1(int[] arr, int num)
        {
            int pervious, tmp;
            for (int i = 0; i < num; i++)
            {
                pervious = arr[arr.Length - 1];
                for (int j = 0; j < arr.Length; j++)
                {
                    tmp = arr[j];
                    arr[j] = pervious;
                    pervious = tmp;
                }
            }
            return arr;
        }

        /// <summary>
        /// 三次反转
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int[] RotateArr2(int[] arr, int num)
        {
            num %= arr.Length;
            Rotate(arr, 0, arr.Length - 1);
            Rotate(arr, 0, num - 1);
            Rotate(arr, num, arr.Length - 1);
            return arr;
        }

        public static int[] Rotate(int[] arr, int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                int tmp = arr[startIndex];
                arr[startIndex] = arr[endIndex];
                arr[endIndex] = tmp;
                startIndex++;
                endIndex--;
            }
            return arr;
        }
    }
}
