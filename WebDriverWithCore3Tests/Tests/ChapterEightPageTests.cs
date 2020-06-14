using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.Common.Helpers;
using WebDriverWithCore3Tests.PageObjects;

namespace WebDriverWithCore3Tests.Tests
{
    public class ChapterEightPageTests: TestBase
    {
        ChapterEightPage chapterEightPage;

        public override void Setup()
        {
            base.Setup();
            chapterEightPage = new ChapterEightPage(WebDriver);
            WebDriver.Url = TestSettingsManager.Chapter8_Page;
        }

        [Test]
        public void AddNewCookiesTest() 
        {
            //Arrange
            WebDriver.Navigate().Refresh();
            WebDriver.Manage().Cookies.DeleteAllCookies();
            var expectedCookieNames = new List<string> { "secondcookie" };

            //Act
            chapterEightPage.createSecondCookieButton.Click();
            List<string> cookieNames = WebDriver.Manage().Cookies.AllCookies
                .Select(cookie => cookie.Name).ToList();

            //Assert
            cookieNames.Should().BeEquivalentTo(expectedCookieNames);
        }

        [Test]
        public void AddNewSessionItem() 
        {
            //Arrange
            var sessionStorage = new SessionStorage(WebDriver);
            var key = "userName";
            var value = "Kostas";

            //Act
            sessionStorage.SetItem(key, value);
            var actValue = sessionStorage.GetItem(key);

            //Assert
            actValue.Should().Be(value);
        }
    }
}
