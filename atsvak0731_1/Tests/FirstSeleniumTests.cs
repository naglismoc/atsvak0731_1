using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atsvak0731_1.Tests
{
    internal class FirstSeleniumTests
    {
        public static IWebDriver driver;

        [Test]
        public void FirstTest()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.skelbiu.lt");
            AcceptCookies();
            driver.FindElement(By.Id("searchKeyword")).SendKeys("kaledines dovanos");

            IWebElement searchBar = driver.FindElement(By.Id("searchKeyword"));
            searchBar.SendKeys("lopeta");

            driver.FindElement(By.Id("searchButton")).Click();
            driver.Quit();
        }

        public void AcceptCookies()
        {
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
        }
    }
}
