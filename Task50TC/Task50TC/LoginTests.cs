using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Task50TC
{
    [TestFixture]
    class LoginTests
    {
        private ChromeDriver chromeDriver;
        const string expectedUserName = "Selenium Test";

        [SetUp]
        public void SetUp()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            chromeDriver.Url = "https://www.tut.by/";
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
            LogInForm logIn = new LogInForm(chromeDriver);
            Thread.Sleep(1500);
            logIn.LogIn(login, password);
            Assert.AreEqual(expectedUserName, logIn.GetInformationAboutUserName(), "User names are not equal.");
        }
    }
}
