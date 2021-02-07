using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _905_按奇偶排序数组
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 3, 1, 2, 4 };
            int[] b = SortArrayByParity2(a);
        }

        public static int[] SortArrayByParity(int[] A)
        {
            int j = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    int tmp = A[i];
                    A[i] = A[j];
                    A[j] = tmp;
                    j++;
                }
            }
            return A;
        }

        /// <summary>
        /// 双指针
        /// 头尾双指针
        /// 如果头指针当前元素是偶数，指针直接后移，找到第一个奇数为止
        /// 如果尾指针当前元素是奇数，指针直接前移，找到第一个偶数为止
        /// 然后交换两个数的位置。继续循环遍历
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int[] SortArrayByParity2(int[] A)
        {
            int i = 0;
            int j = A.Length - 1;
            while (i < j)
            {
                while (i < j && A[i] % 2 == 0)
                {
                    i++;
                }
                while (i < j && A[j] % 2 != 0)
                {
                    j--;
                }
                int tmp = A[i];
                A[i] = A[j];
                A[j] = tmp;
                i++;
                j--;
            }
            return A;
        }
    }
}
