using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C_练习
{
    internal class 判断是否是有效的电话号码
    {
        public static bool ValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^[(]\d{3}[)]\s\d{3}[-]\d{4}$");
        }

        private static readonly string PhonePattern = @"^[(]\d{3}[)]\s\d{3}[-]\d{4}$";

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return false;

            return Regex.IsMatch(phoneNumber, PhonePattern);
        }
    }
}
