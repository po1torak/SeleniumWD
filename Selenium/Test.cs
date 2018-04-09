using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    class Test
    {
        IWebDriver driver = new ChromeDriver();

        static void Main(string[] args)
        {
        }

        [SetUp]
        public void Initialize()
        {
            driver.Navigate().GoToUrl("http://www.gooogle.com");
        }

        [Test]
        public void Test_1()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.FindElement(By.Name("q")).SendKeys("Вікіпедія");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            driver.FindElement(By.LinkText("Вікіпедія")).Click();
            Assert.AreEqual("Вікіпедія", driver.Title);
        }

        [Test]
        public void Test_2()
        {
            driver.Navigate().GoToUrl("https://uk.wikipedia.org/wiki");
            Assert.AreEqual("Вікіпедія", driver.Title);
            DateTime currentTime = DateTime.Now;
            string textToCheck = driver.FindElement(By.LinkText(currentTime.ToString("d MMMM"))).Text;
            Assert.AreEqual(currentTime.ToString("d MMMM"), textToCheck);
        }

        [Test]
        public void Test_3()
        {
            driver.Navigate().GoToUrl("https://uk.wikipedia.org/wiki");
            Assert.AreEqual("Вікіпедія", driver.Title);
            driver.FindElement(By.LinkText("Поточні події")).Click();
            Assert.AreEqual("Вікіпедія:Поточні події — Вікіпедія", driver.Title);
            IWebElement news = driver.FindElement(By.CssSelector("div#mw-content-text > div > table > tbody > tr > td > div:nth-of-type(4) > ul > li:nth-of-type(2) > ul > li:nth-of-type(2)"));
            Assert.IsTrue(news.Text.Contains("Перша китайська космічна станція «Тяньгун-1», з якою було втрачено зв'язок у 2016 році, згоріла в атмосфері над Тихим океаном"));
        }

        [Test]
        public void Test_4()
        {
            driver.Navigate().GoToUrl("https://uk.wikipedia.org/wiki");
            Assert.AreEqual("Вікіпедія", driver.Title);
            driver.FindElement(By.Name("search")).SendKeys("testing");
            driver.FindElement(By.Name("go")).Click();
            Assert.AreEqual("Результати пошуку для «testing» — Вікіпедія", driver.Title);
            driver.FindElement(By.LinkText("Pairwise testing")).Click();
            Assert.AreEqual("Pairwise testing — Вікіпедія", driver.Title);
        }

        [TearDown]
        public void CleanUp()
        {
            //driver.Close();
        }
    }
}