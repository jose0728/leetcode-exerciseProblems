using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _189_旋转数组
{
    class Program
    {
        /// <summary>
        /// 给定一个数组，将数组中的元素向右移动 k 个位置，其中 k 是非负数。
        /// 进阶：
        /// 尽可能想出更多的解决方案，至少有三种不同的方法可以解决这个问题。
        /// 你可以使用空间复杂度为 O(1) 的 原地 算法解决这个问题吗？
        /// 示例 1:
        /// 输入: nums = [1,2,3,4,5,6,7], k = 3
        /// 输出: [5,6,7,1,2,3,4]
        /// 解释:
        /// 向右旋转 1 步: [7,1,2,3,4,5,6]
        /// 向右旋转 2 步: [6,7,1,2,3,4,5]
        /// 向右旋转 3 步: [5,6,7,1,2,3,4]
        /// 示例 2:
        /// 输入：nums = [-1,-100,3,99], k = 2
        /// 输出：[3,99,-1,-100]
        /// 解释: 
        /// 向右旋转 1 步: [99,-1,-100,3]
        /// 向右旋转 2 步: [3,99,-1,-100]
        /// 提示：
        /// 1 <= nums.length <= 2 * 104
        /// -231 <= nums[i] <= 231 - 1
        /// 0 <= k <= 105
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int[] b = RotateArr2(arr, 3);
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
            Rotate(arr, 0, arr.Length - 1);// 7 6 5 4 3 2 1
            Rotate(arr, 0, num - 1);// 5 6 7 4 3 2 1 
            Rotate(arr, num, arr.Length - 1); // 5 6 7 1 2 3 4 
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
