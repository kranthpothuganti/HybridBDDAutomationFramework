using OpenQA.Selenium;

namespace WebTests.Pages
{
    public class ProductsPage : BasePage
    {
        private readonly By _itemAddToCart = By.Id("add-to-cart-sauce-labs-backpack");
        private readonly By _cartIcon = By.Id("shopping_cart_container");

        public ProductsPage(IWebDriver driver) : base(driver) { }

        public void AddItemToCart()
        {
            Click(WaitVisible(_itemAddToCart));
        }
        public void AddItemToCart(string itemName)
        {
            Click(WaitVisible(By.Id($"add-to-cart-{itemName.ToLower().Replace(' ','-')}")));
        }
        public void GoToCart()
        {
            Click(WaitVisible(_cartIcon));
        }
    }
}
