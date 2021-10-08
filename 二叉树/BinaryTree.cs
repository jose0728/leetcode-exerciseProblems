using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 二叉树
{
    public class BinaryTree
    {
    }

    public class Tree<T> where T : IComparable<T>//where 指定T从IComparable<T>继承
    {
        /// <summary>
        /// 定义二叉树
        /// </summary>
        private T data;
        private Tree<T> left;
        private Tree<T> right;
        /// <summary>
        /// 构造函数：定义二叉树的根节点
        /// </summary>
        /// <param name="nodeValue">二叉树的根节点</param>
        public Tree(T nodeValue)
        {
            this.data = nodeValue;
            this.left = null;
            this.right = null;
        }
        /// <summary>
        /// 数据节点属性
        /// </summary>
        public T NodeData
        {
            get { return this.data; }
            set { this.data = value; }
        }
        /// <summary>
        /// 左子树
        /// </summary>
        public Tree<T> LeftTree
        {
            get { return this.left; }
            set { this.left = value; }
        }
        /// <summary>
        /// 右子树
        /// </summary>
        public Tree<T> RightTree
        {
            get { return this.right; }
            set { this.right = value; }
        }

        /// <summary>
        /// 向二叉树中插入一个节点
        /// 存储思想，凡是小于该结点值的数据全部都在该节点的左子树中，凡是大于该结点结点值的数据全部在该节点的右子树中
        /// </summary>
        /// <param name="newItem"></param>
        public void Insert(T newItem)
        {
            T currentNodeValue = this.NodeData;
            if (currentNodeValue.CompareTo(newItem) > 0)
            {
                if (this.LeftTree == null)
                {
                    this.LeftTree = new Tree<T>(newItem);
                }
                else
                {
                    this.LeftTree.Insert(newItem);
                }
            }
            else
            {
                if (this.RightTree == null)
                {
                    this.RightTree = new Tree<T>(newItem);
                }
                else
                {
                    this.RightTree.Insert(newItem);
                }
            }
        }

        /// <summary>
        /// 前序遍历：先跟节点然后左子树，右子树
        /// </summary>
        /// <param name="root"></param>
        public void PreOrderTree(Tree<T> root)
        {
            if (root != null)
            {
                Console.Write(root.NodeData);
                PreOrderTree(root.LeftTree);
                PreOrderTree(root.RightTree);
            }
        }
        /// <summary>
        /// 中序遍历：左子树，根节点，右子树可以实现顺序输出
        /// </summary>
        /// <param name="root"></param>
        public void InOrderTree(Tree<T> root)
        {
            if (root != null)
            {
                InOrderTree(root.LeftTree);
                Console.Write(root.NodeData);
                InOrderTree(root.RightTree);
            }
        }
        /// <summary>
        /// 后序遍历：左子树，右子树，根节点
        /// </summary>
        /// <param name="root"></param>
        public void PostOrderTree(Tree<T> root)
        {
            if (root != null)
            {
                PostOrderTree(root.LeftTree);
                PostOrderTree(root.RightTree);
                Console.Write(root.NodeData);
            }
        }
        /// <summary>
        /// 逐层遍历：遍历思想是从根节点开始，访问一个节点然后将其左右子树的根节点依次放入链表中，然后删除该节点。
        /// 依次遍历直到链表中的元素数量为0即没有更下一层的节点出现时候为止。
        /// </summary>
        public void WideOrderTree()
        {
            List<Tree<T>> nodeList = new List<Tree<T>>();
            nodeList.Add(this);
            Tree<T> temp = null;
            while (nodeList.Count > 0)
            {
                Console.Write(nodeList[0].NodeData + " ");
                temp = nodeList[0];
                nodeList.Remove(nodeList[0]);
                if (temp.LeftTree != null)
                {
                    nodeList.Add(temp.LeftTree);
                }
                if (temp.RightTree != null)
                {
                    nodeList.Add(temp.RightTree);
                }
            }
            Console.WriteLine();
        }
    }
}
