using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaTestAutomationFramework.PageObjectss
{
    public class CheckoutCompletePage
    {
        public IWebElement CheckoutTitle => DriverHelper.Driver.FindElement(By.XPath("//span[@class='title']"));
        public IWebElement OrderCompleteHeader => DriverHelper.Driver.FindElement(By.XPath("//h2[@class='complete-header']"));
    }
}
