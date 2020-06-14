using NUnit.Framework;

namespace WebDriverWithCore3Tests.Common
{
    /// <summary>
    /// Class properties retrives values from current .runsettings file
    /// </summary>
    public class TestSettingsManager
    {
        public static string GetBrowser => TestContext.Parameters["browser"];
        public static string GetUserName => TestContext.Parameters["userName"];
        public static string GetPassword => TestContext.Parameters["password"];
        public static string GetBaseUrl => TestContext.Parameters["baseUrl"];
        public static string Chapter1_Page => GetBaseUrl + TestContext.Parameters["chapter1"];
        public static string Chapter2_Page => GetBaseUrl + TestContext.Parameters["chapter2"];
        public static string Chapter3_Page => GetBaseUrl + TestContext.Parameters["chapter3"];
        public static string Chapter4_Page => GetBaseUrl + TestContext.Parameters["chapter4"];
        public static string Chapter5_Page => GetBaseUrl + TestContext.Parameters["chapter5"];
        public static int DefaultTimeOut => int.Parse(TestContext.Parameters["waitTimeOut"]);
    }
}
