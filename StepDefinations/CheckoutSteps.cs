using HamzaRizwanWebAutomationFrameWork.HelperFuntions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HamzaTestAutomationFramework.StepDefinations
{
    [Binding]
    public class CheckoutSteps
    {
        [Given(@"the customer is on the homepage of Swag Labs website")]
        public void GivenTheCustomerIsOnTheHomepageOfSwagLabsWebsite()
        {
            DriverHelper.Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [When(@"the customer logs in with valid credentials")]
        public void WhenTheCustomerLogsInWithValidCredentials()
        {
            BaseDefinition.HomePage.UserNameInputBox.SendKeys("standard_user");
            BaseDefinition.HomePage.PasswordInputBox.SendKeys("secret_sauce");
            BaseDefinition.HomePage.LogInButton.Click();
        }

        [When(@"they add product ""([^""]*)"" to the basket")]
        public void WhenTheyAddProductToTheBasket(string p0)
        {
            BaseDefinition.InventoryPage.AddToCartButton.Click();
            BaseDefinition.InventoryPage.CartIcon.Click();
        }

        [When(@"they proceed to checkout")]
        public void WhenTheyProceedToCheckout()
        {
            BaseDefinition.CartPage.CheckoutButton.Click();
        }

        [When(@"they provide valid checkout information")]
        public void WhenTheyProvideValidCheckoutInformation()
        {
            BaseDefinition.CheckoutFormPage.FirstNameInputBox.SendKeys("Hamza");
            BaseDefinition.CheckoutFormPage.LastNameInputBox.SendKeys("Rizwan");
            BaseDefinition.CheckoutFormPage.PostalCodeInputBox.SendKeys("NG7 2DU");
            BaseDefinition.CheckoutFormPage.ContinueButton.Click();
        }

        [When(@"the customer confirms the order")]
        public void WhenTheCustomerConfirmsTheOrder()
        {
            BaseDefinition.CheckoutOverviewPage.FinishButton.Click();
        }

        [Then(@"the customer should see and order confirmation message")]
        public void ThenTheCustomerShouldSeeAndOrderConfirmationMessage()
        {
            string checkoutTitle = BaseDefinition.CheckoutCompletePage.CheckoutTitle.Text;
            Assert.AreEqual("Checkout: Complete!", checkoutTitle);
        }

        // Scenario 2 Tests

        [Then(@"I iterate over each item in CSV file to ensure both website's and CSV file prices matches")]
        public void ThenIIterateOverEachItemInCSVFileToEnsureBothWebsitesAndCSVFilePricesMatches()
        {
            const string csvFilePath = "C:\\Users\\HamzaRizwan\\source\\repos\\HamzaFrameworkUnit1\\HamzaTestAutomationFramework\\Products.csv";
            
            Helper helper = new Helper();
            var productsCSVFile = helper.ReadItemsFromCSV(csvFilePath);

            foreach (var item in productsCSVFile)
            {
                string productPrice = BaseDefinition.InventoryPage.GetProductPrice(item.Name);
                Assert.AreEqual(item.Price, productPrice);
            }
        }


    }
}
