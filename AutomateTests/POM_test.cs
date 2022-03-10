using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
// For supporting Page Object Model
// Obsolete - using OpenQA.Selenium.Support.PageObjects;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;

namespace AutomateTests
{
    class POM_test
    {

        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("C:\\Users\\Dragan\\Desktop\\chromedriver\\ver 99");
        }

        [Test, Order(1)]
        public void Search_Google()
        {
            POM_HomePage home = new POM_HomePage(driver);
            home.goToPage();
            POM_SearchPage search = home.goToSearchPage("Mitto CH");
            search.searchfunction();
            POM_MittoPage mitto = new POM_MittoPage(driver);
            mitto.TryFindElement();
        }
        [Test, Order(2)]
        public void GetStarted()
        {
            POM_MittoPage mitto = new POM_MittoPage(driver);
            mitto.goToMitto();
            mitto.GetStarted();
        }

        [TearDown]
        public void Cleanup()
        {


            driver.Close();

        }            // Terminates the remote webdriver sessio}
    }
}




