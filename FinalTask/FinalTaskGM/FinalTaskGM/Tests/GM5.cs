using FinalTaskGM.PageObject;
using NUnit.Framework;

namespace FinalTaskGM.Tests
{
    [TestFixtureSource("Locally")]
    [TestFixture("SauceLabs")]
    [TestFixture("SeleniumGrid")]
    public class GM5 : BaseTest
    {
        public GM5(string type) : base(type)
        {
        }

        private const string user2email = "trainingtestqa222";
        private const string user2password = "TrainingQA222";

        [Test]
        public void VerifyThatDeletedEmailIsListedInTrash()
        {
            LoginPages loginPages = new LoginPages(driver);
            loginPages.EnterUserName(user2email);
            loginPages.EnterUserPassword(user2password);

            InboxPage inboxPage = new InboxPage(driver);
            string dateEmails = inboxPage.GetDateMessage();
            inboxPage.ClickCheckBoxToDeleteEmail();
            inboxPage.ClickDeleteMessageButton();
            inboxPage.ClickMoreOptionsButton();
            inboxPage.ClickTrashedEmailsButton();
            Assert.AreEqual(inboxPage.GetDateMessage(), dateEmails, "Actual date is not equal with expected date.");
        }
    }
}
