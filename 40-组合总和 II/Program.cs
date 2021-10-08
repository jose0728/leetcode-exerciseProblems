using System;
using System.Collections.Generic;

namespace _40_组合总和_II
{
    class Program
    {
        /// <summary>
        /// 第 39 题：candidates 中的数字可以无限制重复被选取；
        /// 第 40 题：candidates 中的每个数字在每个组合中只能使用一次。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var a = CombinationSum(new int[] { 2, 3, 5 }, 8);
        }

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var length = candidates.Length;
            IList<IList<int>> res = new List<IList<int>>();

            if (length == 0)
                return res;

            // 关键步骤
            Array.Sort(candidates);

            Stack<int> path = new Stack<int>();
            Dfs(candidates, target, 0, length, res, path);
            return res;
        }
        private static void Dfs(int[] candidates, int target, int begin, int length, IList<IList<int>> res, Stack<int> path)
        {
            // target 为负数和 0 的时候不再产生新的孩子结点
            if (target < 0)
            {
                return;
            }
            if (target == 0)
            {
                res.Add(new List<int>(path));
                return;
            }

            for (int i = begin; i < length; i++)
            {
                // 大剪枝：减去 candidates[i] 小于 0，减去后面的 candidates[i + 1]、candidates[i + 2] 肯定也小于 0，因此用 break
                if (target - candidates[i] < 0)
                {
                    break;
                }

                // 小剪枝：同一层相同数值的结点，从第 2 个开始，候选数更少，结果一定发生重复，因此跳过，用 continue
                if (i > begin && candidates[i] == candidates[i - 1])
                {
                    continue;
                }

                path.Push(candidates[i]);
                // 因为元素不可以重复使用，这里递归传递下去的是 i + 1 而不是 i
                Dfs(candidates, target - candidates[i], i + 1, length, res, path);
                path.Pop();
            }
        }
    }
}
