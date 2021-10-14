using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 荷兰国旗问题
{
    class Program
    {
        /// <summary>
        /// 荷兰国旗问题：现在有若干个红、白、蓝三种颜色的球随机排列成一条直线。现在我们的任务是把这些球按照红、白、蓝排序。
        /// 这个问题之所以叫荷兰国旗，是因为我们可以将红白蓝三色小球想象成条状物，有序排列后正好组成荷兰国旗。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 0, 1, 0, 2, 2, 1, 0 };
            int[] b = SortColors(a);
        }

        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] SortColors(int[] nums)
        {
            int a = 0;
            int c = 0;
            int b = nums.Length - 1;

            while (c <= b)
            {
                //若遍历到的元素为0，说明他一定位于a的左侧，那么将他和a处的元素交换，同时移动a和c
                if (nums[c] == 0)
                {
                    int tmp = nums[a];
                    nums[a] = nums[c];
                    nums[c] = tmp;

                    a++;
                    c++;
                }
                //若遍历到的元素为2，说明他一定位于b的左侧，那么将他和b处的元素交换，同时移动b，c仍然指向原位置。（因为交换后的C可能是属于A之前的，所以C仍然指向原位置）
                else if (nums[c] == 2)
                {
                    int tmp = nums[c];
                    nums[c] = nums[b];
                    nums[b] = tmp;

                    b--;
                }
                //若遍历到的位置为1，则说明它一定位于AB之间，满足规则，不需要动弹。只需向右移动C。
                else
                {
                    c++;
                }
            }

            return nums;
        }
    }
}
