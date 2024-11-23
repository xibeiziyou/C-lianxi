using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_练习
{
    /// <summary>
    /// 让我们考虑这个例子（以一般格式编写的数组）：
    ///ls = [0, 1, 3, 6, 10]
    ///它包括以下部分：
    ///ls = [0, 1, 3, 6, 10]
    ///ls = [1, 3, 6, 10]
    ///ls = [3, 6, 10]
    ///ls = [6, 10]
    ///ls = [10]
    ///ls = []
    ///相应的总和是 （放在一个列表中）：[20, 20, 19, 16, 10, 0]
    ///该函数（或其他语言中的变体）将采用一个列表作为参数，并返回上面定义的其部分之和的列表。parts_sumsls
    /// </summary>
    internal class 零件之和
    {
        public static int[] PartsSums(int[] ls)
        {
            int sum = 0;
            int[] ints = new int[ls.Length + 1];
            for (int i = 0; i < ls.Length; i++)
            {
                for (int j = i; j < ls.Length;j++)
                {
                    sum += ls[j];
                }
                ints[i] = sum;
                sum = 0;
            }
            // your code
            return ints;
        }
        public static int[] PartsSums优化(int[] ls)
        {
            int sum = 0;
            int[] result = new int[ls.Length + 1];

            // 从后往前计算累积和
            for (int i = ls.Length - 1; i >= 0; i--)
            {
                sum += ls[i];
                result[i] = sum;
            }

            // 最后一个元素是0，已经是默认值，无需设置
            return result;
        }

    }
}
