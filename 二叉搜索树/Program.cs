using System;
using 二叉树;

namespace 二叉搜索树
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Tree<int> tree = new Tree<int>(10);

            program.Insert(5, tree);
            program.Insert(3, tree);
            program.Insert(6, tree);
            program.Insert(20, tree);
            program.Insert(15, tree);
            program.Insert(21, tree);

            var a = IsValidBST(tree);

            var b = IsValidBST2(tree);

            var c = program.MinDiffInBST(tree);

            var d = SearchBST2(tree, 5);

            var e = program.MinDiffInBST(tree);

            var f = DeleteNode(tree, 5);

            Console.ReadKey();
        }

        /// <summary>
        /// 向树中插入数据
        /// </summary>
        /// <param name="element">数据的值</param>
        /// <param name="node">树的根结点</param>
        /// <returns></returns>
        public Tree<int> Insert(int element, Tree<int> node)
        {
            if (node == null)
            {
                return new Tree<int>(element);
            }

            if (element.CompareTo(node.NodeData) < 0)
            {
                node.LeftTree = Insert(element, node.LeftTree);
            }
            else if (element.CompareTo(node.NodeData) > 0)
            {
                node.RightTree = Insert(element, node.RightTree);
            }

            return node;
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
        /// 删除二叉搜索树中的节点方法2（leetcode450题）
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
                    //取出右子树最小结点，并用来替换根结点
                    var rightMinNode = SearchMin(root.RightTree);
                    root.NodeData = rightMinNode.NodeData;
                    root.RightTree = DeleteNode(root.RightTree, rightMinNode.NodeData);
                }
            }
            return root;
        }

        /// <summary>
        /// 获取二叉搜索树的最小节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static Tree<int> SearchMin(Tree<int> node)
        {
            if (node.LeftTree != null)
            {
                return SearchMin(node.LeftTree);
            }
            return node;
        }

        /// <summary>
        /// 783. 二叉搜索树节点最小距离
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        int ans;
        Tree<int> preTree;
        public int MinDiffInBST(Tree<int> root)
        {
            ans = int.MaxValue;
            MinDiffDfsBST(root);
            return ans;
        }

        public void MinDiffDfsBST(Tree<int> root)
        {
            if (root == null)
            {
                return;
            }

            MinDiffDfsBST(root.LeftTree);

            if (preTree != null)
            {
                ans = Math.Min(ans, root.NodeData - preTree.NodeData);
            }

            preTree = root;

            MinDiffDfsBST(root.RightTree);
        }
    }
}
