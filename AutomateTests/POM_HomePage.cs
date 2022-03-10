using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace AutomateTests
{
    public class POM_HomePage
    {

        String test_url = "https://www.google.com";
        String mitto_url = "https://www.mitto.ch/";

        private IWebDriver driver;
        private WebDriverWait wait;

        public POM_HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        //[FindsBy(How = How.XPath, Using = "//*[@id='tsf']/div[2]/div[1]/div[1]/div/div[2]/input")]
        [FindsBy(How = How.Name, Using = "q")]
        [CacheLookup]
        public IWebElement elem_search_text;

        //[FindsBy(How = How.XPath, Using = "//*[@id='tsf']/div[2]/div/div[3]/center/input[1]")]
        [FindsBy(How = How.Name, Using = "btnI")]
        [CacheLookup]
        public IWebElement elem_submit_button;

        // Go to the designated page
        public void goToPage()
        {
            driver.Navigate().GoToUrl(test_url);
            driver.Manage().Window.Maximize();
        }

        public void goToMitto()
        {
            driver.Navigate().GoToUrl(mitto_url);
            driver.Manage().Window.Maximize();
            
        }

        //[FindsBy(How = How.XPath, Using = "//*[@id='tsf']/div[2]/div/div[3]/center/input[1]")]
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[4]/span[1]/center/div[3]/div[2]/div/a")]
        [CacheLookup]
        private IWebElement Serbian_button;

        //[FindsBy(How = How.XPath, Using = "//*[@id='tsf']/div[2]/div/div[3]/center/input[1]")]
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[4]/span[1]/center/div[3]/div[2]/div/a[2]")]
        [CacheLookup]
        private IWebElement English_button;

       

        public POM_SearchPage goToSearchPage(string input_search)
        {
            elem_search_text.SendKeys(input_search);
            //wait.Until(ExpectedConditions.ElementToBeClickable(elem_submit_button)).Submit();
            elem_search_text.Submit();
            return new POM_SearchPage(driver);
        }
    }
}