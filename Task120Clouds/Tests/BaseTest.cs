using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace Task110Nodes.Tests
{
    public class BaseTest
    {
        public IWebDriver driver;
        private readonly string Username = "Zhilinskaya_";
        private readonly string Key = "711d7acf-6f2d-4295-a23d-772c80b3afc3";

        public string operatingSystem;
        public string browserName;
        public string version;

        public BaseTest(string operatingSystem, string browserName, string version)
        {
            this.operatingSystem = operatingSystem;
            this.browserName = browserName;
            this.version = version;
        }

        [SetUp]
        public void SetUp()
        {
            var caps = GetOptions(operatingSystem, browserName, version);
            string uri = "http://{0}:{1}" + "@ondemand.eu-central-1.saucelabs.com:80/wd/hub";
            driver = new RemoteWebDriver(new Uri(string.Format(uri, Username, Key)), caps, TimeSpan.FromSeconds(25000));
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Url = "https://www.tut.by/";
        }

        private DesiredCapabilities GetOptions(string operatingSystem, string browserName, string version)
        {
            switch (browserName)
            {
                case "MicrosoftEdge":
                    DesiredCapabilities edgeCaps = new DesiredCapabilities();
                    edgeCaps.SetCapability("browserName", browserName);
                    edgeCaps.SetCapability("platform", operatingSystem);
                    edgeCaps.SetCapability("version", version);
                    edgeCaps.SetCapability("name", TestContext.CurrentContext.Test.Name);
                    return edgeCaps;

                case "Firefox":
                    DesiredCapabilities firefoxCaps = new DesiredCapabilities();
                    firefoxCaps.SetCapability("browserName", browserName);
                    firefoxCaps.SetCapability("platform", operatingSystem);
                    firefoxCaps.SetCapability("version", version);
                    firefoxCaps.SetCapability("name", TestContext.CurrentContext.Test.Name);
                    return firefoxCaps;

                case "Chrome":
                    DesiredCapabilities chromeCaps = new DesiredCapabilities();
                    chromeCaps.SetCapability("BrowserName", browserName);
                    chromeCaps.SetCapability("platform", operatingSystem);
                    chromeCaps.SetCapability("version", version);
                    chromeCaps.SetCapability("name", TestContext.CurrentContext.Test.Name);
                    return chromeCaps;
                default:
                    throw new NoSuchElementException("Driver is absent");
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
