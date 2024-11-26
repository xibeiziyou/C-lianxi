using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace C_练习
{
    /// <summary>
    /// 实现一个函数，该函数接收两个 IPv4 地址，并返回它们之间的地址数（包括第一个地址，不包括最后一个地址）。
    /// 所有输入都将是字符串形式的有效 IPv4 地址。最后一个地址将始终大于第一个地址。
    /// 例子
    /// * With input "10.0.0.0", "10.0.0.50"  => return   50 
    /// * With input "10.0.0.0", "10.0.1.0"   => return  256 
    /// * With input "20.0.0.10", "20.0.1.0"  => return  246
    /// </summary>
    internal class 返回ip4之间的地址数
    {
        public static long IpsBetween(string start, string end)
        {
            string[] strings0 = start.Split('.');
            string[] strings1 = end.Split('.');
            long shu = 0;
            for (int i = 0; i < 4; i++)
            {
                shu = (shu + int.Parse(strings1[i]) - int.Parse(strings0[i])) * 256;
            }
            shu = shu / 256;
            return shu;
        }
        public static long IpsBetween优化(string start, string end)
        {
            // 将IP地址分割成数组
            var startParts = start.Split('.');
            var endParts = end.Split('.');

            long result = 0;

            // 逐位计算差值
            for (int i = 0; i < 4; i++)
            {
                result = result * 256 + (int.Parse(endParts[i]) - int.Parse(startParts[i]));
            }

            return result;
        }
        public static long IpsBetween简化(string start, string end)
        {
            long startIp = BitConverter.ToUInt32(IPAddress.Parse(start).GetAddressBytes().Reverse().ToArray(), 0);
            long endIp = BitConverter.ToUInt32(IPAddress.Parse(end).GetAddressBytes().Reverse().ToArray(), 0);
            return endIp - startIp;
        }
    }
}
