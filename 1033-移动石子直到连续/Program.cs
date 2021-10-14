using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1033_移动石子直到连续
{
    class Program
    {
        /// <summary>
        /// 三枚石子放置在数轴上，位置分别为 a，b，c。
        /// 每一回合，你可以从两端之一拿起一枚石子（位置最大或最小），并将其放入两端之间的任一空闲位置。形式上，假设这三枚石子当前分别位于位置 x, y, z 且 x < y < z, 那么就可以从位置 x 或者是位置 z 拿起一枚石子，并将该石子移动到某一整数位置 k 处，其中 x < k < z 且 k != y。
        /// 当你无法进行任何移动时，即，这些石子的位置连续时，游戏结束。
        /// 要使游戏结束，你可以执行的最小和最大移动次数分别是多少？ 以长度为 2 的数组形式返回答案：answer = [minimum_moves, maximum_moves]
        /// 输入：a = 1, b = 2, c = 5
        /// 输出：[1, 2]
        /// 解释：将石子从 5 移动到 4 再移动到 3，或者我们可以直接将石子移动到 3。
        /// 输入：a = 4, b = 3, c = 2
        /// 输出：[0, 0]
        /// 解释：我们无法进行任何移动。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var a = NumMovesStones(1, 2, 5);
        }

        public static int[] NumMovesStones(int a, int b, int c)
        {
            int[] arr = { a, b, c };
            Array.Sort(arr);

            int x = arr[1] - arr[0] - 1;
            int y = arr[2] - arr[1] - 1;
            int max = x + y;
            int min = 0;

            if (x != 0 || y != 0)
            {
                if (x > 1 && y > 1)
                {
                    //两个间隔都可以移动，一步就移动过去
                    min = 2;
                }
                else
                {
                    //两个间隔只有一个间隔可以移动了，一步就移动过去
                    min = 1;
                }
            }
            return new int[] { min, max };
        }
    }
}
