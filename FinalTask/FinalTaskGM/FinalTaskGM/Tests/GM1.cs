using FinalTaskGM.PageObject;
using NUnit.Framework;

namespace FinalTaskGM.Tests
{
    [TestFixture("Locally")]
    [TestFixture("SauceLabs")]
    [TestFixture("SeleniumGrid")]
    public class GM1 : BaseTest
    {
        public GM1(string type) : base (type)
        {            
        }

        const string expectedFirstUserName = "trainingtestqa111@gmail.com";
        const string expectedSecondUserName = "trainingtestqa222@gmail.com";        

        [TestCase("trainingtestqa111", "TrainingQA111")]
        public void FirstUserLogin(string login, string password)
        {
            LoginPages loginPages = new LoginPages(driver);
            loginPages.EnterUserName(login);
            loginPages.EnterUserPassword(password);

            InboxPage inboxPage = new InboxPage(driver);
            
            Assert.AreEqual(expectedFirstUserName, inboxPage.GetInformationAboutUserName(), "User emails are not equal.");
        }
        
        [TestCase("trainingtestqa222", "TrainingQA222")]
        public void SecondtUserLogin(string login, string password)
        {
            LoginPages loginPages = new LoginPages(driver);
            loginPages.EnterUserName(login);
            loginPages.EnterUserPassword(password);

            InboxPage inboxPage = new InboxPage(driver);

            Assert.AreEqual(expectedSecondUserName, inboxPage.GetInformationAboutUserName(), "User emails are not equal.");
        }        
    }
}
