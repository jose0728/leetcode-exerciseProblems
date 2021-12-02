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
            tree.Insert(21);

            //遍历
            tree.PreOrderTree(tree);
            tree.InOrderTree(tree);
            tree.PostOrderTree(tree);
            tree.WideOrderTree();
        }
    }
}
