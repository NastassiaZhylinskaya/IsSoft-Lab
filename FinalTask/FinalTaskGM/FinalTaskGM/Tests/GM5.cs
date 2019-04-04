using FinalTaskGM.PageObject;
using NUnit.Framework;

namespace FinalTaskGM.Tests
{
    [TestFixture(TestService.Locally)]
    [TestFixture(TestService.SauceLabs)]
    [TestFixture(TestService.SeleniumGrid)]
    public class GM5 : BaseTest
    {
        public GM5(TestService testService) : base(testService)
        {
        }

        private const string user2email = "trainingtestqa222";
        private const string user2password = "TrainingQA222";

        [Test]
        public void VerifyThatDeletedEmailIsListedInTrash()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterUserName(user2email);
            loginPage.EnterUserPassword(user2password);

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
