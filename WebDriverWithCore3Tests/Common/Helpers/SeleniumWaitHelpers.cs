using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebDriverWithCore3Tests.Common.Helpers
{
    public class SeleniumWaitHelpers
    {
        /// <summary>
        /// Waits during defined time until element is available or fails if it's not 
        /// </summary>
        /// <param name="locator">Element locator</param>
        /// <param name="maxSeconds">Maximum wait timeout. Default value was also defined</param>
        /// <returns></returns>
        public IWebElement WaitUntilElementExists(By locator, int maxSeconds = 30)
        {
            return new WebDriverWait(WebDriverFactory.CurrentDriver, TimeSpan.FromSeconds(maxSeconds)).Until(dr => dr.FindElement(locator));
        }

        /// <summary>
        /// Waits during defined time until all elements are visible or fails if it's not 
        /// </summary>
        /// <param name="locator">Elements locator</param>
        /// <param name="maxSeconds">Maximum wait timeout. Default value was also defined</param>
        /// <returns></returns>
        public List<IWebElement> WaitUntilElementsExists(By locator, int maxSeconds = 30)
        {
            return new WebDriverWait(WebDriverFactory.CurrentDriver, TimeSpan.FromSeconds(maxSeconds))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator))
                .ToList();
        }
    }
}
