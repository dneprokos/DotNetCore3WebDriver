using OpenQA.Selenium;
using System;

namespace WebDriverWithCore3Tests.Common.Helpers
{
    public class JavaScriptManager
    {
        /// <summary>
        /// Runs javascript in the current browser and returns result
        /// </summary>
        /// <param name="script"></param>
        /// <param name="paramaters"></param>
        /// <returns></returns>
        public object RunJavaScript(string script, params object[] paramaters) 
        {
            var jsExec = (IJavaScriptExecutor)WebDriverFactory.CurrentDriver;
            try
            {
                var result = jsExec.ExecuteScript(script, paramaters);
                return result;
            }
            catch (Exception)
            {
                Console.WriteLine($"JavaScript {script} execution was failed");
                return false;
            }
        }

        /// <summary>
        /// Run Async javascript in the current browser
        /// </summary>
        /// <param name="script"></param>
        /// <param name="paramaters"></param>
        public void RunJavaScriptAsync(string script, params object[] paramaters) 
        {
            var jsExec = (IJavaScriptExecutor)WebDriverFactory.CurrentDriver;
            try
            {
                var result = jsExec.ExecuteAsyncScript(script, paramaters);
            }
            catch (Exception)
            {
                Console.WriteLine($"Async JavaScript {script} execution was failed");
            }
        }
    }
}
