using NLog;
using OpenQA.Selenium;
using TestCore.Utils;
using WebTests.hooks;

namespace WebTests.Pages
{
    public class ProductsPage : BasePage
    {
        private readonly By _itemAddToCart = By.Id("add-to-cart-sauce-labs-backpack");
        private readonly By _cartIcon = By.Id("shopping_cart_container");

        public ProductsPage(IWebDriver driver) : base(driver) { }

        public void AddItemToCart()

        {
            LogManagerHelper.Logger.Info("Adding item to cart");
            Click(WaitVisible(_itemAddToCart));
            LogManagerHelper.Logger.Info("Item added to cart");
        }
        public void AddItemToCart(string itemName)
        {
            LogManagerHelper.Logger.Info("Adding item to cart");
            Click(WaitVisible(By.Id($"add-to-cart-{itemName.ToLower().Replace(' ','-')}")));
            LogManagerHelper.Logger.Info("Item added to cart");
        }
        public void GoToCart()
        {
            Click(WaitVisible(_cartIcon));
        }
    }
}
