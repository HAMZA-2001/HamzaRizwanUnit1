﻿using CsvHelper;
using CsvHelper.Configuration;
using HamzaRizwanWebAutomationFrameWork;
using HamzaTestAutomationFramework;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamzaRizwanWebAutomationFrameWork.HelperFuntions
{
    public class Helper
    {
        public List<Item> ReadItemsFromCSV(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            { 
                return csv.GetRecords<Item>().ToList();
            }
        }

        public class Item
        { 
            public string Name { get; set; }
            public string Price { get; set; }

        }

        public void TakeBrowserScreenShot()
        {
            Screenshot screenShot = ((ITakesScreenshot)DriverHelper.Driver).GetScreenshot();

            // TODO make it include the test name in this path
            string filePath = $"C:\\Users\\HamzaRizwan\\source\\repos\\HamzaFrameworkUnit1\\HamzaTestAutomationFramework\\Screenshots\\FailureScreenshot {DateTime.Now.ToString("dd MMMM yyyy HH-mm-ss")}.png";
            screenShot.SaveAsFile(filePath);
            TestContext.AddTestAttachment(filePath);
        }
    }
}
