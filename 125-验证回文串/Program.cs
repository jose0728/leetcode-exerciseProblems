using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _125_验证回文串
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "A man, a plan, a canal: Panama";
            var b = ValidPalindrome3(s);
        }

        /// <summary>
        /// 方法一：筛选+判断
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ValidPalindrome1(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetterOrDigit(s[i]))
                {
                    sb.Append(s[i]);
                }
            }
            var a = sb.ToString().ToLower();
            string b = new string(sb.ToString().Reverse().ToArray()).ToLower();
            if (a != b)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 方法二：双指针
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ValidPalindrome2(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetterOrDigit(s[i]))
                {
                    sb.Append(s[i]);
                }
            }
            var a = sb.ToString();
            int n = a.Length;
            int left = 0, right = n - 1;
            while (left < right)
            {
                if (char.ToLower(a[left]) != char.ToLower(a[right]))
                {
                    return false;
                }
                ++left;
                --right;
            }
            return true;
        }

        /// <summary>
        /// 方法三：双指针
        /// 在原字符串上直接判断
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool ValidPalindrome3(string s)
        {
            int n = s.Length;
            int left = 0, right = n - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left]))
                {
                    ++left;
                }
                while (left < right && !char.IsLetterOrDigit(s[right]))
                {
                    --right;
                }
                if (left < right)
                {
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    {
                        return false;
                    }
                }
                ++left;
                --right;
            }
            return true;
        }
    }
}
