using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverWithCore3Tests.Common.Extensions
{
    public static class WebDriverExtension
    {
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
