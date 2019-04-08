using FinalTaskGM.PageObject;
using NUnit.Framework;

namespace FinalTaskGM.Tests
{
    [TestFixture(TestService.Locally)]
    [TestFixture(TestService.SauceLabs)]
    [TestFixture(TestService.SeleniumGrid)]
    public class GM1 : BaseTest
    {
        public GM1 (TestService testService) : base(testService)
        {
        }

        const string expectedFirstUserName = "trainingtestqa111@gmail.com";
        const string expectedSecondUserName = "trainingtestqa222@gmail.com";        

        [TestCase("trainingtestqa111", "TrainingQA111")]
        public void FirstUserLogin(string login, string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterUserName(login);
            loginPage.EnterUserPassword(password);

            InboxPage inboxPage = new InboxPage(driver);
            
            Assert.AreEqual(expectedFirstUserName, inboxPage.GetInformationAboutUserName(), "User emails are not equal.");
        }
        
        [TestCase("trainingtestqa222", "TrainingQA222")]
        public void SecondtUserLogin(string login, string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.EnterUserName(login);
            loginPage.EnterUserPassword(password);

            InboxPage inboxPage = new InboxPage(driver);

            Assert.AreEqual(expectedSecondUserName, inboxPage.GetInformationAboutUserName(), "User emails are not equal.");
        }        
    }
}
