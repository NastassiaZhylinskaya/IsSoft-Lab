using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageFactoryTask70.PageObjects
{
    public class MainPage : BasePage
    {
        private readonly IWebDriver driver;

        [FindsBy(How = How.LinkText, Using = "Войти")]
        private IWebElement EnterButton;

        [FindsBy(How = How.Name, Using = "login")]
        private IWebElement InputEmailButton;

        [FindsBy(How = How.XPath, Using = "//input[@name = 'password']")]
        private IWebElement InputPasswordButton;

        [FindsBy(How = How.CssSelector, Using = ".auth__enter")]
        private IWebElement SubmitButton;

        [FindsBy(How = How.ClassName, Using = "uname")]
        private IWebElement UserNameButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='authorize']//a[contains(@href, 'logout')]")]
        private IWebElement LogoutButton;

        public MainPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LogIn(string userEmail, string userPassword)
        {
            EnterButton.Click();
            InputEmailButton.SendKeys(userEmail);
            InputPasswordButton.SendKeys(userPassword);
            SubmitButton.Click();
        }

        public string GetInformationAboutUserName()
        {
            WaitUntilElementIsDisplayed(UserNameButton, driver);
            string value = UserNameButton.Text;
            return value;
        }

        public void Logout()
        {
            UserNameButton.Click();
            LogoutButton.Click();
        }

        public bool CheckIfOpenMainPage() => EnterButton.Displayed;
    }
}
