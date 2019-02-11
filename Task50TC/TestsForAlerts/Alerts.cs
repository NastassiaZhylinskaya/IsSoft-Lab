using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestsForAlerts
{
    public class Alerts
    {
        private IWebDriver driver;
        private By FirstJSAlert = By.XPath("//button[@onclick = 'jsAlert()']");
        private By SecondJSConfirm = By.XPath("//button[@onclick = 'jsConfirm()']");
        private By ThirdJSPrompt = By.XPath("//button[@onclick = 'jsPrompt()']");
        private By ResultOfAlert = By.XPath("//p[@id = 'result']");

        public Alerts(ChromeDriver chromeDriver)
        {
            driver = chromeDriver;
        }

        public void SwitchToFirstAlert()
        {
            driver.FindElement(FirstJSAlert).Click();
            driver.SwitchTo().Alert().Accept();
        }

        public string GetResultTextAfterAlert()
        {
            string result = driver.FindElement(ResultOfAlert).Text;
            return result;
        }

        public void SwitchToSecondAlertForAccept()
        {
            driver.FindElement(SecondJSConfirm).Click();
            driver.SwitchTo().Alert().Accept();
        }

        public void SwitchToSecondAlertForDismiss()
        {
            driver.FindElement(SecondJSConfirm).Click();
            driver.SwitchTo().Alert().Dismiss();
        }

        public void SwitchToThirdAlertForAccept()
        {
            driver.FindElement(ThirdJSPrompt).Click();
            driver.SwitchTo().Alert().Accept();
        }

        public void SwitchToThirdAlertForDismiss()
        {
            driver.FindElement(ThirdJSPrompt).Click();
            driver.SwitchTo().Alert().Dismiss();
        }

        public void SwitchToThirdAlertForSendText()
        {
            driver.FindElement(ThirdJSPrompt).Click();
            driver.SwitchTo().Alert().SendKeys("Hello world!");
            driver.SwitchTo().Alert().Accept();
        }
    }
}
