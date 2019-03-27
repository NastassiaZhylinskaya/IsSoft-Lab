using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FinalTaskGM.Tests
{
    public class BaseTest
    {
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
