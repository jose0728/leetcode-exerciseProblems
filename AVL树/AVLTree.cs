using System;
using System.Collections.Generic;
using System.Text;

namespace AVL树
{

    public class AVLTree<T> where T : IComparable<T>//where 指定T从IComparable<T>继承
    {
        public class TreeNode
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

        /// <summary>
        /// 根节点
        /// </summary>
        private TreeNode root;

        /// <summary>
        /// 向树中插入数据
        /// </summary>
        public TreeNode Add(T element)
        {
            return root = Insert(element, root);
        }

        /// <summary>
        /// 删除树中值为element的元素
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public TreeNode Delete(T element)
        {
            return root = Remove(element, root);
        }

        /// <summary>
        /// 前序遍历树
        /// </summary>
        public void Print()
        {
            Print(root);
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
        /// 右旋转（LLL的情况）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TreeNode RightRotate(TreeNode node)
        {
            TreeNode newNode = node.left;
            node.left = newNode.right;
            newNode.right = node;

            CalcHeight(node);
            CalcHeight(newNode);

            return newNode;
        }

        /// <summary>
        /// 左旋转（RRR的情况）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TreeNode LeftRotate(TreeNode node)
        {
            TreeNode newNode = node.right;
            node.right = newNode.left;
            newNode.left = node;

            CalcHeight(node);
            CalcHeight(newNode);

            return newNode;
        }

        /// <summary>
        /// 先左后右（LLR的情况）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TreeNode LeftAndRightRotate(TreeNode node)
        {
            node.left = LeftRotate(node.left);
            return RightRotate(node);
        }

        /// <summary>
        /// 先右后左（RRL的情况）
        /// </summary>
        /// <param name="node">要旋转的子树的根结点</param>
        /// <returns>旋转后的子树的根结点</returns>
        private TreeNode RightAndLeftRotate(TreeNode node)
        {
            node.right = RightRotate(node.right);
            return LeftRotate(node);
        }

        /// <summary>
        /// 让以node为根结点的树恢复平衡
        /// </summary>
        /// <param name="node">根结点</param>
        /// <returns>恢复平衡后的树的根结点</returns>
        private TreeNode Balance(TreeNode node)
        {
            //assert node != null;
            if (GetHeight(node.left) - GetHeight(node.right) == 2)
            {
                if (GetHeight(node.left.left) > GetHeight(node.left.right))//判断是不是左左型
                {
                    // 需要进行右旋转
                    return RightRotate(node);
                }
                else
                {
                    // 需要左旋再右旋
                    return LeftAndRightRotate(node);
                }
            }
            else if (GetHeight(node.right) - GetHeight(node.left) == 2)
            {
                if (GetHeight(node.right.right) > GetHeight(node.right.left))
                {
                    // 需要进行左旋转
                    return LeftRotate(node);
                }
                else
                {
                    // 需要右旋再左旋
                    return RightAndLeftRotate(node);
                }
            }
            return node;
        }

        /// <summary>
        /// 向树中插入数据
        /// </summary>
        /// <param name="element">数据的值</param>
        /// <param name="node">树的根结点</param>
        /// <returns></returns>
        private TreeNode Insert(T element, TreeNode node)
        {
            if (node == null)
            {
                return new TreeNode(element);
            }

            if (element.CompareTo(node.data) < 0)
            {
                node.left = Insert(element, node.left);
            }
            else if (element.CompareTo(node.data) > 0)
            {
                node.right = Insert(element, node.right);
            }

            CalcHeight(node);
            return Balance(node);
        }

        /// <summary>
        /// 删除树中的元素
        /// </summary>
        /// <param name="element">要删除的元素值</param>
        /// <param name="node">树的根结点</param>
        /// <returns>删除后的树根结点</returns>
        private TreeNode Remove(T element, TreeNode node)
        {
            if (node == null || (node.left == null && node.right == null))
            {
                return null;
            }

            if (element.CompareTo(node.data) < 0)
            {
                node.left = Remove(element, node.left);
            }
            else if (element.CompareTo(node.data) > 0)
            {
                node.right = Remove(element, node.right);
            }
            else
            {
                if (node.right == null)
                {
                    // 右空左不空
                    node = node.left;
                }
                else if (node.left == null)
                {
                    // 左空右不空
                    node = node.right;
                }
                else
                {
                    //左右都不空，则取出右子树最小结点，并用来替换根结点
                    TreeNode rightMin = SearchMin(node.right);
                    node.data = rightMin.data;
                    node.right = Remove(rightMin.data, node.right);
                }
            }
            CalcHeight(node);
            return Balance(node);
        }

        private TreeNode SearchMin(TreeNode node)
        {
            //assert node != null;

            if (node.left != null)
            {
                return SearchMin(node.left);
            }
            return node;
        }

        /// <summary>
        /// 打印以node为树根的树
        /// </summary>
        /// <param name="node">树根</param>
        private void Print(TreeNode node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine(node.data + " , height = " + node.height);
            Print(node.left);
            Print(node.right);
        }

        /// <summary>
        /// 计算树的高度
        /// </summary>
        /// <param name="node"></param>
        private void CalcHeight(TreeNode node)
        {
            node.height = Math.Max(GetHeight(node.left), GetHeight(node.right)) + 1;
        }
    }
}
