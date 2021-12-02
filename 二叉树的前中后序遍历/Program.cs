using System;
using System.Collections.Generic;

namespace 二叉树的前中后序遍历
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
    /// leetcode144题：二叉树的前序遍历
    /// leetcode94题：二叉树的中序遍历
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

        }

        /// <summary>
        /// 递归方式中序遍历
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

        /// 迭代法：
        /// 前序遍历需要每次向左走之前就访问根结点
        /// 而中序遍历先压栈，在出栈的时候才访问
        /// 后序如果右子树为空或者已经访问过了才访问根结点。否则，需要将该结点再次压回栈中，去访问其右子树

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
        /// 后序遍历 迭代法
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> BackInorderTraversal(TreeNode root)
        {
            IList<int> res = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode preNode = null;

            while (root != null || stack.Count > 0)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                if (root.right == null || root.right == preNode)
                {
                    res.Add(root.val);
                    preNode = root;
                    root = null;
                }
                else
                {
                    stack.Push(root);
                    root = root.right;
                }
            }
            return res;
        }
    }
}
