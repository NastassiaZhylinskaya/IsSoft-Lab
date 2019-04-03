using FinalTaskGM.PageObject;
using NUnit.Framework;
using System;

namespace FinalTaskGM.Tests
{
    [TestFixtureSource("Locally")]
    [TestFixture("SauceLabs")]
    [TestFixture("SeleniumGrid")]
    public class GM4 : BaseTest
    {
        public GM4(string type) : base(type)
        {
        }

        private const string user1email = "trainingtestqa111";
        private const string user1password = "TrainingQA111";
       
        [Test]
        public void VerifyThatSentEmailAppearsInSentMailFolder()
        {
            LoginPages loginPages = new LoginPages(driver);
            loginPages.EnterUserName(user1email);
            loginPages.EnterUserPassword(user1password);

            InboxPage inboxPage = new InboxPage(driver);
            inboxPage.ClickNewEmailButton();

            string actualDate = DateTime.Now.Hour + ":" + DateTime.Now.Minute;

            NewEmailTab newEmail = new NewEmailTab(driver);
            newEmail.WriteNewEmail();
            newEmail.SendNewEmail();
            inboxPage.ClickSendedEmailsButton();
            Assert.AreEqual(inboxPage.GetDateMessage(), actualDate, "Actual date is not equal with expected date.");
        }

    }
}
