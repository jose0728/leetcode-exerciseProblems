using System;
using System.Collections.Generic;

namespace _39_组合总和
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = CombinationSum(new int[] { 2, 3, 6, 7 }, 7);
        }

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var length = candidates.Length;
            IList<IList<int>> res = new List<IList<int>>();

            if (length == 0)
                return res;

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
                path.Push(candidates[i]);
                Dfs(candidates, target - candidates[i], i, length, res, path);
                path.Pop();
            }
        }
    }
}
