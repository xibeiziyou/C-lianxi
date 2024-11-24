using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_练习
{
    internal class 井字棋状况判定
    {
        public static int IsSolved(int[,] board)
        {
            //胜
            if (board[0, 0] == board[1, 1] && board[2,2] == board[1, 1])return board[1, 1] == 0 ? -1 : board[1, 1];
            if (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2]) return board[1, 1] == 0 ? -1 : board[1, 1];
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i]) return board[2, i] == 0 ? -1 : board[2, i];
                if (board[i, 0] == board[i,1]&& board[i, 1] == board[i,2])return board[i,2] == 0 ? -1 : board[i, 2];
            }
            //未完
            foreach (var item in board)
            {
                if (item == 0) return -1;
            }
            //平
            return 0;
        }

        public static int IsSolved优化(int[,] board)
        {
            // 检查胜利条件
            if (IsWinningLine(board[0, 0], board[1, 1], board[2, 2])) return board[1, 1];
            if (IsWinningLine(board[2, 0], board[1, 1], board[0, 2])) return board[1, 1];
            for (int i = 0; i < 3; i++)
            {
                if (IsWinningLine(board[0, i], board[1, i], board[2, i])) return board[0, i]; // 列胜利
                if (IsWinningLine(board[i, 0], board[i, 1], board[i, 2])) return board[i, 0]; // 行胜利
            }

            // 检查是否有未填满的格子
            foreach (var item in board)
            {
                if (item == 0) return -1; // 游戏未完成
            }

            // 平局
            return 0;
        }

        // 检查三个格子是否构成胜利条件
        private static bool IsWinningLine(int a, int b, int c)
        {
            return a == b && b == c && a != 0;
        }

        public static int IsSolved再优化(int[,] b)
        {
            string[] lines = new string[8];
            for (int i = 0; i < 3; i++)
            {
                lines[i] = $"{b[i, 0]}{b[i, 1]}{b[i, 2]}";
                lines[i + 3] = $"{b[0, i]}{b[1, i]}{b[2, i]}";
            }
            lines[6] = $"{b[0, 0]}{b[1, 1]}{b[2, 2]}";
            lines[7] = $"{b[2, 0]}{b[1, 1]}{b[0, 2]}";

            if (lines.Contains("111")) return 1;
            if (lines.Contains("222")) return 2;
            if (lines.Any(line => line.Contains('0'))) return -1;
            return 0;
        }
    }
}
