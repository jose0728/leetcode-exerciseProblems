using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _881_救生艇
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] people = { 3, 2, 2, 1 };
            NumRescueBoats(people, 3);
        }

        /// <summary>
        /// 双指针法
        /// 我们首先需要让这些人根据体重进行排序。
        /// 同时维护两个指针，每次让最重的一名上船，同时让最轻的也上船。
        /// 因为最重的要么和最轻的一起上船。要么就无法配对，只能自己占用一艘船的资源
        /// </summary>
        /// <param name="people"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);
            int i = 0;
            int j = people.Length - 1;
            int ans = 0;
            while (i <= j)
            {
                ans++;
                if (people[i] + people[j] <= limit)
                {
                    i++;
                }
                j--;
            }
            return ans;
        }
    }
}
