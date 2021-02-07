using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _299_猜数字游戏
{
    class Program
    {
        static void Main(string[] args)
        {
            var secret = "1122";
            var guess = "0111";
            var a = GetHint(secret, guess);
        }

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
