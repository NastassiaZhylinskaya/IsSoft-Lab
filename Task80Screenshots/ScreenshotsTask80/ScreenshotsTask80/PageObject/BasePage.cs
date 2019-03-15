using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ScreenshotsTask80.PageObject
{
    public class BasePage
    {
        private readonly IClock clock = new SystemClock();

        public void WaitUntilElementIsDisplayed(By locator, IWebDriver driver)
        {
            var element = new WebDriverWait(clock, driver, TimeSpan.FromSeconds(10), TimeSpan.FromMilliseconds(1500)).Until(condition =>
            {
                if (driver.FindElement(locator).Displayed)
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
