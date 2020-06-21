using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.Common.Extensions;

namespace WebDriverWithCore3Tests.PageObjects
{
    public class OShopMainPage
    {
        private string currentFoodName;

        public List<IWebElement> ProductCards
            => WebDriverFactory.CurrentDriver
            .WaitForElements(By.XPath("//div[@class='card']")).ToList();

        public IWebElement ProductCard(string foodName) 
            => WebDriverFactory.CurrentDriver
            .WaitForElement(By
                .XPath($"//h5[text()='{foodName}']/ancestor::*[@class='card']"));
        

        public OShopMainPage AddFoodToCard(string foodName) 
        {
            currentFoodName = null;
            ProductCard(foodName)
                .WaitForElement(By
                .XPath("//button[@class='btn btn-secondary btn-block']"))
                .Click();

            currentFoodName = foodName;

            return this;
        }

        public OShopMainPage AddMoreItems(int count) 
        {
            IWebElement addMoreButton = ProductCard(currentFoodName)
                .WaitForElement(By
                .XPath("//button[@class='btn btn-secondary btn-block'][text()='+']"));

            for (int i = 0; i < count; i++)
            {
                addMoreButton.Click();
            }

            return this;
        }

        public OShopMainPage RemoveItems(int count)
        {
            IWebElement addMoreButton = ProductCard(currentFoodName)
                .WaitForElement(By
                .XPath("//button[@class='btn btn-secondary btn-block'][text()='-']"));

            for (int i = 0; i < count; i++)
            {
                addMoreButton.Click();
            }
            return this;
        }
    }
}
