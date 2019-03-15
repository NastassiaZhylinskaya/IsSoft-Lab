using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using ScreenshotsTask80.PageObject;
using System;
using System.Threading;

namespace ScreenshotsTask80.Tests
{
    [TestFixture]
    public class TutByTest : BaseTest
    {
        private ChromeDriver chromeDriver;
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
            chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            chromeDriver.Url = "https://www.tut.by/";
            TakeScreenshot(pathToScreenshots, TestContext.CurrentContext.Test.MethodName, chromeDriver);
        }

        [TearDown]
        public void TearDown()
        {
            chromeDriver.Quit();
        }

        [Test]
        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
        [TestCase("seleniumtests2@tut.by", "123456789zxcvbn")]
        public void CorrectUserLogin(string login, string password)
        {
            MainPage mainPage = new MainPage(chromeDriver);
            Thread.Sleep(1500);

            mainPage.LogIn(login, password);
            Assert.AreEqual(expectedUserName, mainPage.GetInformationAboutUserName(), "User names are not equal.");
        }

        [Test]
        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
        [TestCase("seleniumtests2@tut.by", "123456789zxcvbn")]
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
