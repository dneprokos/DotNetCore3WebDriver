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
    public class BookTestSiteMainPageTests : TestBase
    {
        private MainPage mainPage;

        public override void Setup()
        {
            base.Setup();
            WebDriverFactory.CurrentDriver.Url = TestSettingsManager.GetBaseUrl;
            mainPage = new MainPage();
        }

        [Test]
        public void AssertAllExpectedElementsPresent()
        {
            //Arrange
            string actualUrl = WebDriverFactory.CurrentDriver.Url;
            var expectedTitle = "Selenium: Beginners Guide";
            var expectedBodyText = 
                "Below is a list of links to the examples needed in the chapters. " +
                "Click on the links below and follow the steps in the book.";
            var expectedLinkNames = 
                new List<string> { "Chapter1", "Chapter2", "Chapter3", "Chapter4", "Chapter8" };
            var expectedHrefs = BuildFullPagesLinks(
                new List<string> { 
                    "chapter1", 
                    "chapter2", 
                    "chapter3", 
                    "chapter4", 
                    "chapter8" });
       
            using (new AssertionScope()) 
            {
                //Act
                var fullLinks = mainPage.GetPageLinks();
                List<string> linkNames = fullLinks.Keys.ToList();
                List<string> hrefs = fullLinks.Values.ToList();

                //Assert
                actualUrl.Should().Be(TestSettingsManager.GetBaseUrl);
                mainPage.GetMainPageTitle().Should().Be(expectedTitle);
                mainPage.GetMainBodyText().Trim().Should().Be(expectedBodyText.Trim());

                linkNames.Should().Contain(expectedLinkNames);
                hrefs.Should().Contain(expectedHrefs);
                mainPage.TextField.Should().NotBeNull();
            }
        }

        [Test]
        public void TypeTextToTextBox_TextShouldBeAdded()
        {
            //Arrange
            var text = "Test";

            //Act
            mainPage.TextField.TypeText(text);
            
            //Assert
            mainPage.TextField.ReadText().Should().Be(text);
        }


        #region Private helpers

        /// <summary>
        /// Gets list of page names and adds base url to each of the page
        /// </summary>
        /// <param name="pageNames"></param>
        /// <returns></returns>
        private List<string> BuildFullPagesLinks(List<string> pageNames) 
        {
            var fullPages = new List<string>();
            pageNames.ForEach(pageName => fullPages.Add(TestSettingsManager.GetBaseUrl + pageName));

            return fullPages;
        }

        #endregion
    }
}