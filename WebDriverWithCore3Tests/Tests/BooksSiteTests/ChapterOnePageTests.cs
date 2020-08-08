using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.PageObjects;

namespace WebDriverWithCore3Tests.Tests
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class ChapterOnePageTests : TestBase
    {
        private ChapterOnePage chapterOnePage;

        public override void Setup()
        {
            base.Setup();
            chapterOnePage = new ChapterOnePage();
            WebDriverFactory.CurrentDriver.Url = TestSettingsManager.Chapter1_Page;
        }

        [Test]
        public void ButtonsCheckTest() 
        {
            //Arrange
            var selectDropDownValue1 = "Selenium Core";
            var selectDropDownValue2 = "Selenium Grid";
            var checkedAttribute = "checked";

            //Act
            chapterOnePage.ClickRadioButton();
            chapterOnePage.ClickCheckBox();
            chapterOnePage.SelectFromDropDownMenu(selectDropDownValue1);

            //Assert
            using (new AssertionScope()) 
            {
               chapterOnePage.RadioButton.GetAttribute(checkedAttribute).Should().Be("true");
               chapterOnePage.CheckBox.GetAttribute(checkedAttribute).Should().Be("true");
               chapterOnePage.DropDownMenu.SelectedOption.Text.Should().Be(selectDropDownValue1);               
            }

            //Act
            chapterOnePage.ClickCheckBox();
            chapterOnePage.SelectFromDropDownMenu(selectDropDownValue2);

            //Assert
            using (new AssertionScope())
            {
                chapterOnePage.CheckBox.GetAttribute(checkedAttribute).Should().Be(null);
                chapterOnePage.DropDownMenu.SelectedOption.Text.Should().Be(selectDropDownValue2);
            }
        }

        [Test]
        public void LoadTextToThePage_ShouldBeLoadedNumberOfTimes() 
        {
            //Arrange

            //Act
            chapterOnePage.SendTextButton.Click();
            chapterOnePage.SendTextButton.Click();

            List<string> newTexts = chapterOnePage.AddedTextElements
                .ToList()
                .Select(el => el.Text)
                .ToList();

            //Assert
            using (new AssertionScope()) 
            {
                newTexts.Count.Should().Be(2);
                newTexts.ForEach(text => text.Should().Be("I have been added with a timeout"));
            }              
        }
    }
}
