using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _292_Nim游戏
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 你和你的朋友，两个人一起玩 Nim 游戏：桌子上有一堆石头，每次你们轮流拿掉 1 - 3 块石头。
        /// 拿掉最后一块石头的人就是获胜者。你作为先手。 你们是聪明人，每一步都是最优解。
        /// 编写一个函数，来判断你是否可以在给定石头数量的情况下赢得游戏。
        /// 分析：只要石头的数量是n的倍数，那么就一定会输
        /// </summary>
        /// <param name="n">石头的数量</param>
        /// <returns></returns>
        public static bool CanWinNim(int n)
        {
            return (n % 4 != 0);
        }
    }
}
