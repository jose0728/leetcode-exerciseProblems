using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _239_滑动窗口的最大值
{
    class Program
    {
        /// <summary>
        /// 给定一个数组 nums，有一个大小为 k 的滑动窗口从数组的最左侧移动到数组的最右侧。
        /// 你只可以看到在滑动窗口内的 k 个数字。滑动窗口每次只向右移动一位。返回滑动窗口中的最大值。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] a = { 1, 3, -1, -3, 5, 3, 6, 7 };
            int[] b = MaxSlidingWindow(a, 3);
        }

        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            int n = nums.Length;
            int[] res = new int[n - k + 1];
            LinkedList<int> dq = new LinkedList<int>();
            for (int i = 0; i < n; i++)
            {
                if (dq.Count != 0 && dq.First.Value < (i - k + 1))
                {
                    dq.RemoveFirst();//超出窗口长度时删除队首
                }
                while (dq.Count != 0 && nums[i] >= nums[dq.Last.Value])
                {
                    dq.RemoveLast();//如果遍历的元素大于队尾元素就删除队尾
                }
                dq.AddLast(i);//添加
                if (i >= k - 1)
                {
                    res[i - k + 1] = nums[dq.First.Value];//结果
                }
            }
            return res;
        }
    }
}
