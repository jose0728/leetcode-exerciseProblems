using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _46_全排列
{
    class Program
    {
        /// <summary>
        /// 给定一个不含重复数字的数组 nums ，返回其 所有可能的全排列 。你可以 按任意顺序 返回答案。
        /// 示例 1：
        /// 输入：nums = [1,2,3]
        /// 输出：[[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
        /// 示例 2：
        /// 输入：nums = [0,1]
        /// 输出：[[0,1],[1,0]]
        /// 示例 3：
        /// 输入：nums = [1]
        /// 输出：[[1]]
        /// 提示：
        /// 1 <= nums.length <= 6
        /// -10 <= nums[i] <= 10
        /// nums 中的所有整数 互不相同
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3 };
            var b = Permutation(a);
            Console.ReadKey();
        }

        /// <summary>
        /// 回溯法
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> Permutation(int[] nums)
        {
            int len = nums.Length;
            // 使用一个动态数组保存所有可能的全排列
            IList<IList<int>> res = new List<IList<int>>();
            if (len == 0)
            {
                return res;
            }

            bool[] used = new bool[len];
            IList<int> path = new List<int>();

            Dfs(nums, len, 0, path, used, res);
            return res;
        }

        private static void Dfs(int[] nums, int len, int depth, IList<int> path, bool[] used, IList<IList<int>> res)
        {
            if (depth == len)
            {
                res.Add(new List<int>(path));
                return;
            }

            // 在非叶子结点处，产生不同的分支，这一操作的语义是：在还未选择的数中依次选择一个元素作为下一个位置的元素，这显然得通过一个循环实现。
            for (int i = 0; i < len; i++)
            {
                if (!used[i])
                {
                    path.Add(nums[i]);
                    used[i] = true;

                    Dfs(nums, len, depth + 1, path, used, res);
                    // 注意：下面这两行代码发生 「回溯」，回溯发生在从 深层结点 回到 浅层结点 的过程，代码在形式上和递归之前是对称的
                    used[i] = false;
                    path.RemoveAt(path.Count() - 1);
                }
            }
        }
    }
}
