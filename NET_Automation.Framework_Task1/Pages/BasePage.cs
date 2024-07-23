using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace NetAutomation_WebDriverTask3
{
    public class BasePage(IWebDriver driver, string url)
    {
        protected readonly IWebDriver driver = driver;
        protected readonly string url = url;

        public void NavigateToPage()
        {
            if(url.Length > 0)
                driver.Navigate().GoToUrl(url);
        }

        public void ScrollDown(int byAmount = -1)
        {
            var windowSize = driver.Manage().Window.Size;

            new Actions(driver)
                .ScrollByAmount(0, (byAmount == -1) ? windowSize.Height : byAmount)
                .Perform();
        }

        protected IWebElement FindDisplayedElement(By locator, int milliSecondsToWait = 2000)
        {
            IWebElement? foundElement = null;
            Exception lastException = new();

            return new WebDriverWait(driver, TimeSpan.FromMilliseconds(milliSecondsToWait)).Until
            (
                driver => 
                { 
                    try
                    {
                        if(driver.FindElement(locator) is var elem && elem.Displayed)
                        {
                            foundElement = elem;
                            return true;
                        }
                        return false;
                    }
                    catch (Exception ex)
                    {
                        lastException = ex;
                        return false;
                    }
                }
            ) ? foundElement! : throw lastException;
        }

        protected bool SwitchToNextTab()
        {
            var windowHandles = new List<string>(driver.WindowHandles);
            if(windowHandles.Count <= 1)
                return false;

            driver.SwitchTo().Window(windowHandles[1]);
            return true;
        }
    }
}