using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ScreenshotsTask80.PageObject
{
    public class MainPage : BasePage
    {
        private IWebDriver driver;
        private By EnterButton = By.LinkText("Войти");
        private By InputEmailButton = By.Name("login");
        private By InputPasswordButton = By.XPath("//input[@name = 'password']");
        private By SubmitButton = By.CssSelector(".auth__enter");
        private By UserNameButton = By.ClassName("uname");
        private By LogoutButton = By.XPath("//*[@id='authorize']//a[contains(@href, 'logout')]");

        public MainPage(ChromeDriver chromeDriver)
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
            WaitUntilElementIsDisplayed(UserNameButton, driver);
            string value = driver.FindElement(UserNameButton).Text;
            return value;
        }

        public void Logout()
        {
            driver.FindElement(UserNameButton).Click();
            driver.FindElement(LogoutButton).Click();
        }

        public bool CheckIfOpenMainPage() => driver.FindElement(EnterButton).Displayed;
    }
}
