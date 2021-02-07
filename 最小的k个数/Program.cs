using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 最小的k个数
{
    class Program
    {
        static void Main(string[] args)
        {
            Test6();
        }

        public static void TestPortal(string testName, int[] data, int[] expected, int k)
        {
            if (!string.IsNullOrEmpty(testName))
            {
                Console.WriteLine("{0} begins:", testName);
            }

            Console.WriteLine("Result for solution:");
            if (expected != null)
            {
                Console.WriteLine("Expected result:");
                for (int i = 0; i < expected.Length; i++)
                {
                    Console.Write("{0}\t", expected[i]);
                }
                Console.WriteLine();
            }

            if (data == null)
            {
                return;
            }

            List<int> dataList = new List<int>();
            for (int i = 0; i < data.Length; i++)
            {
                dataList.Add(data[i]);
            }
            SortedDictionary<int, int> leastNumbers = new SortedDictionary<int, int>();
            GetLeastNumbersByRedBlackTree(dataList, leastNumbers, k);
            Console.WriteLine("Actual result:");
            foreach (var item in leastNumbers)
            {
                Console.Write("{0}\t", item.Value);
            }
            Console.WriteLine("\n");
        }

        // k小于数组的长度
        public static void Test1()
        {
            int[] data = { 4, 5, 1, 6, 2, 7, 3, 8 };
            int[] expected = { 1, 2, 3, 4 };
            TestPortal("Test1", data, expected, expected.Length);
        }

        // k等于数组的长度
        public static void Test2()
        {
            int[] data = { 4, 5, 1, 6, 2, 7, 3, 8 };
            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };
            TestPortal("Test2", data, expected, expected.Length);
        }

        // k大于数组的长度
        public static void Test3()
        {
            int[] data = { 4, 5, 1, 6, 2, 7, 3, 8 };
            int[] expected = null;
            TestPortal("Test3", data, expected, 10);
        }

        // k等于1
        public static void Test4()
        {
            int[] data = { 4, 5, 1, 6, 2, 7, 3, 8 };
            int[] expected = { 1 };
            TestPortal("Test4", data, expected, expected.Length);
        }

        // k等于0
        public static void Test5()
        {
            int[] data = { 4, 5, 1, 6, 2, 7, 3, 8 };
            int[] expected = null;
            TestPortal("Test5", data, expected, 0);
        }

        // 数组中有相同的数字
        public static void Test6()
        {
            int[] data = { 4, 5, 1, 6, 2, 7, 2, 8 };
            int[] expected = { 1, 2 };
            TestPortal("Test6", data, expected, expected.Length);
        }

        // 输入空指针
        public static void Test7()
        {
            TestPortal("Test7", null, null, 0);
        }

        public static void GetLeastNumbersByRedBlackTree(List<int> data, SortedDictionary<int, int> leastNumbers, int k)
        {
            leastNumbers.Clear();

            if (k < 1 || data.Count < k)
            {
                return;
            }

            for (int i = 0; i < data.Count; i++)
            {
                int num = data[i];
                if (leastNumbers.Count < k)
                {
                    leastNumbers.Add(num, num);
                }
                else
                {
                    int greastNum = leastNumbers.ElementAt(leastNumbers.Count - 1).Value;
                    if (num < greastNum)
                    {
                        leastNumbers.Remove(greastNum);
                        leastNumbers.Add(num, num);
                    }
                }
            }
        }
    }
}
