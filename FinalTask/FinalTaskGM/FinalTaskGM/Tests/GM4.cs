using FinalTaskGM.PageObject;
using NUnit.Framework;
using System;

namespace FinalTaskGM.Tests
{
    [TestFixture(TestService.Locally)]
    [TestFixture(TestService.SauceLabs)]
    [TestFixture(TestService.SeleniumGrid)]
    public class GM4 : BaseTest
    {
        public GM4(TestService testService) : base(testService)
        {
        }

        private const string user1email = "trainingtestqa111";
        private const string user1password = "TrainingQA111";
       
        [Test]
        public void VerifyThatSentEmailAppearsInSentMailFolder()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterUserName(user1email);
            loginPage.EnterUserPassword(user1password);

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
