using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageFactoryTask70.PageObjects
{
    public class BasePage
    {
        private readonly IClock clock = new SystemClock();
        private readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitUntilElementIsDisplayed(IWebElement iWebElement, IWebDriver driver)
        {
            var element = new WebDriverWait(clock, driver, TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(1500)).Until(condition =>
            {
                if (iWebElement.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            });
        }
    }
}
