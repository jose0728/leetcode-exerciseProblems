using System;
using System.Collections.Generic;

namespace _83_删除排序链表中的重复元素
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 删除排序链表中的重复元素 I
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return head;
            ListNode cur = head;
            while (cur.next != null)
            {
                if (cur.val == cur.next.val)
                    cur.next = cur.next.next;
                else
                    cur = cur.next;
            }
            return head;
        }

        /// <summary>
        /// 删除排序链表中的重复元素 II
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static ListNode DeleteDuplicates2(ListNode head)
        {
            if (head == null)
                return head;
            ListNode dummy = new ListNode(0, head);
            ListNode cur = dummy;
            while (cur.next != null && cur.next.next!=null)
            {
                if (cur.next.val == cur.next.next.val)
                {
                    int x = cur.next.val;
                    while (cur.next != null && cur.next.val == x)
                    {
                        cur.next = cur.next.next;
                    }
                }
                else
                    cur = cur.next;
            }
            return dummy.next;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
