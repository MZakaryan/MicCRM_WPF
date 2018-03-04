using MicCRM.Domain.Entities;
using MicCRM.Logic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MicCRM.Logic.Helpers
{
    public static class Helper
    {
        public static string HashSHA1(string value)
        {
            var sha1 = SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public static DateTime GetDate(string stringdate)
        {
            string[] date = stringdate.Split('/');
            return new DateTime(Convert.ToInt32(date[2]), 
                                Convert.ToInt32(date[0]), 
                                Convert.ToInt32(date[1])).Date;
        } 
    }
}
