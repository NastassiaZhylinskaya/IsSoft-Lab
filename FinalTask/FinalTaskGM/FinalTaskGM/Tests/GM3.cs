using FinalTaskGM.PageObject;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace FinalTaskGM.Tests
{
    public class GM3 : BaseTest
    {
        private ChromeDriver chromeDriver;
        private const string user1email = "trainingtestqa111";
        private const string user1password = "TrainingQA111";
        private string pathToScreenshots;
        
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

        [Test]
        public void VerifyTheAbilityToSendEmails()
        {
            LoginPages loginPages = new LoginPages(chromeDriver);
            loginPages.EnterUserName(user1email);
            loginPages.EnterUserPassword(user1password);

            InboxPage inboxPage = new InboxPage(chromeDriver);
            inboxPage.ClickNewEmailButton();

            NewEmailTab newEmail = new NewEmailTab(chromeDriver);
            newEmail.WriteNewEmail();
            newEmail.SendNewEmail();
            inboxPage.ClickSendedEmailsButton();
        }

    }
}
