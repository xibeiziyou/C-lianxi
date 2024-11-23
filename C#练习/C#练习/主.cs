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
            int[] ints = { 35, 22345,452, 32344,5633,346,234,252 };
            int[] its = 零件之和.PartsSums优化(ints);
            foreach (var item in its)
            {
                Console.WriteLine(item);
            }
        }
    }
}
