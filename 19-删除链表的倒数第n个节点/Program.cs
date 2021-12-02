using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 链表;

namespace _19_删除链表的倒数第n个节点
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDemo list = new ListDemo();
            list.Insert("jiajia1", "header");
            list.Insert("jiajia2", "jiajia1");
            list.Insert("jiajia3", "jiajia2");
            list.Insert("jiajia4", "jiajia3");
            list.Insert("jiajia5", "jiajia4");
            list.Print();
            Console.WriteLine("=============================");
            RemoveNthFromEnd(list.header, 2);
            list.Print();
            Console.ReadKey();
        }

        /// <summary>
        /// 双指针法
        /// 慢slow、快fast
        /// 用两个指针对链表进行遍历，fast比slow快n个节点，当fast到达链表末尾，second就是倒数第n个节点
        /// 初始情况：两个指针都指向头节点,fast先遍历，遍历n次，这时，两个指针相距n-1个节点，即fast比slow超前n个节点
        /// 加入哨兵节点，初始slow指向哨兵节点，当fast到达末尾时，slow指向的节点正好是我们要删除的节点的前一个节点
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode("0", head);//哨兵节点
            ListNode fast = head;
            ListNode slow = dummy;
            for (int i = 0; i < n; i++)
            {
                fast = fast.next;
            }
            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }
            slow.next = slow.next.next;
            ListNode ans = dummy.next;
            return ans;
        }

    }

}
