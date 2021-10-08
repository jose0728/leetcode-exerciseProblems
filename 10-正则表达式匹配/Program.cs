using System;

namespace _10_正则表达式匹配
{
    class Program
    {
        /// <summary>
        /// 给你一个字符串 s 和一个字符规律 p，请你来实现一个支持 '.' 和 '*' 的正则表达式匹配。
        /// '.' 匹配任意单个字符
        /// '*' 匹配零个或多个前面的那一个元素
        /// 所谓匹配，是要涵盖 整个字符串 s的，而不是部分字符串。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var a = IsMatch("a", "c*a");
        }

        public static bool IsMatch(string s, string p)
        {
            //s和p可能为空。空的长度就是0，但是这些情况都已经判断过了，只需要判断是否为null即可
            if (p.Length == 0 && s.Length == 0)
                return true;
            if (s == null || p == null)
                return false;

            int rows = s.Length;
            int columns = p.Length;
            bool[,] dp = new bool[rows + 1, columns + 1];
            //dp[i][j] 表示 s 的前 i 个是否能被 p 的前 j 个匹配

            //s和p两个都为空，肯定是可以匹配的，同时这里取true的原因是
            //当s=a，p=a，那么dp[1][1] = dp[0][0]。因此dp[0][0]必须为true。
            dp[0, 0] = true;

            for (int j = 1; j <= columns; j++)
            {
                //p[j-1]为*可以把j-2和j-1处的字符删去，只有[0,j-3]都为true才可以
                //因此dp[j-2]也要为true，才可以说明前j个为true
                if (p[j - 1] == '*' && dp[0, j - 2])
                    dp[0, j] = true;
            }

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= columns; j++)
                {
                    char nows = s[i - 1];
                    char nowp = p[j - 1];
                    if (nows == nowp)
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        if (nowp == '.')
                            dp[i, j] = dp[i - 1, j - 1];
                        else if (nowp == '*')
                        {
                            //p需要能前移1个。（当前p指向的是j-1，前移1位就是j-2，因此为j>=2）
                            if (j >= 2)
                            {
                                char nowpLast = p[j - 2];
                                //只有p[j-2]==s[i-1]或p[j-2]==‘.’才可以让*取1个或者多个字符：
                                if (nowpLast == nows || nowpLast == '.')
                                    dp[i, j] = dp[i - 1, j] || dp[i, j - 1];
                                //不论p[j-2]是否等于s[i-1]都可以删除掉j-1和j-2处字符：
                                dp[i, j] = dp[i, j] || dp[i, j - 2];
                            }
                        }
                        else
                            dp[i, j] = false;
                    }
                }
            }

            return dp[rows, columns];
        }
    }
}
