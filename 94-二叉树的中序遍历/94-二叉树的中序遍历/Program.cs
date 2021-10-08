using System;
using System.Collections.Generic;

namespace _94_二叉树的中序遍历
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

    class Program
    {
        static void Main(string[] args)
        {

        }


        /// <summary>
        /// 递归方式
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal(TreeNode root)
        {
            IList<int> res = new List<int>();
            Inorder(root, res);
            return res;
        }

        public static void Inorder(TreeNode root, IList<int> res)
        {
            if (root == null)
            {
                return;
            }
            Inorder(root.left, res);
            res.Add(root.val);
            Inorder(root.right, res);
        }

        /// <summary>
        /// 中序遍历 迭代法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal2(TreeNode root)
        {
            IList<int> res = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (root != null || stack.Count > 0)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                res.Add(root.val);
                root = root.right;
            }

            return res;

        }

        /// <summary>
        /// 前序遍历 迭代法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> PreInorderTraversal(TreeNode root)
        {
            IList<int> res = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (root != null || stack.Count > 0)
            {
                while (root != null)
                {
                    res.Add(root.val);
                    stack.Push(root);
                    root = root.left;
                }

                var cur = stack.Pop();
                root = cur.right;
            }

            return res;
        }

        /// <summary>
        /// 后序遍历 迭代法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> BackInorderTraversal(TreeNode root)
        {
            IList<int> res = new List<int>();
            List<int> tmp = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (root != null || stack.Count > 0)
            {
                while (root != null)
                {
                    tmp.Add(root.val);
                    stack.Push(root);
                    root = root.right;
                }

                var node = stack.Pop();
                root = node.left;
            }
            tmp.Reverse();
            res = tmp;
            return res;
        }
    }
}
