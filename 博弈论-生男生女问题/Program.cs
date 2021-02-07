using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 博弈论_生男生女问题
{
    class Program
    {
        static void Main(string[] args)
        {
            BobyBorn(10);
            Console.ReadKey();
        }

        ///错误-现在还未解出
        /// <summary>
        /// 生男生女问题
        /// 题目：说澳大利亚的父母喜欢女孩，如果生出来的第一个女孩，就不再生了，如果是男孩就继续生，
        /// 直到生到第一个女孩为止，问若干年后，男女的比例是多少？
        /// </summary>
        /// <param name="number"></param>
        private static void BobyBorn(int number)
        {
            int boys = 0;
            int girls = 0;

            for (int i = 0; i < number; i++)
            {
                Random rd = new Random();
                int num = rd.Next();
                int flag = num % 2;
                if (flag == 0) //女孩
                {
                    girls++;
                }
                if (flag == 1) //男孩
                {
                    boys++;
                    i--;
                }
            }
            Console.WriteLine("女孩：{0},男孩：{1},男女比例：{2}", girls, boys, (float)girls / (float)boys);
        }
    }
}
