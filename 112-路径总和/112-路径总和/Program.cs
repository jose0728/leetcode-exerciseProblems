using System;
using System.Collections.Generic;

namespace _112_路径总和
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    /// <summary>
    /// 给你二叉树的根节点 root 和一个表示目标和的整数 targetSum ，
    /// 判断该树中是否存在 根节点到叶子节点 的路径，这条路径上所有节点值相加等于目标和 targetSum 。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 迭代
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }

            Queue<TreeNode> treeQueue = new Queue<TreeNode>();
            Queue<int> valQueue = new Queue<int>();

            treeQueue.Enqueue(root);
            valQueue.Enqueue(root.val);

            while (treeQueue.Count > 0)
            {
                var curNode = treeQueue.Dequeue();
                var tmpValue = valQueue.Dequeue();

                if (curNode.left == null && curNode.right == null)
                {
                    if (tmpValue == sum)
                    {
                        return true;
                    }
                    continue;
                }

                if (curNode.left != null)
                {
                    treeQueue.Enqueue(curNode.left);
                    valQueue.Enqueue(curNode.left.val + tmpValue);
                }

                if (curNode.right != null)
                {
                    treeQueue.Enqueue(curNode.right);
                    valQueue.Enqueue(curNode.right.val + tmpValue);
                }
            }
            return false;
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool HasPathSum2(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }

            if (root.left == null && root.right == null)
            {
                return root.val == sum;
            }

            return HasPathSum2(root.left, sum - root.val) || HasPathSum2(root.right, sum - root.val);
        }
    }
}
