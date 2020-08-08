using OpenQA.Selenium;

namespace WebDriverWithCore3Tests.Common.WebElements
{
    public class LabelElement : WebElement
    {
        public LabelElement()
        {

        }

        public LabelElement(string id) : base(id)
        {

        }

        public LabelElement(IWebElement webElement) : base(webElement)
        {

        }

        public string GetText() => Element.Text;
    }
}
