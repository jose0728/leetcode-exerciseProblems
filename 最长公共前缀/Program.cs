using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_最长公共前缀
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] test = { "flower", "flow", "flight" };
            var str = Method1(test);
        }

        /// <summary>
        /// 逆向思维
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string Method1(string[] strs)
        {
            string ans = strs[0];
            if (strs.Length == 0)
                return "";
            foreach (var item in strs)
            {
                if (ans == "")
                    return "";
                while (!item.StartsWith(ans))
                    ans = ans.Substring(0, ans.Length - 1);
            }
            return ans;
        }
    }
}
