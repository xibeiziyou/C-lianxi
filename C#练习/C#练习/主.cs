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
            string a = "";
            foreach (var item in 最常用的单词.Top3(a))
            {
                Console.WriteLine(item);
            }
        }
    }
}
