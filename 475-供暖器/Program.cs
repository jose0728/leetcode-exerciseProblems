using System;

namespace _475_供暖器
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /**
         * 整体思路：
         * (1)先找到每个房屋离加热器的最短距离（即找出离房屋最近的加热器）；
         *  (2)在所有距离中选出最大的一个即为最小覆盖半径。记住是选一个最大的距离。
         * 二分查找的思路
         * 针对每个房屋都有四中可能性
         * 1，房屋的位置刚好有一个加热器，那么加热器离房屋的距离就是0
         * 2，房屋的左边没有加热器，右边有加热器，那最小距离是：加热器位置 - 房屋的位置
         * 3，房屋的左边有加热器，右边没有，那最小距离是：房屋的位置 - 加热器的位置
         * 4，房屋的左右都有加热器，那最小距离是： Min（房屋离左侧加热器的距离，房屋离右侧加热器的距离）
         */
        /// <summary>
        /// 供暖器（leetcode475题）
        /// 冬季已经来临。 你的任务是设计一个有固定加热半径的供暖器向所有房屋供暖。
        /// 在加热器的加热半径范围内的每个房屋都可以获得供暖。
        /// 现在，给出位于一条水平线上的房屋 houses 和供暖器 heaters 的位置，请你找出并返回可以覆盖所有房屋的最小加热半径。
        /// 说明：所有供暖器都遵循你的半径标准，加热的半径也一样。
        /// </summary>
        /// <param name="houses"></param>
        /// <param name="heaters"></param>
        /// <returns></returns>
        public static int FindRadius(int[] houses, int[] heaters)
        {
            Array.Sort(heaters);

            int[] distances = new int[houses.Length];
            for (int i = 0; i < houses.Length; i++)
            {
                int left = 0;
                int right = heaters.Length - 1;

                //找到离本房子最近的加热器
                while (left < right)
                {
                    int mid = (left + right) / 2;
                    if (heaters[mid] > houses[i])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid;
                    }
                }
                if (heaters[left] == houses[i])
                {
                    distances[i] = 0;
                }
                else if (heaters[left] > houses[i] && left == 0)
                {
                    // 如果加热器在房屋的右边且房屋的左边没有加热器了
                    distances[i] = heaters[left] - houses[i];
                }
                else if (heaters[left] < houses[i] && left == heaters.Length - 1)
                {
                    // 如果加热器在房屋的左边，且房屋的右边没有加热器了
                    distances[i] = houses[i] - heaters[left];
                }
                else
                {
                    // 如果房屋两边都有加加热器
                    distances[i] = Math.Min((heaters[left + 1] - houses[i]), (houses[i] - heaters[left]));
                }
            }

            Array.Sort(distances);
            return distances[distances.Length - 1];
        }
    }
}
