using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1033_移动石子直到连续
{
    class Program
    {
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
                    min = 2;
                }
                else
                {
                    min = 1;
                }
            }
            return new int[] { min, max };
        }
    }
}
