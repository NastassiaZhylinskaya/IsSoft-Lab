using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace Task20_TC
{
    [TestFixture]
    class LoginTests
    {
        private const string USEREMAIL = "seleniumtests@tut.by";
        private const string USERPASSWORD = "123456789zxcvbn";
        
        private ChromeDriver chromeDriver;

        [SetUp]
        public void SetUp()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            chromeDriver.Url = "https://www.tut.by/";
        }

        [TearDown]
        public void TearDown()
        {
            chromeDriver.Quit();
        }

        [Test]
        public void CorrectUserLogin()
        {
            string expectedUserName = "Selenium Test";
            LogInForm logIn = new LogInForm(chromeDriver);
            logIn.LogIn(USEREMAIL, USERPASSWORD);
            Assert.AreEqual(expectedUserName, logIn.GetInformationAboutUserName(), "User names are not equal.");
        }
    }
}
