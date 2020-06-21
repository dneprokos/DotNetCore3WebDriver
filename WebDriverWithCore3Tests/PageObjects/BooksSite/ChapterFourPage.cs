using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.Common.Extensions;

namespace WebDriverWithCore3Tests.PageObjects
{
    public class ChapterFourPage
    {
        private readonly Actions actions;

        public ChapterFourPage()
        {
            actions = new Actions(WebDriverFactory.CurrentDriver);
        }

        public IWebElement TextBoxTriggersAlert => WebDriverFactory.CurrentDriver
            .WaitForElement(By.Id("blurry"));

        public IWebElement MouseOverText => WebDriverFactory.CurrentDriver
            .WaitForElement(By.Id("hoverOver"));


        public void MoveMouseOverTextTriggersAlert() 
        {
            actions.MoveToElement(MouseOverText).Perform();
        }

        public void EnterTextToAlertTextBoxAndMoveMouseOut(string text) 
        {
            TextBoxTriggersAlert.SendKeys(text);

            actions.Click().Build().Perform();
        }

        public string GetAlertTextAndAccept() 
        {
            IAlert alert = WebDriverFactory.CurrentDriver.SwitchTo().Alert();
            string text = alert.Text;
            alert.Accept();

            return text;
        }

    }
}
