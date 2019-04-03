using FinalTaskGM.PageObject;
using NUnit.Framework;

namespace FinalTaskGM.Tests
{
    [TestFixtureSource("Locally")]
    [TestFixture("SauceLabs")]
    [TestFixture("SeleniumGrid")]
    public class GM2 : BaseTest
    {
        public GM2(string type) : base(type)
        {
        }

        const string expectedFirstUserName = "trainingtestqa111@gmail.com";
        const string expectedSecondUserName = "trainingtestqa222@gmail.com";
        
        [TestCase("trainingtestqa111", "TrainingQA111")]
        public void FirstUserLogout(string login, string password)
        {
            LoginPages loginPages = new LoginPages(driver);
            loginPages.EnterUserName(login);
            loginPages.EnterUserPassword(password);

            InboxPage inboxPage = new InboxPage(driver);
            inboxPage.ClickAccountIcon();
            inboxPage.ClickLogoutButton();

            Assert.AreEqual(expectedFirstUserName, inboxPage.CheckLogoutAccount(), "User emails are not equal.");
        }

        [TestCase("trainingtestqa222", "TrainingQA222")]
        public void SecondtUserLogout(string login, string password)
        {
            LoginPages loginPages = new LoginPages(driver);
            loginPages.EnterUserName(login);
            loginPages.EnterUserPassword(password);

            InboxPage inboxPage = new InboxPage(driver);
            inboxPage.ClickAccountIcon();
            inboxPage.ClickLogoutButton();

            Assert.AreEqual(expectedSecondUserName, inboxPage.CheckLogoutAccount(), "User emails are not equal.");
        }
    }
}
