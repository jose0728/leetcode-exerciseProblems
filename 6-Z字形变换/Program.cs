using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Z字形变换
{
    class Program
    {
        /// <summary>
        /// 将一个给定字符串 s 根据给定的行数 numRows ，以从上往下、从左到右进行 Z 字形排列。
        /// 比如输入字符串为 "PAYPALISHIRING" 行数为 3 时，排列如下：
        /// P   A   H   N
        /// A P L S I I G
        /// Y   I   R
        /// 之后，你的输出需要从左往右逐行读取，产生出一个新的字符串，比如："PAHNAPLSIIGYIR"。
        /// 请你实现这个将字符串进行指定行数变换的函数：
        /// string convert(string s, int numRows);
        /// 示例 1：
        /// 输入：s = "PAYPALISHIRING", numRows = 3
        /// 输出："PAHNAPLSIIGYIR"
        /// 示例 2：
        /// 输入：s = "PAYPALISHIRING", numRows = 4
        /// 输出："PINALSIGYAHRPI"
        /// 解释：
        /// P     I    N
        /// A   L S  I G
        /// Y A   H R
        /// P     I
        /// 示例 3：
        /// 输入：s = "A", numRows = 1
        /// 输出："A"
        /// 提示：
        /// 1 <= s.length <= 1000
        /// s 由英文字母（小写和大写）、',' 和 '.' 组成
        /// 1 <= numRows <= 1000
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string a = "LEETCODEISHIRING";
            string b = Convert1(a, 3);
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
