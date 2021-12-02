using System;
using System.Collections.Generic;
using 二叉树;

namespace _104_二叉树的最大深度
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
            int a = DepthFirstSearch(tree);
            int b = BreadFirstSearch(tree);
            int d = MaxDepth2(tree);
        }

        /// <summary>
        /// DFS求二叉树的最大深度（leetcode104题）
        /// </summary>
        /// <param name="root"></param>
        public static int DepthFirstSearch(Tree<int> root)
        {
            if (root == null)
                return 0;
            Stack<Tree<int>> stack = new Stack<Tree<int>>();
            Stack<int> level = new Stack<int>();
            stack.Push(root);
            level.Push(1);
            int max = 0;

            Tree<int> node = null;
            while (stack.Count > 0)
            {
                node = stack.Pop();
                int temp = level.Pop();
                max = Math.Max(temp, max);
                Console.WriteLine(node.NodeData);
                if (node.RightTree != null)
                {
                    stack.Push(node.RightTree);//先将右子树压栈
                    level.Push(temp + 1);
                }
                if (node.LeftTree != null)
                {
                    stack.Push(node.LeftTree);//再将左子树压栈
                    level.Push(temp + 1);
                }
            }
            return max;
        }

        /// <summary>
        /// BFS求二叉树的最大深度（leetcode104题）
        /// </summary>
        /// <param name="root"></param>
        public static int BreadFirstSearch(Tree<int> root)
        {
            if (root == null)
                return 0;
            Queue<Tree<int>> queue = new Queue<Tree<int>>();
            queue.Enqueue(root);
            int count = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                while (size-- > 0)
                {
                    Tree<int> cur = queue.Dequeue();
                    if (cur.LeftTree != null)
                    {
                        queue.Enqueue(cur.LeftTree);//先将左子树入队
                    }
                    if (cur.RightTree != null)
                    {
                        queue.Enqueue(cur.RightTree);//再将右子树入队
                    }
                }
                count++;
            }
            return count;
        }

        /// <summary>
        ///  递归求二叉树的最大深度（leetcode104题）
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MaxDepth2(Tree<int> root)
        {
            if (root == null)
                return 0;
            int leftDepth = MaxDepth2(root.LeftTree);
            int rightDepth = MaxDepth2(root.RightTree);
            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}
