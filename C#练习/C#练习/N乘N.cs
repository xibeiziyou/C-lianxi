using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_练习
{
    internal class N乘N
    {
        //打印乘法表
        public static int[,] MultiplicationTable(int size)
        {
            int[,] 大 = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++) 
                {
                    大[i,j] = (i + 1) * (j + 1);
                } 
            }
            return 大;//your table
        }
    }
}
