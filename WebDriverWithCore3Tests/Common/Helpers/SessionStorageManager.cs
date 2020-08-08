namespace WebDriverWithCore3Tests.Common.Helpers
{
    public class SessionStorageManager
    {
        /// <summary>
        /// Sets session storage item
        /// </summary>
        /// <param name="key">item key</param>
        /// <param name="value">item value</param>
        public void SetItem(string key, string value)
        {
            TestFramework.JavaScriptHelper
                .RunJavaScript($"window.sessionStorage.setItem('{key}','{value}')");
        }

        /// <summary>
        /// Gets session storage item by id
        /// </summary>
        /// <param name="key">item key</param>
        /// <returns></returns>
        public string GetItem(string key)
        {
            return TestFramework.JavaScriptHelper
                .RunJavaScript($"return window.sessionStorage.getItem('{key}')").ToString();
        }

    }
}
