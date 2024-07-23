using OpenQA.Selenium;

namespace NetAutomation_WebDriverTask3
{
    public class AddToEstimatePage : BasePage
    {
        private readonly By computeEngineBtnLocator = By.XPath("//h2[text()='Compute Engine']");

        public AddToEstimatePage(IWebDriver driver, string url = "") : base(driver, url)
        {
            //
        }

        public void SelectComputeEngine()
        {
            FindDisplayedElement(computeEngineBtnLocator).Click();
        }
    }
}