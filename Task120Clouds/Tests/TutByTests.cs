using NUnit.Framework;
using System.Threading;
using Task110Nodes.PageObject;

namespace Task110Nodes.Tests
{
    [TestFixture("Windows 10", "MicrosoftEdge", "18")]
    [TestFixture("Windows 8.1", "Firefox", "39.0")]
    [TestFixture("Linux", "Chrome", "40")]
    public class TutByTests : BaseTest
    {
        const string expectedUserName = "Selenium Test";
        private string pathToScreenshots;

        public TutByTests(string operatingSystem, string browserName, string version) : base(operatingSystem, browserName, version)
        {
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            pathToScreenshots = $"{TestContext.CurrentContext.TestDirectory}\\Screenshots";
        }

        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
        [TestCase("seleniumtests2@tut.by", "123456789zxcvbn")]
        public void CorrectUserLogin(string login, string password)
        {
            MainPage mainPage = new MainPage(driver);
            Thread.Sleep(1500);

            mainPage.LogIn(login, password);
            Assert.AreEqual(expectedUserName, mainPage.GetInformationAboutUserName(), "User names are not equal.");
        }
        
        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
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
