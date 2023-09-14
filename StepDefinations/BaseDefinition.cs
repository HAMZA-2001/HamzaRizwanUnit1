using AventStack.ExtentReports.Gherkin.Model;
using HamzaRizwanWebAutomationFrameWork;
using HamzaRizwanWebAutomationFrameWork.HelperFuntions;
using HamzaTestAutomationFramework.PageObjectss;
using HamzaTestAutomationFramework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static HamzaRizwanWebAutomationFrameWork.Utils.Settings;

namespace HamzaTestAutomationFramework.StepDefinations
{
    [Binding]
    public class BaseDefinition : ExtentReport
    {
        public static HomePage HomePage;
        public static CartPage CartPage;
        public static InventoryPage InventoryPage;
        public static CheckoutFormPage CheckoutFormPage;
        public static CheckoutOverviewPage CheckoutOverviewPage;
        public static CheckoutCompletePage CheckoutCompletePage;
        public static Asserter Asserter;

        [BeforeScenario(Order = 1)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            DriverHelper.InitializeDriver(browserName);
            DriverHelper.Driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            HomePage = new HomePage();
            CartPage = new CartPage();
            InventoryPage = new InventoryPage();
            CheckoutFormPage = new CheckoutFormPage();
            CheckoutOverviewPage = new CheckoutOverviewPage();
            CheckoutCompletePage = new CheckoutCompletePage();
            Asserter = new Asserter();

            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverHelper.KillDriver();
        }
    }
}
