using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaTestAutomationFramework.PageObjectss
{
    public class CheckoutOverviewPage
    {
        public IWebElement FinishButton => DriverHelper.Driver.FindElement(By.Id("finish"));
    }
}
