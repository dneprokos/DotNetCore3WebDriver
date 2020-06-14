using FluentAssertions;
using NUnit.Framework;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.Common.Extensions;
using WebDriverWithCore3Tests.PageObjects;

namespace WebDriverWithCore3Tests.Tests
{
    [TestFixture]
    [Parallelizable]
    public class MainPageNavigationTests: TestBase
    {
        private MainPage mainPage;

        public override void Setup()
        {
            base.Setup();
            WebDriver.Url = TestSettingsManager.GetBaseUrl;
            mainPage = new MainPage(WebDriver);
        }

        [Test]
        [TestCase("Chapter1")]
        [TestCase("Chapter2")]
        [TestCase("Chapter3")]
        [TestCase("Chapter4")]
        [TestCase("Chapter8")]
        public void PageLink_ShouldNavigateToExpectedPage(string pageName) 
        {
            //Arrange
            string expectedPageUrl = pageName.AddValueBefore(TestSettingsManager.GetBaseUrl);

            //Act
            mainPage.ClickPageLink(pageName);

            //Assert
            WebDriver.Url.Should().Be(expectedPageUrl.ToLowerInvariant());          
        }
    }
}
