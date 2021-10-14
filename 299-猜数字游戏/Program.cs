using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _299_猜数字游戏
{
    class Program
    {
        /// <summary>
        /// 你在和朋友一起玩 猜数字（Bulls and Cows）游戏，该游戏规则如下：
        /// 你写出一个秘密数字，并请朋友猜这个数字是多少。
        /// 朋友每猜测一次，你就会给他一个提示，告诉他的猜测数字中有多少位属于数字和确切位置都猜对了（称为“Bulls”, 公牛），有多少位属于数字猜对了但是位置不对（称为“Cows”, 奶牛）。
        /// 朋友根据提示继续猜，直到猜出秘密数字。
        /// 写出一个根据秘密数字和朋友的猜测数返回提示的函数，返回字符串的格式为 xAyB ，x 和 y 都是数字，A 表示公牛，用 B 表示奶牛。
        /// xA 表示有 x 位数字出现在秘密数字中，且位置都与秘密数字一致。
        /// yB 表示有 y 位数字出现在秘密数字中，但位置与秘密数字不一致。
        /// 请注意秘密数字和朋友的猜测数都可能含有重复数字，每位数字只能统计一次。
        /// 输入: secret = "1807", guess = "7810"
        /// 输出: "1A3B"
        /// 解释: 1 公牛和 3 奶牛。公牛是 8，奶牛是 0, 1 和 7。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var secret = "1122";
            var guess = "0111";
            var a = GetHint(secret, guess);
        }

        /// <summary>
        /// 哈希思想
        /// </summary>
        /// <param name="secret"></param>
        /// <param name="guess"></param>
        /// <returns></returns>
        public static string GetHint(string secret, string guess)
        {
            // 定义两个map，用来存放每位数字出现的次数
            Dictionary<char, int> secretMap = new Dictionary<char, int>();
            Dictionary<char, int> guessMap = new Dictionary<char, int>();
            int bulls = 0;
            int cows = 0;
            char[] secretChars = secret.ToCharArray();
            char[] guessChars = guess.ToCharArray();
            for (int i = 0; i < guess.Length; i++)
            {
                if (guessChars[i] == secretChars[i])
                {
                    // 相等，说明是公牛
                    bulls++;
                }
                else
                {
                    var sValue = secretMap.ContainsKey(secretChars[i]) ? secretMap[secretChars[i]] + 1 : 1;
                    var gValue = guessMap.ContainsKey(guessChars[i]) ? guessMap[guessChars[i]] + 1 : 1;
                    // 不等的话，先存放到map中
                    if (sValue > 1)
                        secretMap[secretChars[i]] = sValue;
                    else
                        secretMap.Add(secretChars[i], sValue);

                    if (gValue > 1)
                        guessMap[guessChars[i]] = gValue;
                    else
                        guessMap.Add(guessChars[i], gValue);
                }
            }
            foreach (var item in secretMap)
            {
                var curKey = item.Key;
                // 如果猜测数字里面包含秘密数字，则从两个map里面取出最小值即可
                if (guessMap.ContainsKey(curKey))
                {
                    var c = guessMap[curKey];
                    var b = secretMap[curKey];
                    cows += Math.Min(b, c);
                }
            }
            return bulls + "A" + cows + "B";
        }
    }
}
