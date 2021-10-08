using System;
using System.Collections.Generic;

namespace _111_二叉树的最小深度
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

    class QueueNode
    {
        public TreeNode node;
        public int depth;

        public QueueNode(TreeNode node, int depth)
        {
            this.node = node;
            this.depth = depth;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 深度优先搜索
        /// 对于每一个非叶子节点，我们只需要分别计算其左右子树的最小叶子节点深度。这样就将一个大问题转化为了小问题，可以递归地解决该问题。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            if (root.left == null && root.right == null)
                return 1;
            int min_depth = int.MaxValue;
            if (root.left != null)
            {
                min_depth = Math.Min(MinDepth(root.left), min_depth);
            }
            if (root.right != null)
            {
                min_depth = Math.Min(MinDepth(root.right), min_depth);
            }
            return min_depth + 1;
        }



        /// <summary>
        /// 广度优先搜索
        /// 当我们找到一个叶子节点时，直接返回这个叶子节点的深度。广度优先搜索的性质保证了最先搜索到的叶子节点的深度一定最小。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MinDepth2(TreeNode root)
        {
            if (root == null)
                return 0;
            Queue<QueueNode> queue = new Queue<QueueNode>();
            queue.Enqueue(new QueueNode(root, 1));

            while (queue.Count > 0)
            {
                QueueNode nodeDepth = queue.Dequeue();
                TreeNode node = nodeDepth.node;
                int depth = nodeDepth.depth;

                if (node.left == null && node.right == null)
                {
                    return depth;
                }
                if (node.left != null)
                {
                    queue.Enqueue(new QueueNode(node.left, depth + 1));
                }
                if (node.right != null)
                {
                    queue.Enqueue(new QueueNode(node.right, depth + 1));
                }
            }
            return 0;
        }
    }
}
