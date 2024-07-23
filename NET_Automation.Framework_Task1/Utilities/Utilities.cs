using OpenQA.Selenium;

namespace NetAutomation_WebDriverTask3_Utilities
{
    public static class WebDriverExtensions
    {
        static public void TakeScreenshot(this IWebDriver driver, string testName)
        {
            var screenshotDriver = driver as ITakesScreenshot ?? throw new InvalidOperationException("The driver does not support taking screenshots");
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            string screenshotDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Selenium_Screenshots");
            Directory.CreateDirectory(screenshotDirectory);
            
            string screenshotPath = Path.Combine(screenshotDirectory, $"{string.Join("_", testName.Split(Path.GetInvalidFileNameChars()))}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png");
            screenshot.SaveAsFile(screenshotPath);

            //TestContext.Out.WriteLine($"Saved screenshot to {screenshotPath}");
        }
    }
}