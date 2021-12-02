using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _858_镜面反射
{
    class Program
    {
        /// <summary>
        /// 有一个特殊的正方形房间，每面墙上都有一面镜子。除西南角以外，每个角落都放有一个接受器，编号为 0， 1，以及 2。
        /// 正方形房间的墙壁长度为 p，一束激光从西南角射出，首先会与东墙相遇，入射点到接收器 0 的距离为 q 。
        /// 返回光线最先遇到的接收器的编号（保证光线最终会遇到一个接收器）。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int a = MirrorReflection(5, 3);
        }

        /// </summary>
        /// 直接根据p、q的奇偶性直接判断第一个到达的镜子
        /// 画图，假设镜面不能反射，直接画延长线
        /// 当 p/q = 1/1 的时候（相等），到达接收器1
        /// 当 p/q = 2/1 的时候，到达接收器2
        /// 当 p/q = 3/1 的时候，到达接收器1
        /// 当 p/q = 4/1 的时候，到达接收器2
        /// 当 p/q = 3/2 的时候，到达接收器0
        /// 总结：
        /// p奇数，q奇数，到达1
        /// p奇数，q偶数，到达0
        /// p偶数，q奇数，到达2
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static int MirrorReflection(int p, int q)
        {
            while (p % 2 == 0 && q % 2 == 0)
            {
                p /= 2;
                q /= 2;
            }
            if (p % 2 != 0 && q % 2 != 0)
            {
                return 1;
            }
            else if (p % 2 != 0 && q % 2 == 0)
            {
                return 0;
            }
            else
            {
                return 2;
            }
        }
    }
}
