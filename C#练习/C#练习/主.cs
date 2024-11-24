using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_练习
{
    internal class 主
    {
        static void Main(string[] args)
        {
            int[,] board = new int[,] { { 1, 2, 1 }, { 1, 2, 2 }, { 2, 1, 2 } };
            Console.WriteLine(井字棋状况判定.IsSolved再优化(board));
        }
    }
}
