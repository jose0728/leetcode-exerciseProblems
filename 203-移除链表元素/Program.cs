using System;

namespace _203_移除链表元素
{

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

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
                return head;
            ListNode dummyHead = new ListNode(0);
            dummyHead.next = head;
            ListNode temp = dummyHead;
            while (temp.next != null)
            {
                if (temp.next.val == val)
                {
                    temp.next = temp.next.next;
                }
                else
                {
                    temp = temp.next;
                }
            }
            return dummyHead.next;
        }
    }
}
