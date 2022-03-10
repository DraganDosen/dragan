using System;
using System.Collections.Generic;
using System.Text;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
// For supporting Page Object Model

using SeleniumExtras.PageObjects;

namespace AutomateTests
{

    public class POM_MittoPage
    {
        String mitto_url = "https://www.mitto.ch/";
        private IWebDriver driver;
        private WebDriverWait wait;
        
        Int32 timeout = 10000; // in milliseconds

        public POM_MittoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);


        }
        public void goToMitto()
        {
            driver.Navigate().GoToUrl(mitto_url);
            driver.Manage().Window.Maximize();

        }

        [FindsBy(How = How.CssSelector, Using = "h1")]
        public IWebElement result;

        public void TryFindElement() // function for check words in webapp
        {

            //wait.Until(ExpectedConditions.ElementExists(By.CssSelector("h1")));
            var textOnPage = driver.FindElement(By.CssSelector("h1")).Text;
            Console.WriteLine("Text in header is:"+ " " + textOnPage);
            //if (text.Equals("Notifications"))

            if (textOnPage.Equals("Notifications"))
            {
                System.Console.WriteLine("Test pass");
                 }

            else {
                System.Console.WriteLine("Test failed");
                Assert.Fail();
            }
                
            
        }

        public void GetStarted() // function for check words in webapp
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            System.Console.WriteLine("Try to find button");
            IWebElement bottomcookies = driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowallSelection"));
            System.Console.WriteLine("Button FOR COOKIES is visible");
            System.Threading.Thread.Sleep(4000);
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(bottomcookies));
            bottomcookies.Click();
            System.Console.WriteLine("Button FOR COOKIES is CLICKED");


            IWebElement buttonGetStarted = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/div/div[1]/header/div/div/a[1]"));
            System.Console.WriteLine("Button is visible");
            // wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(buttonGetStarted));
            System.Threading.Thread.Sleep(4000);
            buttonGetStarted.Click();
            Console.WriteLine("Button is clicked");

        }

    }


}


