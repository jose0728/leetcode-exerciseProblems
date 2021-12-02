using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 链表;

namespace 两数相加
{
    class Program
    {
        /// <summary>
        /// leetcode 2题
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            ListDemo list1 = new ListDemo();
            list1.Insert("1", "header");
            list1.Insert("3", "1");
            list1.Insert("5", "3");
            list1.Print();
            ListDemo list2 = new ListDemo();
            list2.Insert("2", "header");
            list2.Insert("4", "2");
            list2.Insert("6", "4");
            list2.Print();
            var header = AddTwoNumbers(list1.header, list2.header);
            PrintNode(header);
            Console.ReadKey();
        }

        public static ListNode AddTwoNumbers(ListNode L1, ListNode L2)
        {
            ListNode l1 = L1.next;
            ListNode l2 = L2.next;
            ListNode pre = new ListNode("header");
            ListNode cur = pre;
            int carry = 0;
            while (l1 != null || l2 != null)
            {
                int x = l1 == null ? 0 : int.Parse(l1.val);
                int y = l2 == null ? 0 : int.Parse(l2.val);
                int sum = x + y + carry;
                carry = sum / 10;
                sum = sum % 10;
                cur.next = new ListNode(sum.ToString());
                cur = cur.next;
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }
            if (carry == 1)
            {
                cur.next = new ListNode(carry.ToString());
            }
            return pre;
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
