using System;
using System.Collections.Generic;
using System.Text;

namespace AVL树
{

    public class AVLTree<T> where T : IComparable<T>//where 指定T从IComparable<T>继承
    {
        private class TreeNode
        {
            public T data;
            public TreeNode left;
            public TreeNode right;
            public int height;

            public TreeNode(T nodeValue)
            {
                this.data = nodeValue;
                this.left = null;
                this.right = null;
                this.height = 1;
            }
        }

        private TreeNode root;
        private int size;
        public AVLTree()
        {
            root = null;
            size = 0;
        }

        /// <summary>
        ///  获取某一结点的高度
        /// </summary>
        private int GetHeight(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return node.height;
        }

        public int GetSize()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        /// <summary>
        /// 获取节点的平衡因子
        /// </summary>
        private int GetBalanceFactor(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            return GetHeight(node.left) - GetHeight(node.right);
        }

        /// <summary>
        /// 判断是否是平衡二叉树
        /// 左右子树的高度差小于等于 1。
        /// 其每一个子树均为平衡二叉树。
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;
            int leftDepth = GetHeight(root.left);
            int rightDepth = GetHeight(root.right);
            return Math.Abs(leftDepth - rightDepth) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
        }

        /// <summary>
        /// 判断是否是平衡二叉树
        /// </summary>
        /// <returns></returns>
        public bool IsBalanced()
        {
            return IsBalanced(root);
        }

        /// <summary>
        /// 右旋转（LL的情况）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TreeNode RightRotate(TreeNode node)
        {
            TreeNode temp = node.left;
            node.left = temp.right;
            temp.right = node;

            node.height = Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;
            temp.height = Math.Max(GetHeight(temp.left), GetHeight(temp.right)) + 1;
            return temp;
        }

        /// <summary>
        /// 左旋转（RR的情况）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TreeNode LeftRotate(TreeNode node)
        {
            TreeNode temp = node.right;
            node.right = temp.left;
            temp.left = node;

            node.height = Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;
            temp.height = Math.Max(GetHeight(temp.left), GetHeight(temp.right)) + 1;
            return temp;
        }

        /// <summary>
        /// 先左后右（LLR的情况）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TreeNode LR(TreeNode node)
        {
            node.left = LeftRotate(node.left);
            return RightRotate(node);
        }

        /// <summary>
        /// 先右后左（RRL的情况）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TreeNode RL(TreeNode node)
        {
            node.right = RightRotate(node.right);
            return LeftRotate(node);
        }

    }
}
