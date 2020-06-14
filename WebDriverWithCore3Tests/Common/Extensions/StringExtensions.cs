using System;

namespace WebDriverWithCore3Tests.Common.Extensions
{
    public static class StringExtensions
    {
        public static string AddValueBefore(this String originalValue,  string additionalValue) 
        {
            return additionalValue + originalValue;
        }
    }
}
