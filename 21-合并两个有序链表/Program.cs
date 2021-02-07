using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
