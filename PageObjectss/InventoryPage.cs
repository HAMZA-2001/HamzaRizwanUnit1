using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HamzaTestAutomationFramework.PageObjectss
{
    public class InventoryPage
    {
        public IWebElement AddToCartButton => DriverHelper.Driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        public IWebElement CartIcon => DriverHelper.Driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));

        public string GetProductPrice(string productName) 
        {
            IWebElement productPriceElement = DriverHelper.Driver.FindElement(By.XPath($"//div[@class='inventory_item_name' and text()='{productName}']//parent::a//parent::div//parent::div//div[@class='inventory_item_price']"));
            string price = productPriceElement.Text;
            return price;
        }
    }
}
//div[@class='inventory_item_name' and text()='Sauce Labs Bike Light']//parent::a//parent::div//parent::div//div[@class='inventory_item_price']