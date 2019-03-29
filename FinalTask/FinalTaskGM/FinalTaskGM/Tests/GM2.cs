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
    class GM2 : BaseTest
    {
        private ChromeDriver chromeDriver;
        private string pathToScreenshots;

        const string expectedFirstUserName = "trainingtestqa111@gmail.com";
        const string expectedSecondUserName = "trainingtestqa222@gmail.com";

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
            chromeDriver.Manage().Cookies.DeleteAllCookies();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            chromeDriver.Url = "https://gmail.com";
            TakeScreenshot(pathToScreenshots, TestContext.CurrentContext.Test.MethodName, chromeDriver);
        }

        [TearDown]
        public void TearDown()
        {
            chromeDriver.Quit();
        }

        [TestCase("trainingtestqa111", "TrainingQA111")]
        public void FirstUserLogin(string login, string password)
        {
            LoginPages loginPages = new LoginPages(chromeDriver);
            loginPages.EnterUserName(login);
            loginPages.EnterUserPassword(password);

            InboxPage inboxPage = new InboxPage(chromeDriver);
            
            Assert.AreEqual(expectedFirstUserName, inboxPage.GetInformationAboutUserName(), "User emails are not equal.");
        }
        
        [TestCase("trainingtestqa222", "TrainingQA222")]
        public void SecondtUserLogin(string login, string password)
        {
            LoginPages loginPages = new LoginPages(chromeDriver);
            loginPages.EnterUserName(login);
            loginPages.EnterUserPassword(password);

            InboxPage inboxPage = new InboxPage(chromeDriver);

            Assert.AreEqual(expectedSecondUserName, inboxPage.GetInformationAboutUserName(), "User emails are not equal.");
        }        
    }
}
