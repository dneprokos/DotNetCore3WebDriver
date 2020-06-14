﻿using OpenQA.Selenium;
using WebDriverWithCore3Tests.Common.WebDrivers;

namespace WebDriverWithCore3Tests.Common
{
    public class WebDriverFactory
    {
        public static IWebDriver CurrentDriver { get; private set; }


        /// <summary>
        /// Creates concreate driver based on TestSeetingsManager value
        /// </summary>
        /// <returns></returns>
        public static IWebDriver CreateDriver()
        {
            switch (TestSettingsManager.GetBrowser)
            {
                case nameof(SupportedBrowsers.Chrome):
                    CurrentDriver = ChromeWebDriver.Get;
                    break;
            }

            return CurrentDriver;
        }
    }
}