using OpenQA.Selenium;
using System;

namespace WebDriverWithCore3Tests.Common.Helpers
{
    public class SessionStorage
    {
        IWebDriver WebDriver;

        public SessionStorage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

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
