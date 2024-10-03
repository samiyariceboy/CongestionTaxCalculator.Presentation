using System.Text.RegularExpressions;

namespace CongestionTaxCalculator.Domain.Common.Utilities
{
    public static partial class StringExtentionMethods
    {
        public static string? RemoveWhitespace(this string? value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            var result = MyRegex().Replace(value, "");
            return result;
        }

        [GeneratedRegex("\\s")]
        private static partial Regex MyRegex();
    }
}
