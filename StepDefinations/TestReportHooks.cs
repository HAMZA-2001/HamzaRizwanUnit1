using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports;
using BoDi;
using HamzaTestAutomationFramework.Utils;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace HamzaTestAutomationFramework.StepDefinations
{
    [Binding]
    public sealed class TestReportHooks : ExtentReport
    {
        private readonly IObjectContainer _container;

        public TestReportHooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        { 
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown(); //flushing the created logs into html report
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            _feature = ExtentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }

        [BeforeScenario("@Testers")]
        public void BeforeScenarioWithTag()
        {
            Console.WriteLine("Running inside tagged hooks in specflow");
        }

        //[BeforeScenario(Order = 1)]
        //public void FirstBeforeScenario(ScenarioContext scenarioContext)
        //{
        //    //Console.WriteLine("Running before scenario...");
        //    //IWebDriver driver = new ChromeDriver();
        //    //driver.Manage().Window.Maximize();

        //    //_container.RegisterInstanceAs<IWebDriver>(driver);

        //    _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        //}


        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

           // Console.WriteLine(stepType + " " + stepName);
            //Console.WriteLine("heeeeelloooooooooooooooooooo");
            Console.WriteLine(scenarioContext);
            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }

            //When scenario fail
            if (scenarioContext.TestError != null)
            {
                Console.WriteLine("heeeeelloooooooooooooooooooo");
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message);
                }
            }

        }

    }
}
