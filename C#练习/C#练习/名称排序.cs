using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_练习
{
    /// <summary>
    /// John 邀请了一些朋友。他的名单是：
    /// s = "Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
    /// 您能否制作一个程序
    /// 使此字符串大写
    /// 使其按姓氏的字母顺序排序。
    /// 当姓氏相同时，按名字对它们进行排序。 客人的姓氏和名字出现在结果中，用逗号分隔的括号之间。
    /// 所以 function 的结果将是：meeting(s)
    /// "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)"
    /// 在两个具有相同姓氏的不同家庭中，两个人也可能具有相同的名字。
    /// </summary>
    internal class 名称排序
    {
        public static string Meeting(string s)
        {
            List<List<string>> strings = new List<List<string>>();

            // 处理输入字符串，分割每个名字
            foreach (var item in s.Split(";"))
            {
                List<string> value = new List<string>();
                value.Add(item.Split(":")[0]);  // 名字
                value.Add(item.Split(":")[1]);  // 姓氏
                strings.Add(value);
            }

            // 根据姓氏（字符串的第二部分）然后按名字排序（字符串的第一部分）
            var sortedStrings = strings.OrderBy(x => x[1].ToUpper()).ThenBy(x => x[0].ToUpper()).ToList();

            // 构建输出字符串
            string result = "";
            foreach (var item in sortedStrings)
            {
                result += $"({item[1].ToUpper()}, {item[0].ToUpper()})";
            }

            return result;
        }
    //    public static string Meeting简(string s) => (
    //    string.Join("", s                    // 1. 用 Join 将数组拼接成一个字符串
    //                .ToUpper()              // 2. 将整个字符串转为大写
    //                .Split(';')             // 3. 按分号分割字符串，得到每个 "名字:姓氏" 的片段
    //                .Select(uu => uu.Split(':'))   // 4. 将每个片段按冒号分割成 "名字" 和 "姓氏"
    //                .OrderBy(f => f[1])     // 5. 按姓氏（第二部分）进行排序
    //                .ThenBy(g => g[0])      // 6. 如果姓氏相同，再按名字（第一部分）排序
    //                .Select(a => "(" + a[1] + ", " + a[0] + ")") // 7. 格式化为 "(姓氏, 名字)" 的形式
    //);
    }
}
