using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverWithCore3Tests.Common.WebElements
{
    public class ButtonElement : WebElement
    {
        public ButtonElement()
        {
        }

        public ButtonElement(string id) : base(id)
        {
        }

        public ButtonElement(IWebElement webElement) : base(webElement)
        {
        }
    }
}
