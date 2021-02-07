using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Z字形变换
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "LEETCODEISHIRING";
            string b = Convert2(a, 3);
        }

        /// <summary>
        /// 关键在于找一个周期2n-2
        /// </summary>
        /// <param name="s">要转化的字符串</param>
        /// <param name="numRows">行数</param>
        /// <returns></returns>
        public static string Convert1(string s, int numRows)
        {
            if (numRows == 1)
                return s;
            string[] arr = new string[numRows];
            char[] chars = s.ToCharArray();
            int len = chars.Length;
            int period = numRows * 2 - 2;
            for (int i = 0; i < len; i++)
            {
                int mod = i % period;
                if (mod < numRows)
                    arr[mod] += chars[i];
                else
                    arr[period - mod] += chars[i];
            }
            StringBuilder res = new StringBuilder();
            foreach (var item in arr)
            {
                res.Append(item);
            }
            return res.ToString();
        }

        /// <summary>
        /// 利用flag
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static string Convert2(string s, int numRows)
        {
            if (numRows == 1)
                return s;
            string[] arr = new string[numRows];
            int i = 0, flag = -1;
            foreach (var item in s.ToCharArray())
            {
                arr[i] += item;
                if (i == 0 || i == numRows - 1)
                    flag = -flag;
                i += flag;
            }
            StringBuilder res = new StringBuilder();
            foreach (var item in arr)
            {
                res.Append(item);
            }
            return res.ToString();
        }
    }
}
