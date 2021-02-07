using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 镜面反射
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = MirrorReflection(5, 3);
        }

        /// <summary>
        /// 858. 镜面反射
        /// 光线最终向上走的距离，其实就是 p 和 q 的最小公倍数。
        /// 我们设最小公倍数为 L，会发现如果 L 是 p 的奇数倍，光线则到达北墙;当 L 是 p 的 偶数倍，光线将会射到南墙。
        /// 果光线是射向南墙，因为只有一个接收器了，必定只能遇到接收器 0。但是如果射到了北墙，如何区分是 1 和 2。
        /// 这回到了一个初中数学题，我们可以通过光线与东西墙的接触次数，来判断最终的落点是 1 还是 2。
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static int MirrorReflection(int p, int q)
        {
            int m = p, n = q;
            int r;
            while (n > 0)
            {
                r = m % n;
                m = n;
                n = r;
            }
            if ((p / m) % 2 == 0)
            {
                return 2;
            }
            else if ((q / m) % 2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
