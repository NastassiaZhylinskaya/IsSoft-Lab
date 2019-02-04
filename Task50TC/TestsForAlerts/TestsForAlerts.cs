using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace TestsForAlerts
{
    [TestFixture]
    public class TestsForAlerts
    {
        private ChromeDriver chromeDriver;
        private const string expectedFirstAlertMessage = "You successfuly clicked an alert";
        private const string expectedSecondAcceptAlertMessage = "You clicked: Ok";
        private const string expectedSecondDismissAlertMessage = "You clicked: Cancel";
        private const string expectedThirdAcceptAlertMessage = "You entered:";
        private const string expectedThirdDismissAlertMessage = "You entered: null";
        private const string expectedThirdSendTextAlertMessage = "You entered: Hello world!";

        [SetUp]
        public void SetUp()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            chromeDriver.Url = "https://the-internet.herokuapp.com/javascript_alerts";
        }

        [TearDown]
        public void TearDown()
        {
            chromeDriver.Quit();
        }

        [Test]
        public void SwitchToJSAlert()
        {
            Alerts alerts = new Alerts(chromeDriver);
            alerts.SwitchToFirstAlert();
            Assert.AreEqual(expectedFirstAlertMessage, alerts.GetResultTextAfterAlert(), "Expected text for first alert is wrong.");
        }

        [Test]
        public void SwitchToJSConfirmAlert()
        {
            Alerts alerts = new Alerts(chromeDriver);
            alerts.SwitchToSecondAlertForAccept();
            Assert.AreEqual(expectedSecondAcceptAlertMessage, alerts.GetResultTextAfterAlert(), "Expected text for second alert with accept button is wrong.");

            alerts.SwitchToSecondAlertForDismiss();
            Assert.AreEqual(expectedSecondDismissAlertMessage, alerts.GetResultTextAfterAlert(), "Expected text for second alert with dismiss button is wrong.");
        }

        [Test]
        public void SwitchToJSPromptAlert()
        {
            Alerts alerts = new Alerts(chromeDriver);
            alerts.SwitchToThirdAlertForAccept();
            Assert.AreEqual(expectedThirdAcceptAlertMessage, alerts.GetResultTextAfterAlert(), "Expected text for third alert with accept button is wrong.");

            alerts.SwitchToThirdAlertForDismiss();
            Assert.AreEqual(expectedThirdDismissAlertMessage, alerts.GetResultTextAfterAlert(), "Expected text for third alert with dismiss button is wrong.");

            alerts.SwitchToThirdAlertForSendText();
            Assert.AreEqual(expectedThirdSendTextAlertMessage, alerts.GetResultTextAfterAlert(), "Expected text for third alert with send keys button is wrong.");

        }
    }
}
