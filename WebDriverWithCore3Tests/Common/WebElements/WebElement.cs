using OpenQA.Selenium;
using System;

namespace WebDriverWithCore3Tests.Common.WebElements
{
    public class WebElement
    {
        protected IWebElement PageElement;

        private int? timeout;

        public string ID { get; set; }
        public string XPath { get; set; }
        public string Css { get; set; }

        public IWebElement Element => PageElement ?? FindElement();

        

        public WebElement()
        {

        }

        public WebElement(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));
            ID = id;
        }

        public WebElement(IWebElement webElement)
        {
            this.PageElement = webElement;
        }


        internal IWebElement FindElement()
        {
            throw new NotImplementedException();
        }


    }
}
