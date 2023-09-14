using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaTestAutomationFramework.Utils
{
    public class ExtentReport
    {
        public static ExtentReports ExtentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static String Dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String TestResultPath = Dir.Replace("bin\\Debug\\net6.0", "TestResults");

        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentHtmlReporter(TestResultPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

            ExtentReports = new ExtentReports();
            ExtentReports.AttachReporter(htmlReporter);
            ExtentReports.AddSystemInfo("Application", "Youtube");
            ExtentReports.AddSystemInfo("Browser", "Chrome");
            ExtentReports.AddSystemInfo("OS", "Windows");
        }

        public static void ExtentReportTearDown()
        {
            ExtentReports.Flush(); 
        }
    }
}
