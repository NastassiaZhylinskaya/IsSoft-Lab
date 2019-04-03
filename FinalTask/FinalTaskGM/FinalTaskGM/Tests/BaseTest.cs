using Allure.Commons;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FinalTaskGM.Tests
{
    public class BaseTest : AllureReport
    {
        public IWebDriver driver { get; set; }
        protected string pathToScreenshots;
        public string TestService { get; }

        public BaseTest(string type)
        {
            TestService = type;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            pathToScreenshots = $"{TestContext.CurrentContext.TestDirectory}\\Screenshots";
            switch (TestService)
            {
                case "Locally":
                    {
                        driver = new ChromeDriver();
                        driver.Manage().Window.Maximize();
                        driver.Manage().Cookies.DeleteAllCookies();
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                        driver.Url = "https://gmail.com";
                        break;
                    }

                case "SauceLabs":
                    {
                        var uri = "http://192.168.100.70:5555/wd/hub";
                        var capabilities = new ChromeOptions();
                        var caps = new DesiredCapabilities();

                        caps.SetCapability(CapabilityType.Version, "latest");
                        caps.SetCapability(CapabilityType.BrowserName, "Chrome");
                        caps.SetCapability(CapabilityType.Platform, "Windows 10");
                        caps.SetCapability("username", "Zhilinskaya_");
                        caps.SetCapability("accessKey", "711d7acf-6f2d-4295-a23d-772c80b3afc3");
                        caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

                        var commandTimeout = TimeSpan.FromMinutes(1);
                        driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps,
                        TimeSpan.FromSeconds(15));
                        driver.Manage().Window.Maximize();
                        driver.Manage().Cookies.DeleteAllCookies();
                        driver.Url = "https://gmail.com";
                        break;
                    }

                case "SeleniumGrid":
                    {
                        var uri = "http://localhost:4555/wd/hub";
                        var capabilities = new ChromeOptions().ToCapabilities();
                        var desiredCapabilities = new DesiredCapabilities();
                        var commandTimeout = TimeSpan.FromMinutes(1);
                        driver = new RemoteWebDriver(new Uri(uri), capabilities, commandTimeout);
                        driver.Manage().Window.Maximize();
                        driver.Manage().Cookies.DeleteAllCookies();
                        driver.Url = "https://gmail.com";
                        break;
                    }
            }
        }      

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        public void TakeScreenshot(string directory, string name, ChromeDriver chromeDriver)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string screenshotFileName = string.Format("{0}{1}.{2}", name, DateTime.Now.ToString("dd.MM"), ImageFormat.Jpeg.ToString().ToLowerInvariant());
            string pathToScreenshot = Path.Combine(directory, screenshotFileName);
            using (Image screenshot = Image.FromStream(new MemoryStream(((ITakesScreenshot)chromeDriver).GetScreenshot().AsByteArray)))
            {
                screenshot.Save(pathToScreenshot);
            }
            TestContext.AddTestAttachment(pathToScreenshot, null);
        }
    }
}
