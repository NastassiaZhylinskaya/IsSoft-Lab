using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task20_TC
{
    class LogInForm
    {
        private IWebDriver driver;
        private By EnterButton = By.LinkText("Войти");
        private By InputEmailButton = By.Name("login");
        private By InputPasswordButton = By.XPath("//input[@name = 'password']");
        private By SubmitButton = By.CssSelector(".auth__enter");
        private By UserNameButton = By.ClassName("uname");

        public LogInForm(ChromeDriver chromeDriver)
        {
            driver = chromeDriver;
        }

        public void LogIn(string userEmail, string userPassword)
        {
            driver.FindElement(EnterButton).Click();
            driver.FindElement(InputEmailButton).SendKeys(userEmail);
            driver.FindElement(InputPasswordButton).SendKeys(userPassword);
            driver.FindElement(SubmitButton).Click();
        }

        public string GetInformationAboutUserName()
        {
            string value = driver.FindElement(UserNameButton).Text;
            return value;
        }

    }
}