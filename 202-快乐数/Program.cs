using System;
using System.Collections.Generic;

namespace _202_快乐数
{
    class Program
    {
        /// <summary>
        /// 编写一个算法来判断一个数 n 是不是快乐数。
        /// 「快乐数」定义为：
        /// 对于一个正整数，每一次将该数替换为它每个位置上的数字的平方和
        /// 然后重复这个过程直到这个数变为 1，也可能是 无限循环 但始终变不到 1。
        /// 如果 可以变为  1，那么这个数就是快乐数。
        /// 如果 n 是快乐数就返回 true ；不是，则返回 false 。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var a = IsHappy2(19);
        }

        public static bool IsHappy(int n)
        {
            HashSet<int> numberSet = new HashSet<int>();
            while (n != 1)
            {
                double temp = 0;
                while (n > 0)
                {
                    temp += Math.Pow(n % 10, 2);
                    n = n / 10;
                }
                if (numberSet.Contains((int)temp))
                    return false;
                else
                    numberSet.Add((int)temp);
                n = (int)temp;
            }
            return true;
        }

        /// <summary>
        /// 快慢指针
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsHappy2(int n)
        {
            int slowRunner = n;
            int fastRunner = GetNext(n);
            while (fastRunner != 1 && slowRunner != fastRunner)
            {
                slowRunner = GetNext(slowRunner);
                fastRunner = GetNext(GetNext(fastRunner));
            }
            return fastRunner == 1;
        }

        public static int GetNext(int n)
        {
            double totalSum = 0;

            while (n > 0)
            {
                double temp = 0;
                temp += Math.Pow(n % 10, 2);
                n = n / 10;
                totalSum += temp;
            }
            return (int)totalSum;
        }
    }
}
