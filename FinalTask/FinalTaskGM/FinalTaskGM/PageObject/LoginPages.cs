using OpenQA.Selenium;
using System.Threading;

namespace FinalTaskGM.PageObject
{
    public class LoginPage : BasePage
    {
        private IWebDriver driver;

        public LoginPage (IWebDriver driver)
        {
            this.driver = driver;
        }   
        
        public By EmailTextField = By.Id("identifierId");
        public By NextOnEmailPageButton = By.XPath("//div[@id = 'identifierNext']/content/span");
        public By NextOnPasswordPageButton = By.XPath("//div[@id = 'passwordNext']/content/span");
        public By PasswordTextField = By.XPath("//input[@name = 'password']");
        public By ChooseAccountButton = By.XPath("//div[@id = 'profileIdentifier']");
        public By ChangeAccountButton = By.XPath("//div[@class = 'BHzsHc']");               

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
            driver.FindElement(NextOnPasswordPageButton).Click();
        }

        public void ClickChooseAccountButton()
        {
            Thread.Sleep(5000);
            driver.FindElement(ChooseAccountButton).Click();
        }

        public void ClickChangeAccountButton()
        {
            Thread.Sleep(5000);
            driver.FindElements(ChangeAccountButton)[0].Click();
        }
    }
}
