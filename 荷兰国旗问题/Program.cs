using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 荷兰国旗问题
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 0, 1, 0, 2, 2, 1, 0 };
            int[] b = SortColors(a);
        }

        public static int[] SortColors(int[] nums)
        {
            int a = 0;
            int c = 0;
            int b = nums.Length - 1;

            while (c <= b)
            {
                if (nums[c] == 0)
                {
                    int tmp = nums[a];
                    nums[a] = nums[c];
                    nums[c] = tmp;

                    a++;
                    c++;
                }
                else if (nums[c] == 2)
                {
                    int tmp = nums[c];
                    nums[c] = nums[b];
                    nums[b] = tmp;

                    b--;
                }
                else
                {
                    c++;
                }
            }

            return nums;
        }
    }
}
