using FinalTaskGM.PageObject;
using NUnit.Framework;
using System;

namespace FinalTaskGM.Tests
{
    [TestFixture(TestService.Locally)]
    [TestFixture(TestService.SauceLabs)]
    [TestFixture(TestService.SeleniumGrid)]
    public class GM3 : BaseTest
    {
        public GM3(TestService testService) : base(testService)
        {
        }

        private const string user1email = "trainingtestqa111";
        private const string user1password = "TrainingQA111";
        private const string user2email = "trainingtestqa222";
        private const string user2password = "TrainingQA222";

        [Test]
        public void VerifyTheAbilityToSendEmails()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterUserName(user1email);
            loginPage.EnterUserPassword(user1password);

            InboxPage inboxPage = new InboxPage(driver);
            inboxPage.ClickNewEmailButton();

            NewEmailTab newEmail = new NewEmailTab(driver);
            newEmail.WriteNewEmail();
            newEmail.SendNewEmail();

            string actualDate = DateTime.Now.Hour + ":" + DateTime.Now.Minute;

            inboxPage.ClickAccountIcon();
            inboxPage.ClickLogoutButton();

            loginPage.ClickChooseAccountButton();
            loginPage.ClickChangeAccountButton();

            loginPage.EnterUserName(user2email);
            loginPage.EnterUserPassword(user2password);

            Assert.AreEqual(inboxPage.GetDateMessage(), actualDate, "Actual date is not equal with expected date.");

        }
    }
}
