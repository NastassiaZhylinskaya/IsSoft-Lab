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

        public By UserNameLabel = By.XPath("//div[@class = 'gb_db']");
        public By AccountIcon = By.XPath("//span[@class = 'gb_ya gbii']");
        public By LogoutButton = By.XPath("//a[@id ='gb_71']");
        public By ProfileIdentifireLabel = By.XPath("//div[@id ='profileIdentifier']");
        public By NewEmailButton = By.XPath("//div[@class = 'T-I J-J5-Ji T-I-KE L3']");
        public By SendedEmailsButton = By.XPath("//div[@class = 'TN bzz aHS-bnu']/div[2]/span/a");
        public By DateSendedMessage = By.CssSelector("div[role = 'main'] tbody>tr>td>span>span");
        public By CheckBoxToDeleteEmail = By.CssSelector("div[role='tabpanel'] div[role='checkbox']");
        public By DeleteMessageButton = By.XPath("//div[@class='T-I J-J5-Ji nX T-I-ax7 T-I-Js-Gs mA']");
        public By MoreOptionsButton = By.XPath("//*[@class='CJ'][contains(text(),'Ещё')]");
        public By TrashedEmailsButton = By.XPath("//div[@data-tooltip='Корзина']");

        public void ClickLogoutButton()
        {
            Thread.Sleep(5000);
            driver.FindElement(LogoutButton).Click();
        }

        public void ClickAccountIcon()
        {
            Thread.Sleep(5000);
            driver.FindElement(AccountIcon).Click();
        }

        public void ClickNewEmailButton()
        {
            Thread.Sleep(1000);
            driver.FindElement(NewEmailButton).Click();
        }

        public void ClickSendedEmailsButton()
        {
            Thread.Sleep(1000);
            driver.FindElement(SendedEmailsButton).Click();
        }

        public string CheckLogoutAccount()
        {
            Thread.Sleep(1000);
            return driver.FindElement(ProfileIdentifireLabel).Text;
        }

        public string GetInformationAboutUserName()
        {
            Thread.Sleep(1000);
            driver.FindElement(AccountIcon).Click();
            return driver.FindElement(UserNameLabel).Text;
        }

        public string GetDateMessage()
        {
            Thread.Sleep(5000);
            return driver.FindElements(DateSendedMessage)[0].Text;
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
