using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_盛水最多的容器
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            var b = MaxArea(a);
        }

        /// <summary>
        /// 盛水最多的容器
        /// 双指针法
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public static int MaxArea(int[] height)
        {
            int i = 0;
            int j = height.Length - 1;
            int res = 0;
            while (i < j)
            {
                res = height[i] < height[j] ? Math.Max(res, (j - i) * height[i++]) : Math.Max(res, (j - i) * height[j--]);
            }
            return res;
        }
    }
}
