using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _289_生命游戏
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] a = new int[4][];
            a[0] = new int[] { 0, 1, 0 };
            a[1] = new int[] { 0, 0, 1 };
            a[2] = new int[] { 1, 1, 1 };
            a[3] = new int[] { 0, 0, 0 };
            var b = GameOfLife(a);
        }

        /// <summary>
        /// 考察边界问题处理
        /// </summary>
        /// <param name="board"></param>
        public static int[][] GameOfLife(int[][] board)
        {
            int[] neighbors = { 0, 1, -1 };//{0. 1. -1} 这三个位置可以随意安排，安排的顺序表示当前结点周围的8个结点的遍历顺序而已。

            int rows = board.Length;
            int cols = board[0].Length;

            // 创建复制数组 copyBoard
            int[][] copyBoard = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                copyBoard[i] = new int[cols];
            }

            // 从原数组复制一份到 copyBoard 中
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    copyBoard[row][col] = board[row][col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // 对于每一个细胞统计其八个相邻位置里的活细胞数量
                    int liveNeighbors = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (!(neighbors[i] == 0 && neighbors[j] == 0))
                            {
                                int r = (row + neighbors[i]);
                                int c = (col + neighbors[j]);

                                if (r < rows && r >= 0 && c < cols && c >= 0 && copyBoard[r][c] == 1)
                                {
                                    liveNeighbors++;
                                }
                            }
                        }
                    }

                    //如果活细胞周围八个位置的活细胞数少于两个，则该位置活细胞死亡
                    //如果活细胞周围八个位置有超过三个活细胞，则该位置活细胞死亡
                    //如果活细胞周围八个位置有两个或三个活细胞，则该位置活细胞仍然存活
                    if ((copyBoard[row][col] == 1) && (liveNeighbors < 2 || liveNeighbors > 3))
                    {
                        board[row][col] = 0;
                    }

                    //如果死细胞周围正好有三个活细胞，则该位置死细胞复活
                    if (copyBoard[row][col] == 0 && liveNeighbors == 3)
                    {
                        board[row][col] = 1;
                    }
                }
            }

            return board;
        }
    }
}
