using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaTestAutomationFramework
{
    public static class DriverHelper
    {
        //[ThreadStatic]
        public static IWebDriver Driver;

        public static void InitializeEdgeDriverAndStart() 
        {
            EdgeOptions options = new EdgeOptions();
            options.AddArguments("--start-maximized");
            Driver = new EdgeDriver(options);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static void InitializeChromeDriverAndStart() 
        {
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static void InitializeDriver(string driverName)
        {
            if (driverName == "Edge")
            {
                EdgeOptions options = new EdgeOptions();
                options.AddArguments("--start-maximized");
                Driver = new EdgeDriver(options);
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            }else if(driverName == "Chrome")
            {
                Driver = new ChromeDriver();
                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
        }

        public static void KillDriver()
        {
            Driver.Quit();
        }
    }
}
