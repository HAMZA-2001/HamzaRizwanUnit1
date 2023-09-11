using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaTestAutomationFramework.PageObjectss
{
    public class HomePage
    {
        public IWebElement UserNameInputBox => DriverHelper.Driver.FindElement(By.Id("user-name"));
        public IWebElement PasswordInputBox => DriverHelper.Driver.FindElement(By.Id("password"));
        public IWebElement LogInButton => DriverHelper.Driver.FindElement(By.Id("login-button"));
    }
}
