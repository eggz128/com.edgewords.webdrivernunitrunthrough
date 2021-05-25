using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LumenWorks.Framework.IO.Csv;
using System.Reflection;

namespace com.edgewords.webdrivernunitrunthrough.Util
{
    public static class HelperLib
    {
        public static IWebElement WaitForAndReturnElement(IWebDriver driver, By locator, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            IWebElement element = wait.Until(drv => drv.FindElement(locator));

            return element;

        }

        public static void TakeScreenshot(IWebDriver driver, string filename)
        {
            
            
            
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            
            if(ssdriver is ITakesScreenshot)
            {
                Screenshot screenshot = ssdriver.GetScreenshot();
                //screenshot.SaveAsFile(@"C:\Users\Edgewords\Pictures\" + filename, ScreenshotImageFormat.Png);

                string screenshotFile = Path.Combine(TestContext.CurrentContext.WorkDirectory,
                                            "my_screenshot.png");
                screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);

                // Add that file to results
                TestContext.AddTestAttachment(screenshotFile, "My Screenshot");
                TestContext.WriteLine("Hello from TestContext");
                Console.WriteLine("Reporting using Console");
                TestContext.AddTestAttachment(@"C:\Users\edgewords\Pictures\page.png", "Hardcoded pic");


            } else
            {
                Console.WriteLine("Not able to take screenshot");
                Assert.Fail("Boom?");
            }

        }

        public static IEnumerable<string[]> GetTestData()
        {
            var csvFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase) + "\\TestData.csv";
            csvFile = new Uri(csvFile).LocalPath;

            using (var csv = new CsvReader(new StreamReader(csvFile), true))
            {
                while (csv.ReadNextRecord())
                {
                    string data1 = csv[0];
                    string data2 = csv[1];
                    yield return new[] { data1, data2 };
                }
            }
        }
    }
}
