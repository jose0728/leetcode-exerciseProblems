using System;

namespace _171_Excel表列序号
{
    class Program
    {
        static void Main(string[] args)
        {
            TitleToNumber2("AA");
        }

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

        public static int TitleToNumber2(string columnTitle)
        {
            double res = 0;
            int carry = 0;
            for (int i = columnTitle.Length - 1; i >= 0; i--)
            {
                res += (columnTitle[i] - 'A' + 1) * Math.Pow(26, carry);
                carry++;
            }
            return (int)res;
        }

    }
}
