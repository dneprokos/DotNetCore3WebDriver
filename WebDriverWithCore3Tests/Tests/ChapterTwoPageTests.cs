using FluentAssertions;
using NUnit.Framework;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.PageObjects;

namespace WebDriverWithCore3Tests.Tests
{
    public class ChapterTwoPageTests: TestBase
    {
        private ChapterTwoPage chapterTwoPage;

        public override void Setup()
        {
            base.Setup();
            chapterTwoPage = new ChapterTwoPage(WebDriver);
            WebDriver.Url = TestSettingsManager.Chapter2_Page;
        }

        [Test]
        public void TextWithRandomLocatorSouldBeFound() 
        {
            //Arrange
            var expectedText = 
                "This element has a ID that changes every time the page is loaded";

            //Act

            //Assert
            chapterTwoPage.randomIdElement.Text.Should().Be(expectedText);

            //Act
            WebDriver.Navigate().Refresh();

            //Assert
            chapterTwoPage.randomIdElement.Text.Should().Be(expectedText);
        }
    }
}
