using FluentAssertions;
using NUnit.Framework;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.PageObjects;

namespace WebDriverWithCore3Tests.Tests
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class ChapterFourPageTests: TestBase
    {
        private ChapterFourPage chapterFourPage;

        public override void Setup()
        {
            base.Setup();
            chapterFourPage = new ChapterFourPage();
            WebDriverFactory.CurrentDriver.Url = TestSettingsManager.Chapter4_Page;
            
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

        [Test]
        public void AlertShouldAppearAfterMouseOverElement() 
        {
            //Arrange
            var text = "on MouseOver worked";

            //Act
            chapterFourPage.MoveMouseOverTextTriggersAlert();
            string alertText = chapterFourPage.GetAlertTextAndAccept();

            //Assert
            alertText.Should().Be(text);
        }
    }
}
