using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace atsvak0731_1.Tests
{
    internal class SkelbiultTests
    {
        public static IWebDriver driver;


        [Test]
        public void SecondTest()
        {
            driver.Navigate().GoToUrl("https://www.skelbiu.lt");
            driver.FindElement(By.Id("searchKeyword")).SendKeys("gimtadienio dovanos");
            driver.FindElement(By.Id("searchButton")).Click();
            

            //change-and-submit
        }


        [OneTimeSetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            AcceptCookies();
        }

        [OneTimeTearDown]
        public void Clenaup()
        {
            //driver.Quit();
        }


        public void AcceptCookies()
        {
            driver.Navigate().GoToUrl("https://www.skelbiu.lt");
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
        }
    }
}
