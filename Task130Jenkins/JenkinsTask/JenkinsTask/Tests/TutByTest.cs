using Allure.Commons;
using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using JenkinsTask.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace JenkinsTask.Tests
{
    [TestFixture]
    [AllureSuite("Tests for Tut.by")]
    public class TutByTests : AllureReport
    {
        private IWebDriver chromeDriver;
        const string expectedUserName = "Selenium Test";
        private string pathToScreenshots;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            pathToScreenshots = $"{TestContext.CurrentContext.TestDirectory}\\Screenshots";
        }

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            //chromeDriver = new ChromeDriver();
            chromeDriver = new RemoteWebDriver(new Uri("http://localhost:4555/wd/hub"), options);
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            chromeDriver.Url = "https://www.tut.by/";
        }

        [TearDown]
        public void TearDown()
        {
            chromeDriver.Quit();
        }

        [AllureOwner("Nastya Zhilinskaya")]
        [AllureTest("Login tests.")]
        [AllureSeverity(SeverityLevel.Critical)]
        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
        [TestCase("seleniumtests2@tut.by", "123456789zxcvbn")]
        public void CorrectUserLogin(string login, string password)
        {
            MainPage mainPage = new MainPage(chromeDriver);
            Thread.Sleep(1500);

            mainPage.LogIn(login, password);
            Assert.AreEqual(expectedUserName, mainPage.GetInformationAboutUserName(), "User names are not equal.");
        }

        [AllureOwner("Nastya Zhilinskaya")]
        [AllureTest("Login tests.")]
        [AllureSeverity(SeverityLevel.Critical)]
        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
        public void LogoutTest(string login, string password)
        {
            MainPage mainPage = new MainPage(chromeDriver);
            Thread.Sleep(1500);

            mainPage.LogIn(login, password);
            Assert.AreEqual(expectedUserName, mainPage.GetInformationAboutUserName(), "User names are not equal.");

            mainPage.Logout();
            Assert.True(mainPage.CheckIfOpenMainPage(), "Main page is not open.");
        }
    }
}
