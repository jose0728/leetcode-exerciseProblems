using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _146_LCU缓存机制
{
    public class LRUCache
    {
        class DLinkedNode
        {
            public int key;
            public int value;
            public DLinkedNode prev;
            public DLinkedNode next;
            public DLinkedNode() { }
            public DLinkedNode(int _key, int _value) { key = _key; value = _value; }
        }

        private Dictionary<int, DLinkedNode> cache = new Dictionary<int, DLinkedNode>();
        private int size;
        private int capacity;
        private DLinkedNode head, tail;

        public LRUCache(int capacity)
        {
            this.size = 0;
            this.capacity = capacity;
            // 使用伪头部和伪尾部节点
            head = new DLinkedNode();
            tail = new DLinkedNode();
            head.next = tail;
            tail.prev = head;
        }

        public int get(int key)
        {
            if (cache.ContainsKey(key))
            {
                DLinkedNode node = cache[key];
                // 如果 key 存在，先通过哈希表定位，再移到头部
                moveToHead(node);
                return node.value;
            }
            else
            {
                return -1;
            }
        }

        public void put(int key, int value)
        {          
            if (!cache.ContainsKey(key))
            {
                // 如果 key 不存在，创建一个新的节点
                DLinkedNode newNode = new DLinkedNode(key, value);
                // 添加进哈希表
                cache.Add(key, newNode);
                // 添加至双向链表的头部
                addToHead(newNode);
                ++size;
                if (size > capacity)
                {
                    // 如果超出容量，删除双向链表的尾部节点
                    DLinkedNode tail = removeTail();
                    // 删除哈希表中对应的项
                    cache.Remove(tail.key);
                    --size;
                }
            }
            else
            {
                DLinkedNode node = cache[key];
                // 如果 key 存在，先通过哈希表定位，再修改 value，并移到头部
                node.value = value;
                moveToHead(node);
            }
        }

        private void addToHead(DLinkedNode node)
        {
            node.prev = head;
            node.next = head.next;
            head.next.prev = node;
            head.next = node;
        }

        private void removeNode(DLinkedNode node)
        {
            node.prev.next = node.next;
            node.next.prev = node.prev;
        }

        private void moveToHead(DLinkedNode node)
        {
            removeNode(node);
            addToHead(node);
        }

        private DLinkedNode removeTail()
        {
            DLinkedNode res = tail.prev;
            removeNode(res);
            return res;
        }
    }
}
