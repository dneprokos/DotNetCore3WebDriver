using System;

namespace WebDriverWithCore3Tests.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Adds new string before current string
        /// </summary>
        /// <param name="originalValue"></param>
        /// <param name="additionalValue">new string value you want to add</param>
        /// <returns></returns>
        public static string AddValueBefore(this String originalValue,  string additionalValue) 
        {
            return additionalValue + originalValue;
        }
    }
}
