using WebDriverWithCore3Tests.Common.Components;
using WebDriverWithCore3Tests.Common.Helpers;
using WebDriverWithCore3Tests.Models;

namespace WebDriverWithCore3Tests.PageObjects.OShopSite
{
    public class ShopingCartPage
    {
        public ShopingCartPage()
        {
            WaitManager.WaitForTrueCondition(
                () => shoppingCartTable.GetHeaderElements().Count > 0,
                "Wait for cart table");
        }

        public TableComponent<CartTableModel> shoppingCartTable 
            = new TableComponent<CartTableModel>();

    }
}
