using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C_练习
{
    /// <summary>
    /// 编写一个函数，给定一个文本字符串（可能带有标点符号和换行符）， 返回出现次数最多的前 3 个单词的数组，按出现次数的降序排列。
    /// 假设：
    /// 单词是一串字母（A 到 Z），可选地包含 ASCII 中的一个或多个撇号 （）。'
    /// 撇号可以出现在单词的开头、中间或结尾（、、 、 都是有效的）'abcabc''abc'ab'c
    /// 任何其他字符（例如 、 、 、 、 ...）都不是单词的一部分，应被视为空格。#\/.
    /// 匹配项应不区分大小写，结果中的单词应为小写。
    /// 平局可以任意打破。
    /// 如果文本包含的唯一单词少于三个，则应返回前 2 个或前 1 个单词，如果文本不包含单词，则应返回空数组。
    /// </summary>
    internal class 最常用的单词
    {
        public static List<string> Top3(string s)
        {
            // 使用正则表达式匹配所有有效的单词（字母和撇号）
            var words = Regex.Matches(s.ToLower(), @"[a-z']+")   // 只匹配字母和撇号
                             .Cast<Match>()
                             .Select(m => m.Value)
                             .Where(word =>
                                 !string.IsNullOrWhiteSpace(word)     // 排除空白
                                 && word != "'"                       // 排除仅为撇号的单词
                                 && !Regex.IsMatch(word, @"^'+$")     // 排除由撇号组成的单词，如 "''", "''''" 等
                                 )
                             .ToList();

            // 根据单词的出现次数进行分组和计数
            var wordCount = words.GroupBy(w => w)
                                 .ToDictionary(g => g.Key, g => g.Count());

            // 按照出现次数降序排列并返回前 3 个
            var topWords = wordCount.OrderByDescending(w => w.Value)
                                    .Take(3)       // 获取前 3 个
                                    .Select(w => w.Key) // 只选择单词
                                    .ToList();

            return topWords;
        }
    }
}
