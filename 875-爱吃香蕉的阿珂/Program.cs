using System;

namespace _875_爱吃香蕉的阿珂
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] piles = { 3, 6, 7, 11 };
            int H = 8;
            var a = MinEatingSpeed(piles, H);
        }

        /// <summary>
        /// 爱吃香蕉的阿珂（leetcode875题）
        /// 珂珂喜欢吃香蕉。这里有 N 堆香蕉，第 i 堆中有 piles[i] 根香蕉。警卫已经离开了，将在 H 小时后回来。
        /// 珂珂可以决定她吃香蕉的速度 K （单位：根/小时）。
        /// 每个小时，她将会选择一堆香蕉，从中吃掉 K 根。如果这堆香蕉少于 K 根，她将吃掉这堆的所有香蕉，然后这一小时内不会再吃更多的香蕉。  
        /// 珂珂喜欢慢慢吃，但仍然想在警卫回来前吃掉所有的香蕉。
        /// 返回她可以在 H 小时内吃掉所有香蕉的最小速度 K（K 为整数）。
        /// </summary>
        /// <param name="piles"></param>
        /// <param name="H"></param>
        /// <returns></returns>
        public static int MinEatingSpeed(int[] piles, int H)
        {
            int min = 1;
            int max = MaxV(piles);
            //我们要找符合条件的最小值
            while (min < max)
            {
                int mid = (min + max) / 2;
                if (CanEatFinish(piles, H, mid))
                {//如果能吃完，说明可能还可以吃的更慢
                    max = mid;//这里要注意，因为是能吃完，所以mid也符合条件
                }
                else
                {//不能吃完，说明需要吃的更快一点
                    min = mid + 1;//这里要注意，因为不能吃完，所以mid不符合条件
                }
            }
            return min;
        }

        /// <summary>
        /// 找出香蕉堆中的最大值
        /// </summary>
        /// <param name="piles"></param>
        /// <returns></returns>
        private static int MaxV(int[] piles)
        {
            int temp = 0;
            foreach (int v in piles)
            {
                temp = Math.Max(v, temp);
            }
            return temp;
        }

        /// <summary>
        /// 能否在H小时以速度K吃完香蕉
        /// </summary>
        /// <param name="piles">香蕉</param>
        /// <param name="H">H小时</param>
        /// <param name="K">速度K</param>
        /// <returns></returns>
        private static bool CanEatFinish(int[] piles, int H, int K)
        {
            int h = 0;
            //foreach (int p in piles)
            //{
            //    h += (p - 1) / K + 1;
            //}
            foreach (int p in piles)
            {
                h += (int)Math.Ceiling(p * 1.0 / K);
            }

            return h <= H;
        }
    }
}
