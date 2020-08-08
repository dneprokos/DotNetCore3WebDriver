using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace WebDriverWithCore3Tests.Common
{
    public class WebDriverFactory
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private static readonly object collectionLocker = new object();

        private static readonly ConcurrentDictionary<IWebDriver, string> WebDriverCollection 
            = new ConcurrentDictionary<IWebDriver, string>();

        private static readonly List<int> runningChromeProcesses = Process.GetProcessesByName("chrome")
            .Select(process => process.Id)
            .ToList();


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
            logger.Info("Starting driver with the following options: \n"
                + "Browser: " + driverOptions.Browser + 
                "\nIsHeadless: " + driverOptions.IsHeadless);
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

            //Creates new driver. Adds it as current driver and then to drivers colletion
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

            //Quits driver in case of exception
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed)
                && TestContext.CurrentContext.Result.Message.Contains("WebDriverException"))
            {
                currentWebDriver.Quit();
                WebDriverCollection.TryRemove(currentWebDriver, out string testID);
            }

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
                        options.AddArgument("window-size=1920, 1080"); //TODO: Read it from configuration
                        options.AddArgument("no-sandbox");

                     CurrentDriver = new ChromeDriver(driverService, options);  
                     break;
                }
            }
            return CurrentDriver;
        }

        public void QuitAndKillProcesses() 
        {
            var timer = new Stopwatch();
            timer.Start();

            while (WebDriverCollection.Values.Any(driver => !string.IsNullOrEmpty(driver)) && timer.Elapsed.Seconds < 60)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1)); //TODO: Need to fix in the future
            }

            WebDriverCollection.ToList().ForEach(pair => pair.Key.Quit());
            WebDriverCollection.Clear();

            List<int> chromeProcessesIds = Process.GetProcessesByName("chrome")
                .Select(process => process.Id)
                .ToList();

            List<int> processIds = chromeProcessesIds.Except(runningChromeProcesses).ToList();

            processIds.ForEach(processId =>
            {
                try
                {
                    Process.GetProcessById(processId).Kill();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        public void KillChromeProcesses(string processName = "chromedriver", bool applyForCreatedOnly = true) 
        {
            foreach (Process process in Process.GetProcessesByName(processName))
            {
                string testRunPath = string.Concat(Directory.GetCurrentDirectory(), @"\", $"{processName}.exe");
                string processPath = process.MainModule.FileName;

                if (applyForCreatedOnly && testRunPath != processPath)
                    continue;

                try
                {
                    process.Kill();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}