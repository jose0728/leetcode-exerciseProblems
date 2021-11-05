using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 最大堆;

namespace 优先队列
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// 利用最大堆实现优先队列
    /// </summary>
    public class PriorityQueue
    {
        private MaxBinaryHeap<int> maxHeap;

        public PriorityQueue()
        {
            maxHeap = new MaxBinaryHeap<int>();
        }

        public int GetSize()
        {
            return maxHeap.mCount;
        }

        public bool IsEmpty()
        {
            return maxHeap.mCount == 0;
        }

        public int GetFront()
        {
            return maxHeap.mItems[0];
        }

        public void Enqueue(int e)
        {
            maxHeap.Enqueue(e);
        }


        public int Dequeue()
        {
            return maxHeap.Dequeue();
        }
    }
}
