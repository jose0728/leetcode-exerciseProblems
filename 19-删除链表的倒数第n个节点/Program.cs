using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class ListNode
    {
        public string val;
        public ListNode next;
        public ListNode(string val = "header", ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class ListDemo
    {
        public ListNode header;  //头结点
        public ListDemo()
        {
            header = new ListNode();  //构造头结点
        }

        /// <summary>
        /// 查找某一节点
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public ListNode Find(string str)
        {
            ListNode current = header;
            while (current != null && current.val != str)
            {
                //如果当前节点不为空
                current = current.next;
            }
            return current;  //返回当前节点
        }

        /// <summary>
        /// 查找某一节点的上一个节点
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private ListNode FindPre(string str)
        {
            ListNode current = header;
            while (current.next != null && current.next.val != str)
            {
                //如果当前节点不为空
                current = current.next;
            }
            return current;  //返回当前节点
        }

        /// <summary>
        /// 打印链表
        /// </summary>
        public void Print()
        {
            //ListNode current = header;//打印首元结点
            ListNode current = header.next;
            while (current != null)
            {
                Console.WriteLine(current.val);
                current = current.next;
            }
        }

        /// <summary>
        /// 在after数据后面插入data
        /// </summary>
        /// <param name="str"></param>
        /// <param name="after"></param>
        public void Insert(string data, string after)
        {
            ListNode afterListNode = Find(after);
            if (afterListNode == null)
            {
                Console.WriteLine("没有找到前节点,无法完成插入操作");
                return;
            }

            ListNode needToInsert = new ListNode(data);
            needToInsert.next = afterListNode.next;
            afterListNode.next = needToInsert;

        }

        /// <summary>
        /// 移除某个节点
        /// </summary>
        /// <param name="data"></param>
        public void Remove(string data)
        {
            ListNode preListNode = FindPre(data);
            if (preListNode == null)
            {
                Console.WriteLine("没有找到前节点,无法完成移除操作");
                return;
            }

            preListNode.next = preListNode.next.next;
        }

        /// <summary>
        /// 反转链表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public void ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return;
            }

            ListNode p1 = head;
            ListNode p2 = head.next;
            ListNode p3 = null;

            while (p2 != null)
            {
                p3 = p2.next;
                p2.next = p1;
                p1 = p2;
                p2 = p3;
            }
            head.next = null;
            header.next = p1;
        }

        /// <summary>
        /// 单向链表的中间节点（快慢指针法）
        /// </summary>
        /// <param name="L"></param>
        public void GetMidListNode(ListNode L)
        {
            ListNode fast = L, slow = L;
            while (fast != null)
            {
                if (fast.next == null)
                {
                    break;
                }
                fast = fast.next.next;
                slow = slow.next;
            }
            Console.WriteLine("中间节点" + slow.val);
        }
    }

}
