using System;
using System.Collections.Generic;

namespace _160_相交链表
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 哈希法
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;

            HashSet<ListNode> list = new HashSet<ListNode>();
            ListNode node = headA;
            while (node != null)
            {
                list.Add(node);
                node = node.next;
            }

            node = headB;

            while (node != null)
            {
                if (list.Contains(node))
                    return node;
                node = node.next;
            }

            return null;
        }

        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public static ListNode GetIntersectionNode2(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;

            ListNode head1 = headA;
            ListNode head2 = headB;
            while (head1 != head2)
            {
                if (head1 != null)
                    head1 = head1.next;
                else
                    head1 = headB;

                if (head2 != null)
                    head2 = head2.next;
                else
                    head2 = headA;
            }
            return head1;
        }
    }
}
