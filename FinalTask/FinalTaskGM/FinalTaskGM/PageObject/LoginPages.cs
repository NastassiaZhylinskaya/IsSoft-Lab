using OpenQA.Selenium;


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
               

        public void EnterUserName(string userEmail)
        {
            driver.FindElement(EmailTextField).SendKeys(userEmail);
            driver.FindElement(NextOnEmailPageButton).Click();
        }

        public void EnterUserPassword(string userPassword)
        {
            driver.FindElement(PasswordTextField).SendKeys(userPassword);
            WaitUntilElementIsDisplayed(NextOnPasswordPageButton, driver);
            driver.FindElement(NextOnPasswordPageButton).Click();
        }

    }
}
