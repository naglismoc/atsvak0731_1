using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections;

namespace atsvak0731_1.Tests
{
    internal class skelbiultarrays
    {
        public static IWebDriver driver;
        public static int sum = 0;
        public static int count = 0;

        [Test]
        public void GetItemPriceData()
        {
            String searchKeyword = "povas";
            ArrayList urls = getUlrs(searchKeyword);
            getPrices(urls);

            Console.WriteLine("su kainomis radome " + count + "/" + urls.Count + " " + searchKeyword + ". Vidutine kaina " + ((double)sum / count));
        }
        public void getPrices(ArrayList urls)
        {
            foreach (string url in urls)
            {
                try
                {
                    driver.Navigate().GoToUrl(url);
                    try
                    {
                        string price = driver.FindElement(By.XPath("//*[@id=\"contentArea\"]/div[6]/div[1]/div[1]/div[5]/div/div[2]/p[1]")).Text;
                        sum += Convert.ToInt32(price.Split(" ")[0]);
                        count++;
                        Console.WriteLine("|" + price + "|");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No price");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("bad url " + url);
                }
            }
        }

        public ArrayList getUlrs(string searchKeyword)
        {
            ArrayList urls = new ArrayList();
            int sum = 0;
            int count = 0;
            for (int i = 1; i < 201; i++)
            {
                string url = "https://www.skelbiu.lt/skelbimai/" + i + "?keywords=" + searchKeyword;
                driver.Navigate().GoToUrl(url);
                if( !driver.Url.Equals(url))
                {
                    return urls;
                }
                IList<IWebElement> cards = driver.FindElement(By.Id("itemsList")).FindElement(By.TagName("ul")).FindElements(By.TagName("li"));
                foreach (IWebElement card in cards)
                {

                    if (card.GetAttribute("class").Contains("kainos-item"))
                    {
                        continue;
                    }
                    urls.Add(card.FindElement(By.TagName("a")).GetAttribute("href"));
                }
            }
            return urls;
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
