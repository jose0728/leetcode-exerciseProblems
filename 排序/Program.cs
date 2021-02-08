using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序
{
    class Program
    {
        static void Main(string[] args)
        {
            //堆排序
            HeapSort heapSort = new HeapSort();
            heapSort.TestHeapSort();
        }
    }
}
