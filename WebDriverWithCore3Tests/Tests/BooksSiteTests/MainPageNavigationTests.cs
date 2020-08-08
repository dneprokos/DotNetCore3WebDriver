using FluentAssertions;
using NLog;
using NUnit.Framework;
using WebDriverWithCore3Tests.Assertions;
using WebDriverWithCore3Tests.Builders;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.Common.Extensions;
using WebDriverWithCore3Tests.Models;
using WebDriverWithCore3Tests.PageObjects;

namespace WebDriverWithCore3Tests.Tests
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class MainPageNavigationTests : TestBase
    {
        private MainPage mainPage;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public override void Setup()
        {
            base.Setup();
            WebDriverFactory.CurrentDriver.Url = TestSettingsManager.GetBaseUrl;
            mainPage = new MainPage();
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
            WebDriverFactory.CurrentDriver.Url.Should().Be(expectedPageUrl.ToLowerInvariant());          
        }

        [Test]
        [Category("Smoke")]
        public void FakerUser_UserShouldBeGenerated() 
        {
            //Arrange
            //Act
            UserTestModel testUser = new UserBuilder()
                .AddFirstName()
                .AddLastName()
                .Build();

            //Assert
            UserTestModelAssertion.AssertFakeUserDetails(testUser);
        }
    }
}
