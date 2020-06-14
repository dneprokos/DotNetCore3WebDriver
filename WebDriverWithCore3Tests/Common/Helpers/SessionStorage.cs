using OpenQA.Selenium;

namespace WebDriverWithCore3Tests.Common.Helpers
{
    public class SessionStorage
    {
        IWebDriver WebDriver;

        public SessionStorage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        /// <summary>
        /// Sets session storage item
        /// </summary>
        /// <param name="key">item key</param>
        /// <param name="value">item value</param>
        public void SetItem(string key, string value) 
        {
            var jsScript = 
                $"window.sessionStorage.setItem('{key}','{value}')";

            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            js.ExecuteScript(jsScript);
        }

        public void SetItem(string key, int value)
        {

        }

        public void SetItem(string key, bool value)
        {

        }

        /// <summary>
        /// Gets session storage item by id
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        public string GetItem(string key)
        {
            var jsScript =
                $"return window.sessionStorage.getItem('{key}')";

            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            string value = (string)js.ExecuteScript(jsScript);

            return value;
        }

    }
}
