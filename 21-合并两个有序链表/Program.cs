using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 链表;

namespace _21_合并两个有序链表
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDemo list1 = new ListDemo();
            list1.Insert("1", "header");
            list1.Insert("3", "1");
            list1.Insert("5", "3");
            list1.Insert("7", "5");
            list1.Insert("9", "7");
            list1.Print();

            ListDemo list2 = new ListDemo();
            list2.Insert("2", "header");
            list2.Insert("4", "2");
            list2.Insert("6", "4");
            list2.Insert("8", "6");
            list2.Insert("10", "8");
            list2.Insert("12", "10");
            list2.Print();

            var header = MergeTwoLists(list1.header, list2.header);
            PrintNode(header);

            Console.ReadKey();
        }

        /// <summary>
        /// 迭代+哨兵节点
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            Queue 
            ListNode prehead = new ListNode("header", null);
            ListNode prev = prehead;
            ListNode newL1 = l1.next;
            ListNode newL2 = l2.next;
            while (newL1 != null && newL2 != null)
            {
                if (int.Parse(newL1.val) <= int.Parse(newL2.val))
                {
                    prev.next = newL1;
                    newL1 = newL1.next;
                }
                else
                {
                    prev.next = newL2;
                    newL2 = newL2.next;
                }
                prev = prev.next;
            }
            prev.next = newL1 == null ? newL2 : newL1;
            return prehead;
        }

        public static void PrintNode(ListNode header)
        {
            //ListNode current = header;//打印首元结点
            ListNode current = header.next;
            while (current != null)
            {
                Console.WriteLine(current.val);
                current = current.next;
            }
        }
    }
}
