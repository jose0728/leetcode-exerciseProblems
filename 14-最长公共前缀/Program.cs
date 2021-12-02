using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_最长公共前缀
{
    class Program
    {
        /// <summary>
        /// 编写一个函数来查找字符串数组中的最长公共前缀。
        /// 如果不存在公共前缀，返回空字符串 ""。
        /// 示例 1：
        /// 输入：strs = ["flower","flow","flight"]
        /// 输出："fl"
        /// 示例 2：
        /// 输入：strs = ["dog","racecar","car"]
        /// 输出：""
        /// 解释：输入不存在公共前缀。
        /// 提示：
        /// 1 <= strs.length <= 200
        /// 0 <= strs[i].length <= 200
        /// strs[i] 仅由小写英文字母组成
        /// </summary>
        /// <param name="args"></param>
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
