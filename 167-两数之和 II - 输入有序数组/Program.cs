using System;

namespace _167_两数之和_II___输入有序数组
{
    class Program
    {
        /// <summary>
        /// 给定一个已按照 升序排列  的整数数组 numbers ，请你从数组中找出两个数满足相加之和等于目标数 target 。
        /// 函数应该以长度为 2 的整数数组的形式返回这两个数的下标值.
        /// numbers 的下标 从 1 开始计数 ，所以答案数组应当满足 1 <= answer[0] < answer[1] <= numbers.length 。
        /// 你可以假设每个输入只对应唯一的答案，而且你不可以重复使用相同的元素。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;
            while (left < right)
            {
                if (numbers[left] + numbers[right] < target)
                {
                    left++;
                }
                else if (numbers[left] + numbers[right] > target)
                {
                    right--;
                }
                else
                {
                    return new int[] { left + 1, right + 1 };
                }
            }
            return new int[] { -1, -1 };
        }

        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum2(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int low = i + 1, high = numbers.Length - 1;
                while (low <= high)
                {
                    int mid = (high - low) / 2 + low;
                    if (numbers[mid] == target - numbers[i])
                    {
                        return new int[] { i + 1, mid + 1 };
                    }
                    else if (numbers[mid] < target - numbers[i])
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }
            return new int[] { -1, -1 };
        }
    }
}
