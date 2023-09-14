using HamzaRizwanWebAutomationFrameWork;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaTestAutomationFramework.PageObjectss
{
    public class CartPage
    {
        public IWebElement CheckoutButton => DriverHelper.Driver.FindElement(By.Id("checkout"));
    }
}
