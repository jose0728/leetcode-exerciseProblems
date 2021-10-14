using System;
using System.Linq;
using System.Text;

namespace _67_二进制求和
{
    class Program
    {
        /// <summary>
        /// 给你两个二进制字符串，返回它们的和（用二进制表示）。
        /// 输入为 非空 字符串且只包含数字 1 和 0。
        /// 输入: a = "11", b = "1"
       ///  输出: "100"
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var c = AddBinary("1011", "1001");
        }

        /// <summary>
        /// 模拟加法
        /// 每次都拼加好的数，进位保存在一个变量里，每次相加前都要加上进位
        /// 如果加到最后，进位还有的话，就在末尾补充一个1
        /// 反转字符串
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string AddBinary(string a, string b)
        {
            var res = string.Empty;
            StringBuilder ans = new StringBuilder();
            int ca = 0;
            for (int i = a.Length - 1, j = b.Length - 1; i >= 0 || j >= 0; i--, j--)
            {
                int sum = ca;
                sum += i >= 0 ? a[i] - '0' : 0;
                sum += j >= 0 ? b[j] - '0' : 0;
                ans.Append(sum % 2);
                ca = sum / 2;
            }
            if (ca == 1)
                ans.Append(1);
            foreach (var item in ans.ToString().Reverse())
            {
                res += item;
            }
            return res;
        }

        public static string AddBinary2(string a, string b)
        {
            return System.Convert.ToString(System.Convert.ToInt32(a, 2) + System.Convert.ToInt32(b, 2), 2);
        }
    }
}
