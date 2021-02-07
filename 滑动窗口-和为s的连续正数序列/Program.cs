using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 滑动窗口_和为s的连续正数序列
{
    class Program
    {
        /// <summary>
        /// 输入一个正整数 target ，输出所有和为 target 的连续正整数序列（至少含有两个数）。
        /// 序列内的数字由小到大排列，不同序列按照首个数字从小到大排列。
        /// 输入：target = 9
        /// 输出：[[2,3,4],[4,5]]
        /// 输入：target = 15
        /// 输出：[[1,2,3,4,5],[4,5,6],[7,8]]
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int target = 9;
            int[][] b = FindContinuousSequence(target);
        }

        /// <summary>
        /// 滑动窗口
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[][] FindContinuousSequence(int target)
        {
            List<int[]> res = new List<int[]>();
            int i = 1;
            int j = 1;
            int win = 0;

            //对于任意一个正整数，总是小于它的中值与中值+1的和
            //一旦窗口左边界超过中值，窗口内的和一定会大于 target
            while (i <= target / 2)
            {
                if (win < target)
                {
                    win += j;
                    j++;
                }
                else if (win > target)
                {
                    win -= i;
                    i++;
                }
                else
                {
                    int[] arr = new int[j - i];
                    for (int k = i; k < j; k++)
                    {
                        arr[k - i] = k;
                    }
                    res.Add(arr);
                    win -= i;
                    i++;
                }
            }
            return res.ToArray();
        }
    }
}
