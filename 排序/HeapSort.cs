using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序
{
    /// <summary>
    /// 堆排序
    /// </summary>
    public class HeapSort
    {
        public void TestHeapSort()
        {
            int[] arr = { 9, 6, 7, 5, 8, 4, 3, 2, 1 };
            Sort(arr);
            Console.WriteLine(arr.ToString());
        }

        public void Sort(int[] arr)
        {
            //1.构建大顶堆
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                AdjustHeap(arr, i, arr.Length);
            }

            //2.调整堆结构+交换堆顶元素与末尾元素
            for (int j = arr.Length - 1; j > 0; j--)
            {
                Swap(arr, 0, j);//将堆顶元素与末尾元素进行交换
                AdjustHeap(arr, 0, j);//重新对堆进行调整
            }
        }

        /// <summary>
        /// 调整大顶堆
        /// 仅仅是调整过程，建立在大顶堆已构建的基础上
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="length"></param>
        public void AdjustHeap(int[] arr, int i, int length)
        {
            int temp = arr[i];//先取出当前元素i
            for (int k = i * 2 + 1; k < length; k = k * 2 + 1)
            {
                //从i结点的左子结点开始，也就是2i+1处开始
                if (k + 1 < length && arr[k] < arr[k + 1])
                {
                    //如果左子结点小于右子结点，k指向右子结点
                    k++;
                }
                if (arr[k] > temp)
                {
                    //如果子节点大于父节点，将子节点值赋给父节点（不用进行交换）
                    arr[i] = arr[k];
                    i = k;
                }
                else
                {
                    break;
                }
            }
            arr[i] = temp;//将temp值放到最终的位置
        }

        /// <summary>
        /// 交换元素
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
