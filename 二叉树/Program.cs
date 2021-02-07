using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>(10);
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(6);
            tree.Insert(20);
            tree.Insert(15);
            //tree.Insert(21);
            //Tree<int> tree = new Tree<int>(1);
            //tree.Insert(2);
            tree.WideOrderTree();
            int a = DepthFirstSearch(tree);
            int b = BreadFirstSearch(tree);
            int d = MaxDepth2(tree);
            var e = BreadFirstSearch2(tree);
            var f = IsValidBST(tree);
            var g = IsValidBST2(tree);
            //var h = DeleteNode(tree, 15);
            var i = CountNodes22(tree);
            Console.ReadKey();
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

        /// <summary>
        /// 验证二叉搜索树（leetcode98题）
        /// 搜索二叉树中序遍历后的二叉树为递增序列
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        static Tree<int> pre;
        public static bool IsValidBST(Tree<int> root)
        {
            if (root == null)
            {
                return true;
            }
            // 访问左子树
            if (!IsValidBST(root.LeftTree))
            {
                return false;
            }
            // 访问当前节点：如果当前节点小于等于中序遍历的前一个节点，说明不满足BST，返回 false；否则继续遍历。
            if (pre != null && root.NodeData <= pre.NodeData)
            {
                return false;
            }
            pre = root;
            // 访问右子树
            if (!IsValidBST(root.RightTree))
                return false;
            return true;
        }

        /// <summary>
        /// 验证二叉搜索树方法2（leetcode98题）
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsValidBST2(Tree<int> root)
        {
            return IsValidBST2(root, long.MinValue, long.MaxValue);
        }

        public static bool IsValidBST2(Tree<int> root, long minVal, long maxVal)
        {
            if (root == null)
                return true;
            //每个节点如果超过这个范围，直接返回false
            if (root.NodeData >= maxVal || root.NodeData <= minVal)
                return false;
            //这里再分别以左右两个子节点分别判断，
            //左子树范围的最小值是minVal，最大值是当前节点的值，也就是root的值，因为左子树的值要比当前节点小
            //右子数范围的最大值是maxVal，最小值是当前节点的值，也就是root的值，因为右子树的值要比当前节点大
            return IsValidBST2(root.LeftTree, minVal, root.NodeData) && IsValidBST2(root.RightTree, root.NodeData, maxVal);
        }

        /// <summary>
        /// 二叉搜索树中的搜索（leetcode700题）
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static Tree<int> SearchBST(Tree<int> root, int val)
        {
            if (root == null)
                return null;
            if (root.NodeData > val)
                return SearchBST(root.LeftTree, val);
            else if (root.NodeData < val)
                return SearchBST(root.RightTree, val);
            else
                return root;
        }

        /// <summary>
        /// 二叉搜索树中的搜索（leetcode700题）
        /// 迭代
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static Tree<int> SearchBST2(Tree<int> root, int val)
        {
            while (root != null)
            {
                if (root.NodeData == val)
                {
                    return root;
                }
                else if (root.NodeData > val)
                {
                    root = root.LeftTree;
                }
                else
                {
                    root = root.RightTree;
                }
            }
            return null;
        }

        /// <summary>
        /// 删除二叉搜索树中的节点（leetcode450题）
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Tree<int> DeleteNode(Tree<int> root, int key)
        {
            if (root == null)
            {
                return null;
            }
            //当前节点值比key小，则需要删除当前节点的左子树中key对应的值，并保证二叉搜索树的性质不变
            if (key < root.NodeData)
            {
                root.LeftTree = DeleteNode(root.LeftTree, key);
            }
            //当前节点值比key大，则需要删除当前节点的右子树中key对应的值，并保证二叉搜索树的性质不变
            else if (key > root.NodeData)
            {
                root.RightTree = DeleteNode(root.RightTree, key);
            }
            //当前节点等于key，则需要删除当前节点，并保证二叉搜索树的性质不变
            else
            {
                //当前节点没有左子树
                if (root.LeftTree == null)
                {
                    return root.RightTree;
                }
                //当前节点没有右子树
                else if (root.RightTree == null)
                {
                    return root.LeftTree;
                }
                //当前节点既有左子树又有右子树
                else
                {
                    Tree<int> node = root.RightTree;
                    //找到当前节点右子树最左边的叶子结点
                    while (node.LeftTree != null)
                    {
                        node = node.LeftTree;
                    }
                    //将root的左子树放到root的右子树的最下面的左叶子节点的左子树上
                    node.LeftTree = root.LeftTree;
                    return root.RightTree;
                }
            }
            return root;
        }

        /// <summary>
        /// 平衡二叉树（leetcode110题）
        /// 一棵高度平衡二叉树定义为：
        /// 一个二叉树每个节点的左右两个子树的高度差的绝对值不超过 1 。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsBalanced(Tree<int> root)
        {
            //它是一棵空树
            if (root == null)
            {
                return true;
            }
            //它的左右两个子树的高度差的绝对值不超过1
            int leftDepth = MaxDepth2(root.LeftTree);
            int rightDepth = MaxDepth2(root.RightTree);
            if (Math.Abs(leftDepth - rightDepth) > 1)
            {
                return false;
            }
            //左右两个子树都是一棵平衡二叉树
            return IsBalanced(root.LeftTree) && IsBalanced(root.RightTree);
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
                return CountNodes2(root.RightTree) + (1 << left);
            }
            else
            {
                return CountNodes2(root.LeftTree) + (1 << right);
            }
        }

        public static int CountNodes22(Tree<int> root)
        {
            if (root == null)
            {
                return 0;
            }
            int left = CountLevel(root.LeftTree);
            int right = CountLevel(root.RightTree);
            if (left == right)
            {
                return CountNodes22(root.RightTree) + (int)Math.Pow(2, left);
            }
            else
            {
                return CountNodes22(root.LeftTree) + (int)Math.Pow(2, right);
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
