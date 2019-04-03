using OpenQA.Selenium;
using System.Threading;

namespace FinalTaskGM.PageObject
{
    public class LoginPages : BasePage
    {
        private IWebDriver driver;
        public LoginPages(IWebDriver driver)
        {
            this.driver = driver;
        }   
        
        private By EmailTextField = By.Id("identifierId");
        private By NextOnEmailPageButton = By.XPath("//div[@id = 'identifierNext']/content/span");
        private By NextOnPasswordPageButton = By.XPath("//div[@id = 'passwordNext']/content/span");
        private By PasswordTextField = By.XPath("//input[@name = 'password']");
        private By ChooseAccountButton = By.XPath("//div[@id = 'profileIdentifier']");
        private By ChangeAccountButton = By.XPath("//div[@class = 'BHzsHc']");
               

        public void EnterUserName(string userEmail)
        {
            Thread.Sleep(1000);
            driver.FindElement(EmailTextField).SendKeys(userEmail);
            driver.FindElement(NextOnEmailPageButton).Click();
        }

        public void EnterUserPassword(string userPassword)
        {
            Thread.Sleep(1000);
            driver.FindElement(PasswordTextField).SendKeys(userPassword);
            WaitUntilElementIsDisplayed(NextOnPasswordPageButton, driver);
            driver.FindElement(NextOnPasswordPageButton).Click();
        }

        public void ClickChooseAccountButton()
        {
            Thread.Sleep(5000);
            WaitUntilElementIsDisplayed(ChooseAccountButton, driver);
            driver.FindElement(ChooseAccountButton).Click();
        }

        public void ClickChangeAccountButton()
        {
            Thread.Sleep(5000);
            driver.FindElements(ChangeAccountButton)[0].Click();
        }

    }
}
