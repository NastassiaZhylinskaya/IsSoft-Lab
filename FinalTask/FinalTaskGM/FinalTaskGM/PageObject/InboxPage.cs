using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

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
        private By OpenEmailButton = By.CssSelector("div[role='main'] tbody>tr>td>div>div>div>span>span");
        private By DateSendedMessage = By.CssSelector("div[role = 'main'] tbody>tr>td>span>span");
        private By CheckBoxToDeleteEmail = By.CssSelector("div[role='tabpanel'] div[role='checkbox']");
        private By DeleteMessageButton = By.XPath("//div[@class='T-I J-J5-Ji nX T-I-ax7 T-I-Js-Gs mA']");
        private By MoreOptionsButton = By.XPath("//*[@class='CJ'][contains(text(),'Ещё')]");
        private By TrashedEmailsButton = By.XPath("//div[@data-tooltip='Корзина']");

        public void ClickLogoutButton()
        {
            Thread.Sleep(5000);
            driver.FindElement(LogoutButton).Click();
        }

        public void ClickAccountIcon()
        {
            WaitUntilElementIsDisplayed(AccountIcon, driver);
            Thread.Sleep(5000);
            driver.FindElement(AccountIcon).Click();
        }

        public void ClickNewEmailButton()
        {
            Thread.Sleep(1000);
            WaitUntilElementIsDisplayed(NewEmailButton, driver);
            driver.FindElement(NewEmailButton).Click();
        }

        public void ClickSendedEmailsButton()
        {
            Thread.Sleep(1000);
            WaitUntilElementIsDisplayed(SendedEmailsButton, driver);
            driver.FindElement(SendedEmailsButton).Click();
        }

        public void ClickOpenEmailButton()
        {
            Thread.Sleep(1000);
            WaitUntilElementIsDisplayed(OpenEmailButton, driver);
            driver.FindElement(OpenEmailButton).Click();
        }

        public string CheckLogoutAccount()
        {
            Thread.Sleep(1000);
            WaitUntilElementIsDisplayed(ProfileIdentifireLabel, driver);
            string value = driver.FindElement(ProfileIdentifireLabel).Text;
            return value;
        }

        public string GetInformationAboutUserName()
        {
            Thread.Sleep(1000);
            driver.FindElement(AccountIcon).Click();
            WaitUntilElementIsDisplayed(UserNameLabel, driver);
            string value = driver.FindElement(UserNameLabel).Text;
            return value;
        }

        public string GetDateMessage()
        {
            Thread.Sleep(5000);
            string date = driver.FindElements(DateSendedMessage)[0].Text;
            return date;
        }
        
        public void ClickCheckBoxToDeleteEmail()
        {
            Thread.Sleep(1000);
            driver.FindElements(CheckBoxToDeleteEmail)[0].Click();
        }

        public void ClickDeleteMessageButton()
        {
            Thread.Sleep(3000);
            driver.FindElement(DeleteMessageButton).Click();
        }

        public void ClickMoreOptionsButton()
        {
            Thread.Sleep(3000);
            driver.FindElement(MoreOptionsButton).Click();
        }

        public void ClickTrashedEmailsButton()
        {
            Thread.Sleep(3000);
            driver.FindElement(TrashedEmailsButton).Click();
        }
    }
}
