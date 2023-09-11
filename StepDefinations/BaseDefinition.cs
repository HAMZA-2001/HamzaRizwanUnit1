using HamzaTestAutomationFramework.PageObjectss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HamzaTestAutomationFramework.StepDefinations
{
    [Binding]
    public class BaseDefinition
    {
        public static HomePage HomePage;
        public static CartPage CartPage;
        public static InventoryPage InventoryPage;
        public static CheckoutFormPage CheckoutFormPage;
        public static CheckoutOverviewPage CheckoutOverviewPage;
        public static CheckoutCompletePage CheckoutCompletePage;

        [BeforeScenario]
        public void BeforeScenario()
        {
            DriverHelper.InitializeEdgeDriverAndStart();
            //DriverHelper.Driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            HomePage = new HomePage();
            CartPage = new CartPage();
            InventoryPage = new InventoryPage();
            CheckoutFormPage = new CheckoutFormPage();
            CheckoutOverviewPage = new CheckoutOverviewPage();
            CheckoutCompletePage = new CheckoutCompletePage();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverHelper.KillDriver();
        }
    }
}
