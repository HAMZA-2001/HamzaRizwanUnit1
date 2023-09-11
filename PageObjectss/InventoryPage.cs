using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaTestAutomationFramework.PageObjectss
{
    public class InventoryPage
    {
        public IWebElement AddToCartButton => DriverHelper.Driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        public IWebElement CartIcon => DriverHelper.Driver.FindElement(By.XPath("//a[@class='shopping_cart_link']"));
    }
}
