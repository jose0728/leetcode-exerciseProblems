using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _679_24点游戏
{
    class Program
    {
        static int TARGET = 24;
        static double EPSILON = 1e-6;
        static int ADD = 0, MULTIPLY = 1, SUBTRACT = 2, DIVIDE = 3;

        static void Main(string[] args)
        {
            int[] a = { 4, 1, 8, 7 };
            var b = JudgePoint24(a);
        }

        /// <summary>
        /// 24 点游戏
        /// 回溯
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool JudgePoint24(int[] nums)
        {
            List<double> list = new List<double>();
            foreach (int num in nums)
            {
                list.Add((double)num);
            }
            return Solve(list);
        }

        public static bool Solve(List<Double> list)
        {
            if (list.Count() == 0)
            {
                return false;
            }
            if (list.Count() == 1)
            {
                return Math.Abs(list.ElementAt(0) - TARGET) < EPSILON;
            }
            int size = list.Count();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i != j)
                    {
                        List<double> list2 = new List<double>();
                        for (int k = 0; k < size; k++)
                        {
                            if (k != i && k != j)
                            {
                                list2.Add(list.ElementAt(k));
                            }
                        }
                        for (int k = 0; k < 4; k++)
                        {
                            if (k < 2 && i > j)
                            {
                                continue;
                            }
                            if (k == ADD)
                            {
                                list2.Add(list.ElementAt(i) + list.ElementAt(j));
                            }
                            else if (k == MULTIPLY)
                            {
                                list2.Add(list.ElementAt(i) * list.ElementAt(j));
                            }
                            else if (k == SUBTRACT)
                            {
                                list2.Add(list.ElementAt(i) - list.ElementAt(j));
                            }
                            else if (k == DIVIDE)
                            {
                                if (Math.Abs(list.ElementAt(j)) < EPSILON)
                                {
                                    continue;
                                }
                                else
                                {
                                    list2.Add(list.ElementAt(i) / list.ElementAt(j));
                                }
                            }
                            if (Solve(list2))
                            {
                                return true;
                            }
                            list2.Remove(list2.Count() - 1);
                        }
                    }
                }
            }
            return false;
        }
    }
}
