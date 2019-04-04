using OpenQA.Selenium;
using System.Threading;

namespace FinalTaskGM.PageObject
{
    public class NewEmailTab : BasePage
    {
        private IWebDriver driver;

        public NewEmailTab(IWebDriver driver)
        {
            this.driver = driver;
        }

        private const string secondUserEmail = "trainingtestqa222@gmail.com";
        private const string textOfTheMessage = "Hello User!";
        public By SendToTextArea = By.XPath("//textarea[@name = 'to']");
        public By EmailBodyTextArea = By.XPath("//td[@class = 'Ap']/div[@class = 'Ar Au']/div[@class = 'Am Al editable LW-avf']");
        public By EnterEmailButton = By.XPath("//div[@class = 'T-I J-J5-Ji aoO T-I-atl L3']");
        public By ChooseEmailButton = By.XPath("//div[@class = 'aq aFf']");
        
        public void WriteNewEmail()
        {
            Thread.Sleep(1000);
            driver.FindElement(SendToTextArea).SendKeys(secondUserEmail);
            Thread.Sleep(1000);
            driver.FindElement(ChooseEmailButton).Click();
            driver.FindElement(EmailBodyTextArea).SendKeys(textOfTheMessage);
        }

        public void SendNewEmail()
        {
            Thread.Sleep(1000);
            driver.FindElement(EnterEmailButton).Click();
        }
    }
}
