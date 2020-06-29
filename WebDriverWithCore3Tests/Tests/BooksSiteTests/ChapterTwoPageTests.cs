using FluentAssertions;
using NUnit.Framework;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.PageObjects;

namespace WebDriverWithCore3Tests.Tests
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class ChapterTwoPageTests : TestBase
    {
        private ChapterTwoPage chapterTwoPage;

        public override void Setup()
        {
            base.Setup();
            chapterTwoPage = new ChapterTwoPage();
            WebDriverFactory.CurrentDriver.Url = TestSettingsManager.Chapter2_Page;
        }

        [Test]
        public void TextWithRandomLocatorSouldBeFound() 
        {
            //Arrange
            var expectedText = 
                "This element has a ID that changes every time the page is loaded";

            //Act

            //Assert
            chapterTwoPage.RandomIdElement.Text.Should().Be(expectedText);

            //Act
            WebDriverFactory.CurrentDriver.Navigate().Refresh();

            //Assert
            chapterTwoPage.RandomIdElement.Text.Should().Be(expectedText);
        }
    }
}
