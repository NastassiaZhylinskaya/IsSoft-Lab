using FinalTaskGM.PageObject;
using NUnit.Framework;

namespace FinalTaskGM.Tests
{
    [TestFixture(TestService.Locally)]
    [TestFixture(TestService.SauceLabs)]
    [TestFixture(TestService.SeleniumGrid)]
    public class GM2 : BaseTest
    {
        public GM2(TestService testService) : base(testService)
        {
        }

        const string expectedFirstUserName = "trainingtestqa111@gmail.com";
        const string expectedSecondUserName = "trainingtestqa222@gmail.com";
        
        [TestCase("trainingtestqa111", "TrainingQA111")]
        public void FirstUserLogout(string login, string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterUserName(login);
            loginPage.EnterUserPassword(password);

            InboxPage inboxPage = new InboxPage(driver);
            inboxPage.ClickAccountIcon();
            inboxPage.ClickLogoutButton();

            Assert.AreEqual(expectedFirstUserName, inboxPage.CheckLogoutAccount(), "User emails are not equal.");
        }

        [TestCase("trainingtestqa222", "TrainingQA222")]
        public void SecondtUserLogout(string login, string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterUserName(login);
            loginPage.EnterUserPassword(password);

            InboxPage inboxPage = new InboxPage(driver);
            inboxPage.ClickAccountIcon();
            inboxPage.ClickLogoutButton();

            Assert.AreEqual(expectedSecondUserName, inboxPage.CheckLogoutAccount(), "User emails are not equal.");
        }
    }
}
