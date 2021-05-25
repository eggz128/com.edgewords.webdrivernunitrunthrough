using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using com.edgewords.webdrivernunitrunthrough.Util;

namespace com.edgewords.webdrivernunitrunthrough.Test_Cases
{
    [TestFixture]
    public class FirstTest : com.edgewords.webdrivernunitrunthrough.Base_Classes.TestBase
    {
        
        string baseURL = "https://www.edgewordstraining.co.uk/webdriver2/sdocs/auth.php";

        [Test, Category("Real Tests")]
        public void TestMethod()
        {

            
            driver.Url = baseURL;

            driver.FindElement(By.Id("username")).SendKeys("Edgewords");
            driver.FindElement(By.Id("password")).SendKeys("edgewords123");
            IWebElement SubmitButton = driver.FindElement(By.LinkText("Submit"));
            SubmitButton.Click();

            driver.Url = "https://www.edgewordstraining.co.uk/training-site/cssXPath.html";

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            //IWebElement gripper = wait.Until(drv => drv.FindElement(By.CssSelector("#slider > a")));

            IWebElement gripper = HelperLib.WaitForAndReturnElement(driver, By.CssSelector("#slider > a"),15);

            HelperLib.TakeScreenshot(driver, "page.png");

            OpenQA.Selenium.Interactions.Actions myaction = new OpenQA.Selenium.Interactions.Actions(driver);
            myaction.MoveToElement(gripper).ClickAndHold().MoveByOffset(100, 0).Release().Build().Perform();
            gripper.Click();
            

            Console.WriteLine("Finished!");
            TestContext.WriteLine("Hello from FirstTest via TestContext");
            Assert.Pass("We got this far so we passed");
        }
    }
}
