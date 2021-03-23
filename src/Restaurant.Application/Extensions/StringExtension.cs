using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Restaurant.Application.Extensions
{
    public static class StringExtension
    {
        public static bool ContainsResearch(this string source, string value)
        {
            var formattedSource = source.ToLower().RemoveAccents();
            var formattedValue = value.ToLower().RemoveAccents();
            return formattedSource.Contains(formattedValue);
        }

        public static string RemoveAccents(this string value)
        {
            bool NotIsNonSpacingMark(Char ch)
            {
                var currentCategory = char.GetUnicodeCategory(ch);
                var NonSpacingCategory = UnicodeCategory.NonSpacingMark;
                return currentCategory != NonSpacingCategory;
            }

            var result = value
                .Normalize(NormalizationForm.FormD)
                .Where(NotIsNonSpacingMark)
                .ToArray();

            return new string(result);
        }
    }
}
