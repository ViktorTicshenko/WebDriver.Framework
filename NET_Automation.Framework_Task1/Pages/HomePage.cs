using OpenQA.Selenium;

namespace NetAutomation_WebDriverTask3
{
    public class HomePage : BasePage
    {
        private readonly By addToEstimateBtnLocator = By.XPath("//span[text()='Add to estimate']");
        public HomePage(IWebDriver driver, string url = "") : base(driver, url)
        {
            //
        }

        public void ClickAddToEstimateBtn()
        {
            driver.FindElement(addToEstimateBtnLocator).Click();
        }
    }
}