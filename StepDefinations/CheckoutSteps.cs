using HamzaRizwanWebAutomationFrameWork;
using HamzaRizwanWebAutomationFrameWork.HelperFuntions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static System.Net.WebRequestMethods;

namespace HamzaTestAutomationFramework.StepDefinations
{
    [Binding]
    public class CheckoutSteps
    {
        [Given(@"the customer logs in with valid credentials")]
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
            BaseDefinition.Asserter.AssertAreEqual("Checkout: Complete!", checkoutTitle);
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
                BaseDefinition.Asserter.AssertAreEqual(item.Price, productPrice);
            }
        }

        // Scenario for Test 3

        [Given(@"I enter incorrect username or password")]
        public void GivenIEnterIncorrectUsernameOrPassword()
        {
            BaseDefinition.HomePage.UserNameInputBox.SendKeys("1233");
            BaseDefinition.HomePage.PasswordInputBox.SendKeys("abc");
            BaseDefinition.HomePage.LogInButton.Click();
        }

        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            string errorMessage = BaseDefinition.HomePage.Errormessage.Text;
            BaseDefinition.Asserter.AssertAreEqual("Epic sadface: Username and password do not match any user in this service", errorMessage);
            //Console.WriteLine(errorMessage);
        }

        // Scenario for Test 4

        [Then(@"I should successfully login")]
        public void ThenIShouldSuccessfullyLogin()
        {
            string currentURL = DriverHelper.Driver.Url;
            string expectedURL = "https://www.saucedemo.com/inventory.html";
            BaseDefinition.Asserter.AssertAreEqual(expectedURL, currentURL);
        }




    }
}
