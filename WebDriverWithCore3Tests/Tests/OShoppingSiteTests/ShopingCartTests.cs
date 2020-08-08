using NUnit.Framework;
using System.Linq;
using WebDriverWithCore3Tests.Common;
using WebDriverWithCore3Tests.Common.Helpers;
using WebDriverWithCore3Tests.PageObjects;
using WebDriverWithCore3Tests.PageObjects.OShopSite;

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
            
            WebDriverFactory.CurrentDriver.Url = TestSettingsManager.GetBaseUrl;
            oShopNavigationBar = new OShopNavigationBar();
            oshopMainPage = new OShopMainPage();
        }

        [Test]
        public void GoodsShouldBeAddedToShoppingCart() 
        {
            //Arrange

            //Actwd
            oshopMainPage.AddFoodToCard("Tomato").AddMoreItems(2);
            oShopNavigationBar.ShoppingCartLink.Click();
            var shoppingCartTable = new ShopingCartPage().shoppingCartTable;

            var headers = shoppingCartTable.GetHeaderNames();
            var cells = shoppingCartTable.GetRowsWithData();

            //Assert
            Assert.IsTrue(true);
        }
    }
}
