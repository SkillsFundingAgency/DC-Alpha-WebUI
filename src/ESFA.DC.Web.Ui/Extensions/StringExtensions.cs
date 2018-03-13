using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DC.Web.Ui.Extensions
{
    public static class StringExtensions
    {
        private static Random random = new Random();

        public static string AppendRandomString(this string value, int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var randomString = new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return $"{value}-{randomString}";
        }

    }
}
