﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 最大堆
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxBinaryHeap<int> heap = new MaxBinaryHeap<int>();
            heap.Enqueue(8);
            heap.Enqueue(2);
            heap.Enqueue(3);
            heap.Enqueue(6);
            heap.Enqueue(5);
            heap.Enqueue(7);
            heap.Enqueue(8);
            heap.Enqueue(1);
            heap.Enqueue(4);
            Console.WriteLine(heap.Dequeue());
            Console.WriteLine(heap.Dequeue());

            Console.ReadLine();
        }
    }

    public class MaxBinaryHeap<T>
    {
        private const int DEFAULT_CAPACITY = 6;
        public int mCount;
        public T[] mItems;
        private Comparer<T> mComparer;

        public MaxBinaryHeap() : this(DEFAULT_CAPACITY) { }

        public MaxBinaryHeap(int capacity)
        {
            if (capacity < 0)
            {
                throw new IndexOutOfRangeException();
            }
            mItems = new T[capacity];
            mComparer = Comparer<T>.Default;
        }

        /// <summary>
        /// 调整堆的容量
        /// </summary>
        /// <param name="newSize"></param>
        private void ResizeItemStore(int newSize)
        {
            if (mCount > newSize || DEFAULT_CAPACITY > newSize)
            {
                return;
            }

            T[] tmp = new T[newSize];
            Array.Copy(mItems, 0, tmp, 0, mCount);
            mItems = tmp;
        }

        /// <summary>
        /// 从后往前依次对各结点为根的子树进行筛选，使之成为堆，直到根结点
        /// </summary>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private int BubbleUp(int startIndex)
        {
            while (startIndex > 0)
            {
                int parent = (startIndex - 1) / 2;
                if (mComparer.Compare(mItems[startIndex], mItems[parent]) > 0)
                {
                    T tmp = mItems[startIndex];
                    mItems[startIndex] = mItems[parent];
                    mItems[parent] = tmp;
                }
                else
                {
                    break;
                }
                startIndex = parent;
            }
            return startIndex;
        }

        /// <summary>
        /// 从后往前依次对各结点为根的子树进行筛选，使之成为堆，直到根结点
        /// </summary>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private void BubbleDown()
        {
            int parent = 0;
            int leftChild = (parent * 2) + 1;
            while (leftChild < mCount)
            {
                // 找到子节点中较小的那个
                int rightChild = leftChild + 1;
                int bestChild = (rightChild < mCount && mComparer.Compare(mItems[rightChild], mItems[leftChild]) > 0) ? rightChild : leftChild;
                if (mComparer.Compare(mItems[bestChild], mItems[parent]) > 0)
                {
                    T tmp = mItems[bestChild];
                    mItems[bestChild] = mItems[parent];
                    mItems[parent] = tmp;
                }
                else
                {
                    break;
                }
                parent = bestChild;
                leftChild = (parent * 2) + 1;
            }
        }


        public void Clear()
        {
            mCount = 0;
            mItems = new T[DEFAULT_CAPACITY];
        }

        private void ShrinkStore()
        {
            // 如果容量不足一半以上，默认容量会下降。
            if (mItems.Length > DEFAULT_CAPACITY && mCount < (mItems.Length >> 1))
            {
                int newSize = Math.Max(
                    DEFAULT_CAPACITY, (((mCount / DEFAULT_CAPACITY) + 1) * DEFAULT_CAPACITY));

                ResizeItemStore(newSize);
            }
        }

        /// <summary>
        /// 增加元素到堆，并从后往前依次对各结点为根的子树进行筛选，使之成为堆，直到根结点
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Enqueue(T value)
        {
            if (mCount == mItems.Length)
            {
                ResizeItemStore(mItems.Length * 2);
            }

            mItems[mCount++] = value;
            int position = BubbleUp(mCount - 1);

            return (position == 0);
        }

        /// <summary>
        /// 取出堆的最大值
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            return Dequeue(true);
        }

        private T Dequeue(bool shrink)
        {
            if (mCount == 0)
            {
                throw new InvalidOperationException();
            }

            T result = mItems[0];
            if (mCount == 1)
            {
                mCount = 0;
                mItems[0] = default(T);
            }
            else
            {
                --mCount;
                //取序列最后的元素放在堆顶
                mItems[0] = mItems[mCount];
                mItems[mCount] = default(T);
                // 维护堆的结构
                BubbleDown();
            }
            if (shrink)
            {
                ShrinkStore();
            }
            return result;
        }

    }
}
