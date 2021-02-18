using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 排序
{
    /// <summary>
    /// 基数排序
    /// </summary>
    public class RadixSort
    {
        public void TestRadixSort()
        {
            int[] arr = { 73, 22, 93, 43, 55, 14, 28, 65, 39, 81 };
            Sort(arr);
            Console.WriteLine(arr.ToString());
        }

        public int[] Sort(int[] sourceArray)
        {
            // 对 arr 进行拷贝，不改变参数内容
            int[] arr = new int[sourceArray.Length];
            Array.Copy(sourceArray, arr, sourceArray.Length);

            int maxDigit = getMaxDigit(arr);
            return radixSort(arr, maxDigit);
        }

        private int getMaxDigit(int[] arr)
        {
            int maxValue = getMaxValue(arr);
            return getNumLenght(maxValue);
        }

        private int getMaxValue(int[] arr)
        {
            int maxValue = arr[0];
            foreach (int value in arr)
            {
                if (maxValue < value)
                {
                    maxValue = value;
                }
            }
            return maxValue;
        }

        protected int getNumLenght(long num)
        {
            if (num == 0)
            {
                return 1;
            }
            int lenght = 0;
            for (long temp = num; temp != 0; temp /= 10)
            {
                lenght++;
            }
            return lenght;
        }

        private int[] radixSort(int[] arr, int maxDigit)
        {
            int mod = 10;
            int dev = 1;

            for (int i = 0; i < maxDigit; i++, dev *= 10, mod *= 10)
            {
                // 考虑负数的情况，这里扩展一倍队列数，其中 [0-9]对应负数，[10-19]对应正数 (bucket + 10)
                int[][] counter = new int[mod * 2][];

                for (int j = 0; j < arr.Length; j++)
                {
                    int bucket = ((arr[j] % mod) / dev) + mod;
                    counter[bucket] = arrayAppend2(counter[bucket], arr[j]);
                }

                int pos = 0;
                foreach (int[] bucket in counter)
                {
                    if (bucket == null)
                        continue;
                    foreach (int value in bucket)
                    {
                        arr[pos++] = value;
                    }
                }
            }

            return arr;
        }

        /// <summary>
        /// 数组扩容
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private int[] arrayAppend(int[] arr, int value)
        {
            int[] dstArray = null;
            if (arr == null)
            {
                arr = new int[1];
                dstArray = new int[1];
            }
            else
            {
                dstArray = new int[arr.Length + 1];
            }
            Array.Copy(arr, dstArray, arr.Length);
            dstArray[dstArray.Length - 1] = value;
            return dstArray;
        }

        /// <summary>
        /// 数组扩容方法2
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private int[] arrayAppend2(int[] arr, int value)
        {
            if (arr == null)
                arr = new int[1];
            else
                Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = value;
            return arr;
        }
    }
}
