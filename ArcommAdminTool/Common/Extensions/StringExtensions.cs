using System.Text.RegularExpressions;

namespace ArcommAdminTool.Common.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveNonDecimalChars(this string st)
        {
            return Regex.Replace(st, @"[^\d\.]", "");
        }

        public static bool IsEmpty(this string st)
        {
            return st.Equals(string.Empty);
        }
    }
}