using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace TestWithFrames
{
    [TestFixture]
    public class TestForFrame
    {
        private ChromeDriver chromeDriver;
        private const string expectedFirstPartText = "Hello ";
        private const string expectedSecondPartText = "world!";

        [SetUp]
        public void SetUp()
        {
            chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            chromeDriver.Url = "https://the-internet.herokuapp.com/iframe";
        }

        [TearDown]
        public void TearDown()
        {
            chromeDriver.Quit();
        }

        [Test]
        public void FrameTest()
        {
            Frame frame = new Frame(chromeDriver);
            frame.ClearExistingText();
            frame.AddFirstPartTextInTextArea();
            Assert.AreEqual(expectedFirstPartText, frame.IsTextAreaGotAFirstPartText(), "Expected text is wrong.");

            frame.ClickBoldButton();

            frame.AddSecondPartTextInTextArea();
            Assert.AreEqual(expectedSecondPartText, frame.IsTextAreaGotASecondPartText(), "Expected text is wrong.");
        }
    }
}
