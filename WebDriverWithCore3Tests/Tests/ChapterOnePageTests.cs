using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.PageObjects;

namespace WebDriverWithCore3Tests.Tests
{
    public class ChapterOnePageTests: TestBase
    {
        private ChapterOnePage chapterOnePage;

        public override void Setup()
        {
            base.Setup();
            chapterOnePage = new ChapterOnePage(WebDriver);
            WebDriver.Url = TestSettingsManager.Chapter1_Page;
        }

        [Test]
        public void ButtonsCheckTest() 
        {
            //Arrange
            string selectDropDownValue1 = "Selenium Core";
            string selectDropDownValue2 = "Selenium Grid";
            string checkedAttribute = "checked";

            //Act
            chapterOnePage.ClickRadioButton();
            chapterOnePage.ClickCheckBox();
            chapterOnePage.SelectFromDropDownMenu(selectDropDownValue1);

            //Assert
            using (new AssertionScope()) 
            {
               chapterOnePage.radioButton.GetAttribute(checkedAttribute).Should().Be("true");
               chapterOnePage.checkBox.GetAttribute(checkedAttribute).Should().Be("true");
               chapterOnePage.dropDownMenu.SelectedOption.Text.Should().Be(selectDropDownValue1);               
            }

            //Act
            chapterOnePage.ClickCheckBox();
            chapterOnePage.SelectFromDropDownMenu(selectDropDownValue2);

            //Assert
            using (new AssertionScope())
            {
                chapterOnePage.checkBox.GetAttribute(checkedAttribute).Should().Be(null);
                chapterOnePage.dropDownMenu.SelectedOption.Text.Should().Be(selectDropDownValue2);
            }
        }

        [Test]
        public void LoadTextToThePage_ShouldBeLoadedNumberOfTimes() 
        {
            //Arrange

            //Act
            chapterOnePage.sendTextButton.Click();
            chapterOnePage.sendTextButton.Click();

            List<string> newTexts = chapterOnePage.addedTextElements
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
