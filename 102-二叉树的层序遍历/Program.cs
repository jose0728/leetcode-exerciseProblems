using System;
using System.Collections.Generic;
using 二叉树;

namespace _102_二叉树的层序遍历
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
            var e = BreadFirstSearch2(tree);
        }

        /// <summary>
        /// 二叉树的层序遍历（leetcode102题）
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<IList<int>> BreadFirstSearch2(Tree<int> root)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if (root == null)
                return list;

            Queue<Tree<int>> queue = new Queue<Tree<int>>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int size = queue.Count;
                IList<int> vs = new List<int>();
                while (size-- > 0)
                {
                    Tree<int> cur = queue.Dequeue();
                    vs.Add(cur.NodeData);
                    if (cur.LeftTree != null)
                    {
                        queue.Enqueue(cur.LeftTree);//先将左子树入队
                    }
                    if (cur.RightTree != null)
                    {
                        queue.Enqueue(cur.RightTree);//再将右子树入队
                    }
                }
                list.Add(vs);
            }
            return list;
        }
    }
}
