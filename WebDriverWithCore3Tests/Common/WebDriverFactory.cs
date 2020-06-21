using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace WebDriverWithCore3Tests.Common
{
    public class WebDriverFactory
    {
        private static readonly object collectionLocker = new object();

        private static readonly ConcurrentDictionary<IWebDriver, string> WebDriverCollection 
            = new ConcurrentDictionary<IWebDriver, string>();


        public static IWebDriver CurrentDriver 
        { 
            get 
            {
                return WebDriverCollection.First(collection => collection.Value == TestContext.CurrentContext.Test.ID).Key;
            } 
            set 
            {
                WebDriverCollection.TryAdd(value, TestContext.CurrentContext.Test.ID);
            } 
        }

        /// <summary>
        /// Setups and starts webdriver based on it's options
        /// </summary>
        /// <param name="driverOptions"></param>
        public void Start(DriverOptions driverOptions) 
        { 
            if (driverOptions.Equals(null)) 
            {
                throw new ArgumentException(MethodBase.GetCurrentMethod().Name);
            }

            lock (collectionLocker) 
            { 
                if (WebDriverCollection.Any(dict => dict.Value.Equals(string.Empty))) 
                {
                    IWebDriver driver = WebDriverCollection.First(dict => dict.Value.Equals(string.Empty)).Key;
                    WebDriverCollection.TryUpdate(driver, TestContext.CurrentContext.Test.ID, string.Empty);

                    return;
                }
            }
            CurrentDriver = GetWebDriver(driverOptions);
            WebDriverCollection.TryAdd(CurrentDriver, TestContext.CurrentContext.Test.ID);
        }

        /// <summary>
        /// Stops webdriver
        /// </summary>
        public void Stop() 
        {
            IWebDriver currentWebDriver = WebDriverCollection
                .First(dict => dict.Value.Equals(TestContext.CurrentContext.Test.ID))
                .Key;

            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed) 
                && TestContext.CurrentContext.Result.Message.Contains("WebDriverException")) 
            {
                currentWebDriver.Quit();
                WebDriverCollection.TryRemove(currentWebDriver, out string testID);
            }

            currentWebDriver.Quit();
            WebDriverCollection
                .TryUpdate(currentWebDriver, string.Empty, TestContext.CurrentContext.Test.ID);
        }


        private IWebDriver GetWebDriver(DriverOptions driverOptions)
        {
            switch (driverOptions.Browser)
            {
                case (nameof(SupportedBrowsers.Chrome)):
                {
                     ChromeDriverService driverService 
                            = ChromeDriverService.CreateDefaultService(AppDomain.CurrentDomain.BaseDirectory);
                     var options = new ChromeOptions();
                     CurrentDriver = new ChromeDriver(driverService, options);
                     FixDriverExecutionDelay(CurrentDriver);   
                     break;
                }
            }
            return CurrentDriver;
        }

        private void FixDriverExecutionDelay(IWebDriver currentDriver)
        {
            PropertyInfo executorProperty = typeof(RemoteWebDriver).GetProperty("CommandExecutor",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetProperty);

            ICommandExecutor commandExecutor = (ICommandExecutor)executorProperty.GetValue(currentDriver);

            var remoteServerUriField = commandExecutor.GetType().GetField("remoteServerUri",
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField);

            if (remoteServerUriField.Equals(null)) 
            {
                FieldInfo internalExecutorField = commandExecutor.GetType().GetField("internalExecutor",
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);

                commandExecutor = (ICommandExecutor)internalExecutorField.GetValue(commandExecutor);

                remoteServerUriField = commandExecutor.GetType().GetField("remoteServerUri",
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField);
            }
            if (!remoteServerUriField.Equals(null))  
            {
                string remoteServerUri = remoteServerUriField.GetValue(commandExecutor).ToString();
                var localhostUriPrefix = "http://localhost";

                if (remoteServerUri.StartsWith(localhostUriPrefix)) 
                {
                    remoteServerUri = remoteServerUri.Replace(localhostUriPrefix, "http://127.0.01");
                    remoteServerUriField.SetValue(commandExecutor, new Uri(remoteServerUri));
                }
            }

        }
    }
}