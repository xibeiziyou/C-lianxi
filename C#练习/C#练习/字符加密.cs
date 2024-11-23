using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_练习
{
    /// <summary>
    /// 加密这个！
    /// 以下是条件：
    /// 您的消息是一个包含空格分隔单词的字符串。
    /// 您需要使用以下规则加密消息中的每个单词：
    ///   第一个字母必须转换为其 ASCII 码。
    ///   第二个字母必须与最后一个字母交换
    ///   保持简单：输入中没有特殊字符。
    /// 例子:
    /// Kata.EncryptThis("Hello") == "72olle"
    /// Kata.EncryptThis("good") == "103doo"
    /// Kata.EncryptThis("hello world") == "104olle 119drlo"
    /// </summary>
    internal class 字符加密
    {
        public static string EncryptThis(string input)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (input != "")
            {
                char[] qie = { ' ' };
                string[] zu = input.Split(qie, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < zu.Length; i++)
                {
                    StringBuilder sb = new StringBuilder(zu[i]);
                    if (sb.Length > 2)
                    {
                        var a = sb[1];
                        sb[1] = sb[sb.Length - 1];
                        sb[sb.Length - 1] = a;
                    }
                    var b = sb[0];
                    sb.Remove(0, 1);
                    sb.Insert(0, (int)b);
                    stringBuilder.Append(sb);
                    if(i==zu.Length-1)continue;
                    stringBuilder.Append(" ");
                }
                string inp = stringBuilder.ToString();
                return inp;
            }
            else
            {
                return input;
            }
            
            // Implement me! :)
        }
    }
}
