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

        public string GetInformationAboutUserName()
        {
            driver.FindElement(AccountIcon).Click();
            WaitUntilElementIsDisplayed(UserNameLabel, driver);
            string value = driver.FindElement(UserNameLabel).Text;
            return value;
        }

    }
}
