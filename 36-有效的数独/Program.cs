using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_有效的数独
{
    class Program
    {
        /// <summary>
        /// 请你判断一个 9x9 的数独是否有效。只需要 根据以下规则 ，验证已经填入的数字是否有效即可。
        /// 数字 1-9 在每一行只能出现一次。
        /// 数字 1-9 在每一列只能出现一次。
        /// 数字 1-9 在每一个以粗实线分隔的 3x3 宫内只能出现一次。（请参考示例图）
        /// 数独部分空格内已填入了数字，空白格用 '.' 表示。
        /// 注意：
        /// 一个有效的数独（部分已被填充）不一定是可解的。
        /// 只需要根据以上规则，验证已经填入的数字是否有效即可。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string[][] matrix = new string[9][];
            matrix[0] = new string[] { "5", "3", ".", ".", "7", ".", ".", ".", "." };
            matrix[1] = new string[] { "6", ".", ".", "1", "9", "5", ".", ".", "." };
            matrix[2] = new string[] { ".", "9", "8", ".", ".", ".", ".", "6", "." };
            matrix[3] = new string[] { "8", ".", ".", ".", "6", ".", ".", ".", "3" };
            matrix[4] = new string[] { "4", ".", ".", "8", ".", "3", ".", ".", "1" };
            matrix[5] = new string[] { "7", ".", ".", ".", "2", ".", ".", ".", "6" };
            matrix[6] = new string[] { ".", "6", ".", ".", ".", ".", "2", "8", "." };
            matrix[7] = new string[] { ".", ".", ".", "4", "1", "9", ".", ".", "5" };
            matrix[8] = new string[] { ".", ".", ".", ".", "8", ".", ".", "7", "9" };
            var c = IsValidSudoku(matrix);
        }

        /// <summary>
        /// 题意理解：只需要判断已经填入数独的数字就行
        /// 哈希思想+模拟推理
        /// 由于board中的整数限定在1到9的范围内，因此可以分别建立哈希表来存储任一个数在相应维度上是否出现过。
        /// 维度有3个：所在的行，所在的列，所在的box，注意box的下标也是从左往右、从上往下的。
        /// 遍历到每个数的时候，例如boar[i][j]，我们判断其是否满足三个条件：
        /// 在第 i 个行中是否出现过
        /// 在第 j 个列中是否出现过
        /// 在第 j/3 + (i/3)*3个box中是否出现过.为什么是j/3 + (i/3)*3呢？模拟推理出来的
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static bool IsValidSudoku(string[][] board)
        {
            int[,] rows = new int[9, 9];
            int[,] col = new int[9, 9];
            int[,] sbox = new int[9, 9];
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] != ".")
                    {
                        // 遍历到第i行第j列的那个数,我们要判断这个数在其所在的行有没有出现过，
                        // 同时判断这个数在其所在的列有没有出现过
                        // 同时判断这个数在其所在的box中有没有出现过
                        int num = int.Parse(board[i][j]) - 1;
                        int boxIndex = (i / 3) * 3 + j / 3;
                        if (rows[i, num] == 1) return false;
                        if (col[j, num] == 1) return false;
                        if (sbox[boxIndex, num] == 1) return false;

                        //之前都没出现过，现在出现了，就给它置为1，下次再遇见就能够直接返回false了
                        rows[i, num] = 1;
                        col[j, num] = 1;
                        sbox[boxIndex, num] = 1;
                    }
                }
            }
            return true;
        }
    }
}
