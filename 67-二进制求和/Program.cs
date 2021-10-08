using System;
using System.Linq;
using System.Text;

namespace _67_二进制求和
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = AddBinary2("1011", "1000");
        }

        /// <summary>
        /// 模拟加法
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
