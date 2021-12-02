using System;
using System.Collections.Generic;

namespace _100_相同的树
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 深度
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            else if (p == null || q == null)
            {
                return false;
            }
            else if (p.val != q.val)
            {
                return false;
            }
            else
            {
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            }
        }

        /// <summary>
        /// 广度
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsSameTree2(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            else if (p == null || q == null)
            {
                return false;
            }
            Queue<TreeNode> queue1 = new Queue<TreeNode>();
            Queue<TreeNode> queue2 = new Queue<TreeNode>();
            queue1.Enqueue(p);
            queue2.Enqueue(q);
            while (queue1.Count > 0 && queue2.Count > 0)
            {
                TreeNode node1 = queue1.Dequeue();
                TreeNode node2 = queue2.Dequeue();
                if (node1.val != node2.val)
                {
                    return false;
                }
                TreeNode left1 = node1.left, right1 = node1.right, left2 = node2.left, right2 = node2.right;
                //对于 bool 操作数，^ 将计算操作数的逻辑“异或”；也就是说，当且仅当只有一个操作数为 true 时，结果才为 true
                if (left1 == null ^ left2 == null)
                {
                    return false;
                }
                if (right1 == null ^ right2 == null)
                {
                    return false;
                }
                if (left1 != null)
                {
                    queue1.Enqueue(left1);
                }
                if (right1 != null)
                {
                    queue1.Enqueue(right1);
                }
                if (left2 != null)
                {
                    queue2.Enqueue(left2);
                }
                if (right2 != null)
                {
                    queue2.Enqueue(right2);
                }
            }
            return queue1.Count == 0 && queue2.Count == 0;
        }
    }

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
}
