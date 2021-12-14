using System;
using System.Collections.Generic;
using System.Text;

namespace RBTree
{
    public class RBTree<T> where T : IComparable<T>//where 指定T从IComparable<T>继承
    {
        public class TreeNode
        {
            /// <summary>
            /// 数据值
            /// </summary>
            public T data;
            /// <summary>
            /// 左子树
            /// </summary>
            public TreeNode left;
            /// <summary>
            /// 右子树
            /// </summary>
            public TreeNode right;
            /// <summary>
            /// 父节点
            /// </summary>
            public TreeNode parent;
            /// <summary>
            /// 节点颜色
            /// </summary>
            public Color color;

            public TreeNode(T data)
            {
                this.data = data;
                this.color = Color.RED;
            }
        }
        public enum Color
        {
            BLACK, RED
        }

        /// <summary>
        /// 根节点
        /// </summary>
        private TreeNode root;

        /// <summary>
        /// 向树中插入数据
        /// </summary>
        public void Add(T element)
        {
            TreeNode treeNode = new TreeNode(element);
            Insert(treeNode);
        }

        /// <summary>
        /// 插入节点
        /// </summary>
        /// <param name="node"></param>
        public void Insert(TreeNode node)
        {
            if (root == null)
            {
                //树中无元素，则将插入元素当做根结点
                root = node;
                root.parent = null;
                root.left = null;
                root.right = null;
                root.color = Color.BLACK;//根节点必是黑色
                return;
            }

            //按二叉查找树的方式将该节点插入
            TreeNode comNode = root;
            while (comNode != null)
            {
                if (comNode.data.CompareTo(node.data) >= 0)
                {
                    if (comNode.left == null)
                    {
                        comNode.left = node;
                        break;
                    }
                    else
                    {
                        comNode = comNode.left;
                    }
                }
                else
                {
                    if (comNode.right == null)
                    {
                        comNode.right = node;
                        break;
                    }
                    else
                    {
                        comNode = comNode.right;
                    }
                }
            }

            node.parent = comNode;
            //当前新插入且非根节点初始必为红色
            node.color = Color.RED;
            node.left = null;
            node.right = null;
            //插入节点后，将红黑树进行变换，使其继续符合红黑树的性质
            DoAddBalance(node);
        }

        /// <summary>
        /// 添加时进行的红黑树性质匹配操作
        /// </summary>
        /// <param name="node">新插入的节点</param>
        private void DoAddBalance(TreeNode node)
        {
            TreeNode currentNode = node;
            //祖父节点
            TreeNode grandP;
            //叔叔节点
            TreeNode uncle;
            //当且仅当新插入节点的父节点为红色时，重新调整红黑树的平衡
            while (currentNode.parent != null && currentNode.parent.color == Color.RED)
            {
                grandP = currentNode.parent.parent;

                //当前节点的祖父节点的左孩子是当前节点的父亲节点
                if (grandP.left == currentNode.parent)
                {
                    uncle = currentNode.parent.parent.right;

                    //叔叔节点是黑色
                    if (uncle == null || uncle.color == Color.BLACK)
                    {
                        //当前节点是右孩子
                        if (currentNode.parent.right == currentNode)
                        {
                            //以当前节点父亲节点为新的当前节点
                            currentNode = currentNode.parent;
                            //对新的当前节点进行左旋
                            LeftRotate(currentNode);
                        }
                        //当前节点是左孩子
                        else if (currentNode.parent.left == currentNode)
                        {
                            //将当前节点的父节点设置为黑色
                            currentNode.parent.color = Color.BLACK;
                            //将当前节点的祖父节点设置为红色
                            grandP.color = Color.RED;
                            //对当前节点的祖父节点进行右旋
                            RightRotate(grandP);
                        }
                    }
                    //叔叔节点是红色
                    else
                    {
                        //(01) 将“父节点”设为黑色。
                        currentNode.parent.color = Color.BLACK;
                        //(02) 将“叔叔节点”设为黑色。
                        uncle.color = Color.BLACK;
                        //(03) 如果祖父节点不是根节点，将“祖父节点”设为“红色”。
                        if (grandP.parent != null)
                        {
                            grandP.color = Color.RED;
                        }
                        //(04) 将“祖父节点”设为“当前节点”(红色节点)
                        currentNode = grandP;
                    }
                }
                //当前节点的祖父节点的右孩子是当前节点的父亲节点
                else if (grandP.right == currentNode.parent)
                {
                    uncle = currentNode.parent.parent.left;
                    //叔叔节点是黑色
                    if (uncle == null || uncle.color == Color.BLACK)
                    {
                        //当前节点是左孩子
                        if (currentNode.parent.left == currentNode)
                        {
                            //以当前节点父亲节点为新的当前节点
                            currentNode = currentNode.parent;
                            //对新的当前节点进行右旋
                            RightRotate(currentNode);
                        }
                        //当前节点是右孩子
                        else if (currentNode.parent.right == currentNode)
                        {
                            //将当前节点的父节点设置为黑色
                            currentNode.parent.color = Color.BLACK;
                            //将当前节点的祖父节点设置为红色
                            grandP.color = Color.RED;
                            //对当前节点的祖父节点进行左旋
                            LeftRotate(grandP);
                        }
                    }
                    //叔叔节点是红色
                    else
                    {
                        //同上边处理方式相同
                        currentNode.parent.color = Color.BLACK;
                        uncle.color = Color.BLACK;
                        if (grandP.parent != null)
                        {
                            grandP.color = Color.RED;
                        }
                        currentNode = grandP;
                    }
                }
            }
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="element"></param>
        public void Delete(T element)
        {
            TreeNode treeNode = new TreeNode(element);
            Delete(treeNode);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="node"></param>
        public void Delete(TreeNode node)
        {
            //找到要删除的节点
            TreeNode needDelete = null;
            TreeNode currentNode = root;
            while (currentNode != null)
            {
                if (currentNode.data.CompareTo(node.data) == 0)
                {
                    needDelete = currentNode;
                    break;
                }
                else if (currentNode.data.CompareTo(node.data) > 0)
                {
                    currentNode = currentNode.left;
                }
                else
                {
                    currentNode = currentNode.right;
                }
            }
            if (needDelete != null)
            {
                DoDelete(needDelete);
            }
        }

        /// <summary>
        /// 执行删除
        /// </summary>
        /// <param name="node"></param>
        private void DoDelete(TreeNode node)
        {
            TreeNode currentNode;//要替换的节点
            TreeNode needDelete = node;//要删除的节点

            //先进行二叉排序树的删除操作，找到要进行替换的节点
            //待删除节点左右子树都不为null
            if (node.left != null && node.right != null)
            {
                //寻找该节点的后继节点（找左儿子的最右子树）
                TreeNode succed = node.left;
                while (succed.right != null)
                {
                    succed = succed.right;
                }
                //将原删除节点的值替换为其后继节点的值，将后继节点作为待删除节点
                node.data = succed.data;
                needDelete = succed;
            }

            currentNode = needDelete.left != null ? needDelete.left : needDelete.right;
            if (currentNode != null)
            {
                currentNode.parent = needDelete.parent;//删除待删除节点，并用其子节点代替
                if (needDelete.left == currentNode)
                {
                    currentNode.parent.left = currentNode;
                }
                else
                {
                    currentNode.parent.right = currentNode;
                }
                needDelete.left = needDelete.right = needDelete.parent = null;
                if (needDelete.color == Color.BLACK)
                {
                    DoDeleteBalance(node);
                }
            }
            else if (needDelete.parent == null)
            {
                //说明当前是根节点
                root = null;
            }
            else
            {
                //说明待删除节点是个叶子节点
                currentNode = needDelete;//将自己作为替换节点，同时自己也是待删除节点
                if (needDelete.color == Color.BLACK)
                {
                    DoDeleteBalance(currentNode);
                }
                //平衡之后，将其删除
                if (currentNode.parent != null)
                {
                    if (currentNode.parent.left == currentNode)
                    {
                        currentNode.parent.left = null;
                    }
                    else if (currentNode.parent.right == currentNode)
                    {
                        currentNode.parent.right = null;
                    }
                    currentNode.parent = null;
                }
            }
        }

        /// <summary>
        /// 删除时进行的红黑树性质匹配操作
        /// </summary>
        /// <param name="node"></param>
        public void DoDeleteBalance(TreeNode node)
        {
            TreeNode currentNode = node;
            while (currentNode != null)
            {
                //当前节点为红色，直接涂黑处理
                if (currentNode.color == Color.RED)
                {
                    currentNode.color = Color.BLACK;
                    return;
                }
                //当前节点为黑色，需要分情况处理
                else
                {
                    //根节点，不做处理
                    if (currentNode.parent == null) return;
                    //当前节点的兄弟节点
                    TreeNode brother;
                    //获取当前节点的兄弟节点
                    brother = GetBrother(currentNode);
                    //被删节点是其父节点的左孩子
                    if (node.parent.left == node)
                    {
                        //若当前节点的兄弟节点为红色
                        if (brother.color == Color.RED)
                        {
                            //将当前节点的父节点变为红色
                            currentNode.parent.color = Color.RED;
                            //将当前节点的兄弟节点置黑
                            brother.color = Color.BLACK;
                            //将当前节点的父节点左旋
                            LeftRotate(currentNode.parent);
                        }
                        //若当前节点的兄弟节点为黑色
                        else if (brother.color == Color.BLACK)
                        {
                            //兄弟节点的左右孩子都是黑色
                            if ((brother.left == null || brother.left.color == Color.BLACK) && (brother.right == null || brother.right.color == Color.BLACK))
                            {
                                //当前节点的兄弟节点颜色变为红色
                                brother.color = Color.RED;
                                //将父节点设置为当前节点
                                currentNode = currentNode.parent;
                            }
                            //兄弟节点的右孩子是红色
                            else if (brother.right != null && brother.right.color == Color.RED)
                            {
                                //将兄弟节点颜色置为当前节点父节点颜色
                                brother.color = currentNode.parent.color;
                                //当前节点父节点置黑
                                currentNode.parent.color = Color.BLACK;
                                //兄弟节点右孩子置黑
                                brother.right.color = Color.BLACK;
                                //以当前节点父节点为支点左旋
                                LeftRotate(currentNode.parent);
                                return;
                            }
                            //兄弟节点的左孩子是红色，右孩子是黑色
                            else if ((brother.left != null && brother.left.color == Color.RED) && (brother.right == null || brother.right.color == Color.BLACK))
                            {
                                //将兄弟节点的左孩子变为黑色
                                brother.left.color = Color.BLACK;
                                //兄弟节点变为红色
                                brother.color = Color.RED;
                                //将兄弟节点右旋
                                RightRotate(brother);
                            }
                        }
                    }
                    //被删节点是其父节点的右孩子
                    else if (node.parent.right == node)
                    {
                        //若当前节点的兄弟节点为红色
                        if (brother.color == Color.RED)
                        {
                            //将当前节点的父节点变为红色
                            currentNode.parent.color = Color.RED;
                            //将当前节点的兄弟节点置黑
                            brother.color = Color.BLACK;
                            //将当前节点的父节点右旋
                            RightRotate(currentNode.parent);
                        }
                        //若当前节点的兄弟节点为黑色
                        else if (brother.color == Color.BLACK)
                        {
                            //兄弟节点的左右孩子都是黑色
                            if ((brother.left == null || brother.left.color == Color.BLACK) && (brother.right == null || brother.right.color == Color.BLACK))
                            {
                                //当前节点的兄弟节点颜色变为红色
                                //将父节点设置为当前节点
                                brother.color = Color.RED;
                                currentNode = currentNode.parent;
                            }
                            //兄弟节点的左孩子是红色
                            else if (brother.left != null && brother.left.color == Color.RED)
                            {
                                //将兄弟节点颜色置为当前节点父节点颜色
                                brother.color = currentNode.parent.color;
                                //当前节点父节点置黑
                                currentNode.parent.color = Color.BLACK;
                                //兄弟节点左孩子置黑
                                brother.left.color = Color.BLACK;
                                //以当前节点父节点为支点右旋
                                RightRotate(currentNode.parent);
                                return;
                            }
                            //兄弟节点的右孩子是红色，左孩子是黑色
                            else if ((brother.right != null && brother.right.color == Color.RED) && (brother.left == null || brother.left.color == Color.BLACK))
                            {
                                //将兄弟节点的右孩子变为黑色
                                brother.right.color = Color.BLACK;
                                //兄弟节点变为红色
                                brother.color = Color.RED;
                                //将兄弟节点右旋
                                LeftRotate(brother);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取当前节点的兄弟节点
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public TreeNode GetBrother(TreeNode node)
        {
            if (node.parent.left != node)
            {
                //重新设置X的兄弟节点
                return node.parent.left;
            }
            else
            {
                return node.parent.right;
            }
        }

        /// <summary>
        /// 左旋操作
        /// </summary>
        /// <param name="node">要左旋的节点</param>
        private void LeftRotate(TreeNode node)
        {
            TreeNode newNode = node.right;
            node.right = newNode.left;

            if (newNode.left != null)
            {
                newNode.left.parent = node;
            }

            //将node的父亲设置为newNode的父亲
            newNode.parent = node.parent;

            //node是根节点
            if (node.parent == null)
            {
                root = newNode;
            }
            //node不是根节点
            else
            {
                //node是其父节点的左孩子
                if (node.parent.left == node)
                {
                    node.parent.left = newNode;
                }
                //node是其父节点的右孩子
                else if (node.parent.right == node)
                {
                    node.parent.right = newNode;
                }
            }

            //将newNode设置成node的父亲
            node.parent = newNode;
            //将node设置为newNode的左孩子
            newNode.left = node;
        }

        /// <summary>
        /// 右旋操作
        /// </summary>
        /// <param name="node">要右旋的节点</param>
        private void RightRotate(TreeNode node)
        {
            TreeNode newNode = node.left;
            node.left = newNode.right;
            if (newNode.right != null)
            {
                newNode.right.parent = node;
            }
            newNode.parent = node.parent;
            if (node.parent == null)
            {
                root = newNode;
            }
            else
            {
                if (node.parent.left == node)
                {
                    node.parent.left = newNode;
                }
                else if (node.parent.right == node)
                {
                    node.parent.right = newNode;
                }
            }
            node.parent = newNode;
            newNode.right = node;
        }
    }
}
