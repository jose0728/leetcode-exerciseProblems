using System;

namespace _171_Excel表列序号
{
    class Program
    {
        /// <summary>
        /// 给你一个字符串 columnTitle ，表示 Excel 表格中的列名称。返回该列名称对应的列序号
        /// 例如，
        /// A -> 1
        /// B -> 2
        /// C -> 3
        /// ...
        /// Z -> 26
        /// AA -> 27
        /// AB -> 28 
        /// ...
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TitleToNumber2("AA");
        }

        /// <summary>
        /// 转换为26进制
        /// </summary>
        /// <param name="columnTitle"></param>
        /// <returns></returns>
        public static int TitleToNumber(string columnTitle)
        {
            int ans = 0;
            foreach (var item in columnTitle)
            {
                var num = item - 'A' + 1;
                ans = ans * 26 + num;
            }
            return ans;
        }

        /// <summary>
        /// 也是转换为26进制，但是用了高级的方法
        /// </summary>
        /// <param name="columnTitle"></param>
        /// <returns></returns>
        public static int TitleToNumber2(string columnTitle)
        {
            double res = 0;
            int carry = 0;
            for (int i = columnTitle.Length - 1; i >= 0; i--)
            {
                res += (columnTitle[i] - 'A' + 1) * Math.Pow(26, carry);//Math.Pow(26, carry)表示26的carry次方
                carry++;
            }
            return (int)res;
        }

    }
}
