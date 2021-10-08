using System;
using System.Collections.Generic;

namespace _144_二叉树的前序遍历
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
            Console.WriteLine("Hello World!");
        }

        //前序遍历需要每次向左走之前就访问根结点
        //而中序遍历先压栈，在出栈的时候才访问
        //后序如果右子树为空或者已经访问过了才访问根结点。否则，需要将该结点再次压回栈中，去访问其右子树

        /// <summary>
        /// 前序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<int> PreorderTraversal(TreeNode root)
        {
            IList<int> res = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode node = root;

            while (node != null || stack.Count > 0)
            {
                if (node != null)
                {
                    res.Add(node.val);
                    stack.Push(node);
                    node = node.left;
                }
                else
                {
                    TreeNode cur = stack.Pop();
                    node = cur.right;
                }

            }
            return res;


        }

        /// <summary>
        /// 中序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<int> MideleorderTraversal(TreeNode root)
        {
            IList<int> res = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode node = root;

            while (node != null || stack.Count > 0)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }
                else
                {
                    TreeNode cur = stack.Pop();
                    res.Add(cur.val);
                    node = cur.right;
                }
            }
            return res;
        }

        /// <summary>
        /// 后序遍历
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<int> HouorderTraversal(TreeNode root)
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
