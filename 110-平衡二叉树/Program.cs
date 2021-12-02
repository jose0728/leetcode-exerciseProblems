using System;
using 二叉树;

namespace _110_平衡二叉树
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(10);
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(20);
            tree.Insert(15);
            tree.Insert(21);
            var a = IsBalanced(tree);
        }

        /// <summary>
        /// 平衡二叉树（leetcode110题）
        /// 左右两个子树的高度差的绝对值不超过1
        /// 左右两个子树都是一棵平衡二叉树
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsBalanced(Tree<int> root)
        {
            // 它是一棵空树
            if (root == null)
            {
                return true;
            }
            return Math.Abs(MaxDepth(root.LeftTree) - MaxDepth(root.RightTree)) <= 1 && IsBalanced(root.LeftTree) && IsBalanced(root.RightTree);
        }

        /// <summary>
        ///  递归求二叉树的最大深度
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MaxDepth(Tree<int> root)
        {
            if (root == null)
                return 0;
            int leftDepth = MaxDepth(root.LeftTree);
            int rightDepth = MaxDepth(root.RightTree);
            return Math.Max(leftDepth, rightDepth) + 1;
        }

    }
}
