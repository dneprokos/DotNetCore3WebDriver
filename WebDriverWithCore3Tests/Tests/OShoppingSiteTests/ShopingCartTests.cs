using NUnit.Framework;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.PageObjects;

namespace WebDriverWithCore3Tests.Tests
{
    [TestFixture, Parallelizable(ParallelScope.All)]
    public class ShopingCartTests : TestBase
    {
        private OShopMainPage oshopMainPage;
        private OShopNavigationBar oShopNavigationBar;

        public override void Setup()
        {
            base.Setup();
            oshopMainPage = new OShopMainPage();
            oShopNavigationBar = new OShopNavigationBar();

            WebDriverFactory.CurrentDriver.Url = TestSettingsManager.GetBaseUrl;
        }

        [Test]
        public void GoodsShouldBeAddedToShoppingCart() 
        {
            //Arrange

            //Act
            oshopMainPage.AddFoodToCard("Tomato").AddMoreItems(2);
            oShopNavigationBar.ShoppingCartLink.Click();

            //Assert
        }
    }
}
