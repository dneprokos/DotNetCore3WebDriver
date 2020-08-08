using OpenQA.Selenium;

namespace WebDriverWithCore3Tests.Common.WebElements
{
    public class TextFieldElement : WebElement
    {
        public TextFieldElement()
        {
        }

        public TextFieldElement(string id) : base(id)
        {
        }

        public TextFieldElement(IWebElement webElement) : base(webElement)
        {
        }

        public TextFieldElement TypeText(string text) 
        {
            Element.SendKeys(text);
            return this;
        }

        public string ReadText()
        {
            return Element.GetAttribute("value");
        }
    }
}
