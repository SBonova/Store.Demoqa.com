using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
using System.Threading;


namespace Team_tasks
{
    [TestClass]
    public class Tests
    {
        private IWebDriver Driver;

        [TestInitialize]
        public void OpenBrowser()
        {
            this.Driver = new ChromeDriver();

            if (Driver.Manage().Cookies.AllCookies.Any())
            {
                Driver.Manage().Cookies.DeleteAllCookies();
            }
        }

        [TestMethod]
        public void Register()
        {
            this.Driver.Navigate().GoToUrl("http://store.demoqa.com/wp-login.php?action=register");

            Driver.FindElement(By.Id("user_login")).SendKeys(Faker.Internet.UserName());

            Driver.FindElement(By.Id("user_email")).SendKeys(Faker.Internet.Email());

            Driver.FindElement(By.Id("wp-submit")).Click();

            Assert.AreEqual("Registration complete. Please check your email.", Driver.FindElement(By.CssSelector(".message")).Text);

        }

        [TestMethod]
        public void Login()
        {

            this.Driver.Navigate().GoToUrl("http://store.demoqa.com/wp-login.php");
            Driver.FindElement(By.Id("user_login")).SendKeys("SBonova");
            Driver.FindElement(By.Id("user_pass")).SendKeys("5WLwf*t7JFBspE4U");
            Driver.FindElement(By.Id("wp-submit")).Click();
            Assert.AreEqual("SBonova", Driver.FindElement(By.ClassName("display-name")).Text);
        }

        [TestMethod]
        public void Rate()
        {

            this.Driver.Navigate().GoToUrl("http://store.demoqa.com/products-page/product-category/");
            Driver.FindElement(By.CssSelector("div.rater-0:nth-child(4) > a:nth-child(1)")).Click();
            Thread.Sleep(3001);
            Driver.FindElement(By.CssSelector("div.rater-1:nth-child(5) > a:nth-child(1)")).Click();
            Thread.Sleep(3001);
            Driver.FindElement(By.CssSelector("div.rater-2:nth-child(4) > a:nth-child(1)")).Click();


        }

        [TestCleanup]
        public void CloseBrowser()
        {
            Driver.Close();
        }
    }
}
