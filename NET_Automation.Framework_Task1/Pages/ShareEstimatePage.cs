using OpenQA.Selenium;

namespace NetAutomation_WebDriverTask3
{
    public class ShareEstimatePage : BasePage
    {
        private readonly By openShareBtnLocator = By.XPath("//span[text()='Share']/ancestor::button[@aria-label='Open Share Estimate dialog']");
        private readonly By openShareLink = By.XPath("//a[text()='Open estimate summary']");

        public ShareEstimatePage(IWebDriver driver, string url = "") : base(driver, url)
        {
            //
        }

        public void ShareEstimate()
        {
            FindDisplayedElement(openShareBtnLocator).Click();
        }

        public void OpenEstimate()
        {
            FindDisplayedElement(openShareLink).Click();
        }
    }
}