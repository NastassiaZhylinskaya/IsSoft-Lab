using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using PageFactoryTask70.PageObjects;
using System.Threading;
using OpenQA.Selenium;

namespace PageFactoryTask70.Tests
{
    [TestFixture]
    class LoginTests
    {
        private IWebDriver driver;
        const string expectedUserName = "Selenium Test";

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Url = "https://www.tut.by/";
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
        [TestCase("seleniumtests2@tut.by", "123456789zxcvbn")]
        public void CorrectUserLogin(string login, string password)
        {
            MainPage mainPage = new MainPage(driver);
            Thread.Sleep(1500);

            mainPage.LogIn(login, password);
            Assert.AreEqual(expectedUserName, mainPage.GetInformationAboutUserName(), "User names are not equal.");
        }

        [Test]
        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
        [TestCase("seleniumtests2@tut.by", "123456789zxcvbn")]
        public void LogoutTest(string login, string password)
        {
            MainPage mainPage = new MainPage(driver);
            Thread.Sleep(1500);

            mainPage.LogIn(login, password);
            Assert.AreEqual(expectedUserName, mainPage.GetInformationAboutUserName(), "User names are not equal.");

            mainPage.Logout();
            Assert.True(mainPage.CheckIfOpenMainPage(), "Main page is not open.");
        }
    }
}
