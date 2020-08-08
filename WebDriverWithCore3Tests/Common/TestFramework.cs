using WebDriverWithCore3Tests.Common.Helpers;

namespace WebDriverWithCore3Tests.Common
{
    public static class TestFramework
    {
        public static WebDriverFactory WebDriver => new WebDriverFactory();
        public static JavaScriptManager JavaScriptHelper => new JavaScriptManager();

    }
}
