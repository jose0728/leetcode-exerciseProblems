using System;
using 二叉树;

namespace _222_完全二叉树的节点个数
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
            var a = CountNodes2(tree);
        }

        /// <summary>
        /// 完全二叉树的节点个数（leetcode222题）
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int CountNodes(Tree<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            return CountNodes(root.LeftTree) + CountNodes(root.RightTree) + 1;
        }

        /// <summary>
        /// 完全二叉树的节点个数（leetcode222题）
        /// 利用完全二叉树的特点
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int CountNodes2(Tree<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            int left = CountLevel(root.LeftTree);
            int right = CountLevel(root.RightTree);
            if (left == right)
            {
                //<< 左移n位就是乘以2的n次方了(有符号数不完全适用,因为左移有可能导致符号变化
                return CountNodes2(root.RightTree) + (1 << left);
            }
            else
            {
                return CountNodes2(root.LeftTree) + (1 << right);
            }
        }

        /// <summary>
        /// 上一个方法的改进-利用c#自带函数
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int CountNodes3(Tree<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            int left = CountLevel(root.LeftTree);
            int right = CountLevel(root.RightTree);
            if (left == right)
            {
                return CountNodes3(root.RightTree) + (int)Math.Pow(2, left);
            }
            else
            {
                return CountNodes3(root.LeftTree) + (int)Math.Pow(2, right);
            }
        }

        private static int CountLevel(Tree<int> root)
        {
            int level = 0;
            while (root != null)
            {
                level++;
                root = root.LeftTree;
            }
            return level;
        }
    }
}
