using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace WebDriverWithCore3Tests.Common.Extensions
{
    public static class WebDriverExtension
    {
        /// <summary>
        /// Wait for element and return or throw exception 
        /// </summary>
        /// <param name="driver">Webdriver instance</param>
        /// <param name="locator">Locator of the element you want to find</param>
        /// <param name="secondsTimeOut">Maximum wait time</param>
        /// <returns></returns>
        public static IWebElement WaitForElement(this IWebDriver driver, By locator, 
            int secondsTimeOut = 5) //TODO: Read it from configuration
        { 
            if (secondsTimeOut <= 0) 
              return driver.FindElement(locator);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsTimeOut));

            try
            {
                return wait.Until(dr => dr.FindElement(locator));
            }
            catch (WebDriverTimeoutException exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }          
        }

        public static IWebElement WaitForElement(this IWebElement element, By locator,
            int secondsTimeOut = 5) //TODO: Read it from configuration
        {
            if (secondsTimeOut <= 0)
                return element.FindElement(locator);

            var wait = new WebDriverWait(
                WebDriverFactory.CurrentDriver, 
                TimeSpan.FromSeconds(secondsTimeOut));

            try
            {
                return wait.Until(dr => element.FindElement(locator));
            }
            catch (WebDriverTimeoutException exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        } 



        /// <summary>
        /// Wait for elements and return or throw exception
        /// </summary>
        /// <param name="driver">Webdriver instance</param>
        /// <param name="locator">Locator of the element you want to find</param>
        /// <param name="secondsTimeOut"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<IWebElement> WaitForElements(this IWebDriver driver, By locator,
            int secondsTimeOut = 5) //TODO: Read it from configuration
        {
            if (secondsTimeOut <= 0)
                return driver.FindElements(locator);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsTimeOut));

            try
            {
                return wait.Until(dr => dr.FindElements(locator));
            }
            catch (WebDriverTimeoutException exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        public static IReadOnlyCollection<IWebElement> WaitForElements(this IWebElement element, By locator,
            int secondsTimeOut = 5) //TODO: Read it from configuration
        {
            if (secondsTimeOut <= 0)
                return element.FindElements(locator);

            var wait = new WebDriverWait(
                WebDriverFactory.CurrentDriver,
                TimeSpan.FromSeconds(secondsTimeOut));

            try
            {
                return wait.Until(dr => element.FindElements(locator));
            }
            catch (WebDriverTimeoutException exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }
        }

        /// <summary>
        /// Eneters to Frame
        /// </summary>
        /// <param name="webDriver"></param>
        /// <param name="frameNameOrId"></param>
        public static void SwitchToFrame(this IWebDriver webDriver, string frameNameOrId) 
        {
            webDriver.SwitchTo().Frame(frameNameOrId);
        }

        /// <summary>
        /// Exists from Frame to default DOM content
        /// </summary>
        /// <param name="webDriver"></param>
        public static void SwitchToDefaultContent(this IWebDriver webDriver)
        {
            webDriver.SwitchTo().DefaultContent();
        }
    }
}
