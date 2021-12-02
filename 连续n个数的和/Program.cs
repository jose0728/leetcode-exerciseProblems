using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 连续n个数的和
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = SumNums(4);
        }


        /// <summary>
        /// 连续n个数的和
        /// 求 1 2 ... n ，要求不能使用乘除法、for、while、if、else、switch、case等关键字及条件判断语句（A?B:C）。
        /// </summary>
        /// &&短路代替递归
        /// <param name="n"></param>
        /// <returns></returns>
        public static int SumNums(int n)
        {
            Console.WriteLine("开始：" + n);
            bool a = n > 0 && (n += SumNums(n - 1)) > 0;
            Console.WriteLine("结束：" + n);
            return n;
        }

       
    }
}
