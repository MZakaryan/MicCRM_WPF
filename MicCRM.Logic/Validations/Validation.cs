using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MicCRM.Logic.Helpers
{
    public static class Validation
    {
        public static bool IsPhoneFormat(string phoneNumber)
        {
            if (phoneNumber.Length < 6 || phoneNumber == null)
                return false;
            if (phoneNumber.StartsWith("+") && phoneNumber.Select(c => c == '+').Count(c => c) == 1)
                return phoneNumber.Substring(1).All(c => Char.IsNumber(c));
            else
                return phoneNumber.All(c => Char.IsNumber(c));
        }

        public static bool IsEmailFormat(string email)
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
               + @"([-a-z0-9!#$%&'*/=^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
               + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            Regex ValidEmailRegex = new Regex(validEmailPattern, RegexOptions.IgnoreCase);

            return  ValidEmailRegex.IsMatch(email);
        }

        public static bool IsTextFormat(string str)
        {
            return str.All(c => Char.IsLetter(c));
        }

        public static bool IsAddingFieldsCompleted(string firstName, string lastName, string phone, string email)
        {
            bool isCompleted = !string.IsNullOrEmpty(firstName) &&
                               !string.IsNullOrEmpty(lastName) &&
                               !string.IsNullOrEmpty(phone) &&
                               !string.IsNullOrEmpty(email) &&
                               IsTextFormat(firstName) &&
                               IsTextFormat(lastName) &&
                               IsPhoneFormat(phone) &&
                               IsEmailFormat(email);
            return isCompleted;
        }
    }
}
