using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FinalTaskGM.PageObject
{
    public class InboxPage : BasePage
    {
        private IWebDriver driver;

        public InboxPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By UserNameLabel = By.XPath("//div[@class = 'gb_db']");
        private By AccountIcon = By.XPath("//span[@class = 'gb_ya gbii']");
        private By LogoutButton = By.XPath("//a[@id ='gb_71']");
        private By ProfileIdentifireLabel = By.XPath("//div[@id ='profileIdentifier']");
        private By NewEmailButton = By.XPath("//div[@class = 'T-I J-J5-Ji T-I-KE L3']");
        private By SendedEmailsButton = By.XPath("//div[@class = 'TN bzz aHS-bnu']/div[2]/span/a");

        public void ClickLogoutButton()
        {
            driver.FindElement(LogoutButton).Click();
        }

        public void ClickAccountIcon()
        {
            WaitUntilElementIsDisplayed(AccountIcon, driver);
            driver.FindElement(AccountIcon).Click();
        }

        public void ClickNewEmailButton()
        {
            WaitUntilElementIsDisplayed(NewEmailButton, driver);
            driver.FindElement(NewEmailButton).Click();
        }

        public void ClickSendedEmailsButton()
        {
            WaitUntilElementIsDisplayed(SendedEmailsButton, driver);
            driver.FindElement(SendedEmailsButton).Click();
        }

        public string CheckLogoutAccount()
        {
            WaitUntilElementIsDisplayed(ProfileIdentifireLabel, driver);
            string value = driver.FindElement(ProfileIdentifireLabel).Text;
            return value;
        }

        public string GetInformationAboutUserName()
        {
            driver.FindElement(AccountIcon).Click();
            WaitUntilElementIsDisplayed(UserNameLabel, driver);
            string value = driver.FindElement(UserNameLabel).Text;
            return value;
        }

    }
}
