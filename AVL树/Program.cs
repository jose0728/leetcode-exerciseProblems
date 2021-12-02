using System;

namespace AVL树
{
    public class Program
    {
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();
            tree.Add(3);
            tree.Add(2);
            tree.Add(1);
            tree.Add(4);
            tree.Add(5);
            tree.Add(6);
            tree.Add(7);
            tree.Add(10);
            tree.Add(9);
            tree.Add(8);

            //tree.Add(5);
            //tree.Add(4);
            //tree.Add(6);
            //tree.Add(2);
            //tree.Add(1);
            tree.Print();
            var isBalance = tree.IsBalanced();
            Console.WriteLine("=====================");
            tree.Delete(4);
            tree.Print();
        } 
    }
}
