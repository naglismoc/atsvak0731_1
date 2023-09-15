using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace atsvak0731_1.Tests
{
    internal class DrogasltTests
    {
        public static IWebDriver driver;

        [Test]
        public void PositiveRegistrationTest()
        {
            driver.Navigate().GoToUrl("https://www.skelbiu.lt");
            driver.FindElement(By.Id("searchKeyword")).SendKeys("kaledines dovanos");
            driver.FindElement(By.Id("searchButton")).Click();
            string result = driver.FindElement(By.XPath("//*[@id=\"body-container\"]/div[3]/div[1]/h3")).Text;
            Assert.AreEqual("labas rytas", result);
        }
        [Test]
        public void RegistrationNoUsernameTest()
        {
            driver.Navigate().GoToUrl("https://www.skelbiu.lt");
            driver.FindElement(By.Id("searchKeyword")).SendKeys("gimtadienio dovanos");
            driver.FindElement(By.Id("searchButton")).Click();
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
