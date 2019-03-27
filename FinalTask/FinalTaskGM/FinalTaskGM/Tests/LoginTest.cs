using FinalTaskGM.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTaskGM.Tests
{
    class LoginTest : BaseTest
    {
        private ChromeDriver chromeDriver;
        private string pathToScreenshots;

        const string expectedFirstUserName = "seleniumtests10@gmail.com";
        const string expectedSecondUserName = "seleniumtests30@gmail.com";
        const string expectedThirdUserName = "seleniumtests50@gmail.com";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            pathToScreenshots = $"{TestContext.CurrentContext.TestDirectory}\\Screenshots";
        }

        [SetUp]
        public void SetUp()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            chromeDriver.Url = "https://gmail.com";
            TakeScreenshot(pathToScreenshots, TestContext.CurrentContext.Test.MethodName, chromeDriver);
        }

        [TearDown]
        public void TearDown()
        {
            chromeDriver.Quit();
        }

        [TestCase("seleniumtests10", "060788avavav")]
        public void CorrectFirstUserLogin(string login, string password)
        {
            LoginPages loginPages = new LoginPages(chromeDriver);
            loginPages.EnterUserName(login);
            loginPages.EnterUserPassword(password);

            InboxPage inboxPage = new InboxPage(chromeDriver);
            
            Assert.AreEqual(expectedFirstUserName, inboxPage.GetInformationAboutUserName(), "User names are not equal.");
        }
        
        [TestCase("seleniumtests30", "060788avavav")]
        public void CorrectSecondtUserLogin(string login, string password)
        {
            LoginPages loginPages = new LoginPages(chromeDriver);
            loginPages.EnterUserName(login);
            loginPages.EnterUserPassword(password);

            InboxPage inboxPage = new InboxPage(chromeDriver);

            Assert.AreEqual(expectedSecondUserName, inboxPage.GetInformationAboutUserName(), "User names are not equal.");
        }
        
        [TestCase("seleniumtests50", "060788avavav")]
        public void CorrectThirdUserLogin(string login, string password)
        {
            LoginPages loginPages = new LoginPages(chromeDriver);
            loginPages.EnterUserName(login);
            loginPages.EnterUserPassword(password);

            InboxPage inboxPage = new InboxPage(chromeDriver);

            Assert.AreEqual(expectedThirdUserName, inboxPage.GetInformationAboutUserName(), "User names are not equal.");
        }
    }
}
