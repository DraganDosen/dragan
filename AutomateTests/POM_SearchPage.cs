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
    public class POM_SearchPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        Int32 timeout = 10000; // in milliseconds

        public POM_SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='rso']/div[1]/div/div/div/div/div[1]/a/h3")]
        private IWebElement result;
        public POM_MittoPage searchfunction ()
        { 
       // wait.Until(ExpectedConditions.ElementExists(By.Name("q")));
           IWebElement link = driver.FindElement(By.Name("q"));
        //link.Click();
           // link.SendKeys("Mitto CH");
            Console.WriteLine("I am here o");
           // link.Submit();
            Console.WriteLine("I am here 1");
            // searching first website after google search
            //wait.Until(ExpectedConditions.ElementExists(By.CssSelector("div.g")));
            IList<IWebElement> webElements = driver.FindElements(By.CssSelector("div.g"));
            Console.WriteLine("I am here 2");
            webElements[0].Click(); // first web site after google search
            Console.WriteLine("I am here 3");
            link = webElements[0].FindElement(By.TagName("a"));
            string href = link.GetAttribute("href");
        driver.Url = href;
            return new POM_MittoPage(driver);

        }

        
   

    
}
}