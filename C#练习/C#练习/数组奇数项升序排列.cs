using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_练习
{
    internal class 数组奇数项升序排列
    {
        public static Queue<int> ints = new Queue<int>();

        // 将奇数从数组中取出并按升序排列后加入队列
        public static Queue<int> Zan(int[] z)
        {
            // 获取所有奇数并排序
            var oddNumbers = z.Where(x => x % 2 != 0).OrderBy(x => x).ToList();

            // 将排序后的奇数加入队列
            foreach (var num in oddNumbers)
            {
                ints.Enqueue(num);
            }

            return ints;
        }

        // 将数组中的奇数替换为队列中的元素
        public static int[] Chu(int[] z, Queue<int> ints)
        {
            for (int w = 0; w < z.Length; w++)
            {
                if (z[w] % 2 != 0) // 如果是奇数
                {
                    z[w] = ints.Dequeue(); // 用队列中的值替换
                }
            }
            return z;
        }

        // 完整排序过程：将奇数升序排列并填回原数组
        public static int[] SortArray(int[] array)
        {
            // 将奇数排序并放入队列
            Queue<int> sortedOdds = Zan(array);

            // 将数组中的奇数项替换为已排序的奇数
            return Chu(array, sortedOdds);
        }
        //简洁版
        public static int[] SortArray简洁版(int[] array)
        {
            // 步骤 1: 提取数组中的奇数并升序排序
            Queue<int> odds = new Queue<int>(array.Where(e => e % 2 == 1).OrderBy(e => e));

            // 步骤 2: 将排序后的奇数填回原数组中的奇数位置
            return array.Select(e => e % 2 == 1 ? odds.Dequeue() : e).ToArray();
        }
    }
}
