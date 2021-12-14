using System;

namespace RBTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RBTree<int> tree = new RBTree<int>();
            //tree.Add(1);
            //tree.Add(2);
            //tree.Add(3);
            //tree.Add(4);
            //tree.Add(5);
            //tree.Add(6);
            //tree.Add(7);
            //tree.Add(8);

            tree.Add(15);
            tree.Add(9);
            tree.Add(10);
            tree.Add(20);
            tree.Add(8);
        }
    }
}
