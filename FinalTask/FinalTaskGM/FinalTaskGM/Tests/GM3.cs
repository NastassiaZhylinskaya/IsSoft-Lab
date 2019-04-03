using FinalTaskGM.PageObject;
using NUnit.Framework;
using System;

namespace FinalTaskGM.Tests
{
    [TestFixtureSource("Locally")]
    [TestFixture("SauceLabs")]
    [TestFixture("SeleniumGrid")]
    public class GM3 : BaseTest
    {
        public GM3(string type) : base(type)
        {
        }

        private const string user1email = "trainingtestqa111";
        private const string user1password = "TrainingQA111";
        private const string user2email = "trainingtestqa222";
        private const string user2password = "TrainingQA222";

        [Test]
        public void VerifyTheAbilityToSendEmails()
        {
            LoginPages loginPages = new LoginPages(driver);
            loginPages.EnterUserName(user1email);
            loginPages.EnterUserPassword(user1password);

            InboxPage inboxPage = new InboxPage(driver);
            inboxPage.ClickNewEmailButton();

            NewEmailTab newEmail = new NewEmailTab(driver);
            newEmail.WriteNewEmail();
            newEmail.SendNewEmail();

            string actualDate = DateTime.Now.Hour + ":" + DateTime.Now.Minute;

            inboxPage.ClickAccountIcon();
            inboxPage.ClickLogoutButton();

            loginPages.ClickChooseAccountButton();
            loginPages.ClickChangeAccountButton();

            loginPages.EnterUserName(user2email);
            loginPages.EnterUserPassword(user2password);

            Assert.AreEqual(inboxPage.GetDateMessage(), actualDate, "Actual date is not equal with expected date.");

        }
    }
}
