using FluentAssertions;
using NUnit.Framework;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.PageObjects;

namespace WebDriverWithCore3Tests.Tests
{
    [TestFixture]
    [Parallelizable]
    public class ChapterFourPageTests: TestBase
    {
        private ChapterFourPage chapterFourPage;

        public override void Setup()
        {
            base.Setup();
            chapterFourPage = new ChapterFourPage(WebDriver);
            WebDriver.Url = TestSettingsManager.Chapter4_Page;
            
        }

        [Test]
        public void AlertShouldShowATextEnteredToTheField() 
        {
            //Arrange
            var text = "Testinus";

            //Act
            chapterFourPage.EnterTextToAlertTextBoxAndMoveMouseOut(text);
            string alertText = chapterFourPage.GetAlertTextAndAccept();

            //Assert
            alertText.Should().Be(text);
        }
    }
}
