using System;

namespace _1720_解码异或后的数组
{
    class Program
    {
        /// <summary>
        /// 未知 整数数组 arr 由 n 个非负整数组成。
        /// 经编码后变为长度为 n - 1 的另一个整数数组 encoded ，其中 encoded[i] = arr[i] XOR arr[i + 1] 。例如，arr = [1,0,2,1]
        /// 经编码后得到 encoded = [1, 2, 3] 。
        /// 给你编码后的数组 encoded 和原数组 arr 的第一个元素 first（arr[0]）。
        /// 请解码返回原数组 arr 。可以证明答案存在并且是唯一的。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int[] encoded = { 6, 2, 7, 3 };
            int first = 4;
            Decode(encoded, first);
        }

        /// <summary>
        /// 异或结合律
        /// </summary>
        /// <param name="encoded"></param>
        /// <param name="first"></param>
        /// <returns></returns>
        public static int[] Decode(int[] encoded, int first)
        {
            int[] decoded = new int[encoded.Length + 1];
            decoded[0] = first;
            for (int i = 1; i < decoded.Length; i++)
            {
                decoded[i] = decoded[i - 1] ^ encoded[i - 1];
            }
            return decoded;
        }
    }
}
