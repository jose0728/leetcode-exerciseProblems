using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_字符串转换为整数
{
    class Program
    {
        /// <summary>
        /// 输入：s = "42"
        /// 输出：42
        /// 
        /// 输入：s = "   -42"
        /// 输出：-42
        /// 
        /// 输入：s = "4193 with words"
        /// 输出：4193
        /// 
        /// 输入：s = "words and 987"
        /// 输出：0
        /// 
        /// 输入：s = "-91283472332"
        /// 输出：-2147483648
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int a = MyAtoi(" -42");
        }

        /*
        请你来实现一个 atoi 函数，使其能将字符串转换成整数。

        首先，该函数会根据需要丢弃无用的开头空格字符，直到寻找到第一个非空格的字符为止。接下来的转化规则如下：

        如果第一个非空字符为正或者负号时，则将该符号与之后面尽可能多的连续数字字符组合起来，形成一个有符号整数。
        假如第一个非空字符是数字，则直接将其与之后连续的数字字符组合起来，形成一个整数。
        该字符串在有效的整数部分之后也可能会存在多余的字符，那么这些字符可以被忽略，它们对函数不应该造成影响。
        注意：假如该字符串中的第一个非空格字符不是一个有效整数字符、字符串为空或字符串仅包含空白字符时，则你的函数不需要进行转换，即无法进行有效转换。

        在任何情况下，若函数不能进行有效的转换时，请返回 0 。

        提示：

        本题中的空白字符只包括空格字符 ' ' 。
        假设我们的环境只能存储 32 位大小的有符号整数，那么其数值范围为 [−231,  231 − 1]。如果数值超过这个范围，请返回  INT_MAX (231 − 1) 或 INT_MIN (−231) 。
        */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int MyAtoi(string s)
        {
            int index = 0;
            int sign = 1;
            int res = 0;

            if (s == null || s.Length == 0)
            {
                return 0;
            }

            var arr = s.ToArray();
            while (index < s.Length && arr[index] == ' ')
            {
                index++;
            }

            if (index == s.Length)
            {
                return 0;
            }

            if (arr[index] == '+' || arr[index] == '-')
            {
                sign = s[index] == '+' ? 1 : -1;
                index++;
            }

            while (index < s.Length)
            {
                int dight = arr[index] - '0';
                if (dight < 0 || dight > 9)
                {
                    break;
                }

                //res * 10 + dight > int.MaxValue ==> res > (int.MaxValue - dight) / 10
                if (res > (int.MaxValue - dight) / 10)
                {
                    return sign == 1 ? int.MaxValue : int.MinValue;
                }

                res = res * 10 + dight;
                index++;
            }

            return res * sign;
        }
    }
}
