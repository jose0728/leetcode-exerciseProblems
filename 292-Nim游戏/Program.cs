﻿using System;
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
        /// 让我们考虑一些小例子。显而易见的是，如果石头堆中只有一块、两块、或是三块石头，那么在你的回合，你就可以把全部石子拿走，从而在游戏中取胜；
        /// 如果堆中恰好有四块石头，你就会失败。因为在这种情况下不管你取走多少石头，总会为你的对手留下几块，他可以将剩余的石头全部取完，从而他可以在游戏中打败你。
        /// 因此，要想获胜，在你的回合中，必须避免石头堆中的石子数为 4 的情况。
        /// 我们继续推理，假设当前堆里只剩下五块、六块、或是七块石头，你可以控制自己拿取的石头数，总是恰好给你的对手留下四块石头，使他输掉这场比赛。
        /// 但是如果石头堆里有八块石头，你就不可避免地会输掉，因为不管你从一堆石头中挑出一块、两块还是三块，你的对手都可以选择三块、两块或一块，以确保在再一次轮到你的时候，你会面对四块石头。
        /// 显然我们继续推理，可以看到它会以相同的模式不断重复 n = 4, 8, 12, 16,…，基本可以看出如果堆里的石头数目为 4 的倍数时，你一定会输掉游戏。
        /// 如果总的石头数目为 4 的倍数时，因为无论你取多少石头，对方总有对应的取法，让剩余的石头的数目继续为 4 的倍数。
        /// 对于你或者你的对手取石头时，显然最优的选择是当前己方取完石头后，让剩余的石头的数目为 44 的倍数。
        /// 假设当前的石头数目为 x，如果 x 为 4 的倍数时，则此时你必然会输掉游戏；如果 x 不为 4 的倍数时，则此时你只需要取走 x mod 4个石头时，则剩余的石头数目必然为 4 的倍数，从而对手会输掉游戏。
        /// </summary>
        /// <param name="n">石头的数量</param>
        /// <returns></returns>
        public static bool CanWinNim(int n)
        {
            return (n % 4 != 0);
        }
    }
}
