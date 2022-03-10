using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using HtmlAgilityPack;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;

namespace AutomateTests
{
    class Nunitfirst
    {
        private IWebDriver driver;
        // Selenium, Selenium Chrome, Nunit, Nunit..., Microsoft.NET.Test.Sdk, i da ti ne treba main stavis u output file class library umesto app
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver("C:\\Users\\Dragan\\Desktop\\chromedriver\\ver 87");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test()

        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(20));

            driver.Url = "http://www.google.com";
            driver.Manage().Window.Maximize();
            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            

            
            // Assert.IsTrue(link.Displayed);
            wait.Until(ExpectedConditions.ElementExists(By.TagName("a")));
            IList <IWebElement> alllanguage = driver.FindElements(By.TagName("a"));
           

            // english and serbian

            wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div[4]/span[1]/center/div[3]/div[2]/div/a[2]")));
            driver.FindElement(By.XPath("/html/body/div[2]/div[4]/span[1]/center/div[3]/div[2]/div/a[2]")).Click();

            driver.Navigate().Back();
            wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div[4]/span[1]/center/div[3]/div[2]/div/a")));
            driver.FindElement(By.XPath("/html/body/div[2]/div[4]/span[1]/center/div[3]/div[2]/div/a")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            

           

            wait.Until(ExpectedConditions.ElementExists(By.Name("q")));
            IWebElement link = driver.FindElement(By.Name("q"));
            link.Click();
            link.SendKeys("Mitto CH");
            link.Submit();
            // searching first website after google search
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.g")));
            IList <IWebElement> webElements = driver.FindElements(By.CssSelector("div.g"));
            webElements[0].Click(); // first web site after google search
            link = webElements[0].FindElement(By.TagName("a"));
            string href = link.GetAttribute("href");
            driver.Url = href; // Open first website       


            // Assert.AreNotEqual(textonsite, "Makers of tomorrow’s communications", "Strings are not matching");
            
                bool TryFindElement() // function for check words in webapp
            {
                
                    wait.Until(ExpectedConditions.ElementExists(By.CssSelector("h1")));
                    var text = driver.FindElement(By.CssSelector("h1")).Text;
                    Console.WriteLine("Text in header is:" +text);
                    if (text.Equals("Makers of tomorrow’s communications")) { 
                    Console.WriteLine("Text in header is equal with:" + " Makers of tomorrow’s communications");
 
                return true;
                }
                else
                {
                    Console.WriteLine("I am here");
                    return false;
                }

              
            }
            // Here we call function for check visibility of appropriate element in first website after google search
            if (!TryFindElement())
            {
                Console.WriteLine("I am here in assert");
                Assert.Fail(); }

        

        }


        [TearDown]
        public void closeBrowser()
        {
            driver.Close();

        }

    }
}
