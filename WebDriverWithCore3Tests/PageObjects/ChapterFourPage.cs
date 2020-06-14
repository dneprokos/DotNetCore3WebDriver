using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using WebDriverWithCore3Tests.Common.Extensions;

namespace WebDriverWithCore3Tests.PageObjects
{
    public class ChapterFourPage
    {
        public IWebDriver Driver { get; set; }
        private readonly SeleniumWaitHelpers seleniumHelper;
        private readonly Actions actions;

        public ChapterFourPage(IWebDriver driver)
        {
            Driver = driver;
            seleniumHelper = new SeleniumWaitHelpers(Driver);
            actions = new Actions(Driver);
        }

        public IWebElement TextBoxTriggersAlert => seleniumHelper.WaitUntilElementExists(By.Id("blurry"));

        public void EnterTextToAlertTextBoxAndMoveMouseOut(string text) 
        {
            TextBoxTriggersAlert.SendKeys(text);

            actions.Click().Build().Perform();
        }

        public string GetAlertTextAndAccept() 
        {
            IAlert alert = Driver.SwitchTo().Alert();
            string text = alert.Text;
            alert.Accept();

            return text;
        }

    }
}
