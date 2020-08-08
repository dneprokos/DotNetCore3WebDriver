using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;

namespace WebDriverWithCore3Tests.Common.Helpers
{
    public class ScreenShotManager
    {
        public static string MakeScreenShot(string fileBaseName) 
        {
            Screenshot screenshot = ((ITakesScreenshot)WebDriverFactory.CurrentDriver).GetScreenshot();
            string screenshotPath = CreateScreenShotDirectory(fileBaseName);
            string fullName = $"{fileBaseName}-{DateTime.Now:ddMMHm}.png"; //TODO:Need to build more buitifull name

            string fullFilePath = Path.Combine(screenshotPath, fullName);
            screenshot.SaveAsFile(fullFilePath, ScreenshotImageFormat.Png);

            return fullFilePath;
        }

        public static void MakeScreenOnTestFail() 
        { 
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success) 
            {
                string fileName = TestContext.CurrentContext.Test.Name;
                string screenshotPath = MakeScreenShot(fileName);
                TestContext.AddTestAttachment(screenshotPath);
            }
        }

        #region Private helpers

        private static string CreateScreenShotDirectory(string folderName) 
        {
            string directory = Path.GetDirectoryName(typeof(Screenshot).Assembly.Location);
            string path = Path.Combine(directory, "Artifacts/Screenshots", folderName);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        #endregion
    }
}
