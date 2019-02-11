using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestWithFrames
{
    public class Frame
    {
        private IWebDriver driver;
        private By TextAreaWithText= By.XPath("//*[@id='tinymce']/p");
        private By BoldFormattinButton = By.XPath("//button[@role = 'presentation' and @type = 'button']/i[@class = 'mce-ico mce-i-bold']");
        private By TextAreaWithoutText = By.XPath("//*[@id='tinymce']");
        private By TextareaWithBoldText = By.XPath("//*[@id='tinymce']/p/span/strong");
        private const string firstTextPart = "Hello ";
        private const string secondTextPart = "world!";

        public Frame(ChromeDriver chromeDriver)
        {
            driver = chromeDriver;
        }

        public void ClearExistingText()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='mce_0_ifr']")));
            driver.FindElement(TextAreaWithText).Clear();
            driver.SwitchTo().DefaultContent();
        }

        public void AddFirstPartTextInTextArea()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='mce_0_ifr']")));
            driver.FindElement(TextAreaWithoutText).SendKeys(firstTextPart);
            driver.SwitchTo().DefaultContent();
        }

        public void ClickBoldButton() => driver.FindElement(BoldFormattinButton).Click();

        public void AddSecondPartTextInTextArea()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='mce_0_ifr']")));
            driver.FindElement(TextAreaWithoutText).SendKeys(secondTextPart);
            driver.SwitchTo().DefaultContent();
        }

        public string IsTextAreaGotASecondPartText()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='mce_0_ifr']")));
            string secondText = driver.FindElement(TextareaWithBoldText).Text;
            driver.SwitchTo().DefaultContent();
            return secondText;
        }

        public string IsTextAreaGotAFirstPartText()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@id='mce_0_ifr']")));
            string fullText = driver.FindElement(TextAreaWithText).Text;
            driver.SwitchTo().DefaultContent();
            return fullText;
        }
    }
}
