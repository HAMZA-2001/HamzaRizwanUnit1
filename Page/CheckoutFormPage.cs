using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaTestAutomationFramework.PageObjectss
{
    public class CheckoutFormPage
    {
        public IWebElement FirstNameInputBox => DriverHelper.Driver.FindElement(By.Id("first-name"));
        public IWebElement LastNameInputBox => DriverHelper.Driver.FindElement(By.Id("last-name"));
        public IWebElement PostalCodeInputBox => DriverHelper.Driver.FindElement(By.Id("postal-code"));

        public IWebElement ContinueButton => DriverHelper.Driver.FindElement(By.Id("continue"));
    }
}
