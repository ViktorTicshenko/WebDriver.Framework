using OpenQA.Selenium;
using NetAutomation_WebDriverTask3_Models;

namespace NetAutomation_WebDriverTask3
{
    public class EstimateSummaryPage
    (
        MachineTypeType machineTypeType,
        OperatingSystemType osType, 
        GPUType gpuType, 
        LocationType locationType, 
        SSDType ssdType, 
        CommitedUsageType commitedUsageType, 
        bool addGPUs,
        string numOfGPUs,
        string numOfInstances,
        IWebDriver driver, 
        string url = ""
    ) : BasePage(driver, url)
    {
        private readonly By machineTypeResultLocator = By.XPath("//span[text()='Machine type']");
        private readonly By gpuModelResultLocator = By.XPath("//span[text()='GPU Model']");
        private readonly By numOfGPUsResultLocator = By.XPath("//span[text()='Number of GPUs']");
        private readonly By localSSDsResultLocator = By.XPath("//span[text()='Local SSD']");
        private readonly By numOfInstancesResultLocator = By.XPath("//span[text()='Number of Instances']");
        private readonly By osTypeResultLocator = By.XPath("//span[text()='Operating System / Software']");
        private readonly By provisioningModelResultLocator = By.XPath("//span[text()='Provisioning Model']");
        private readonly By addGPUsResultLocator = By.XPath("//span[text()='Add GPUs']");
        private readonly By regionResultLocator = By.XPath("//span[text()='Region']");
        private readonly By commitedUseResultLocator = By.XPath("//span[text()='Committed use discount options']");
        private OperatingSystemType osType = osType;
        private GPUType gpuType = gpuType;
        private LocationType locationType = locationType; 
        private SSDType ssdType = ssdType;
        private CommitedUsageType commitedUsageType = commitedUsageType;
        private bool addGPUs = addGPUs;
        private string numOfGPUs = numOfGPUs;
        private string numOfInstances = numOfInstances;

        public void Verify()
        {
            SwitchToNextTab();

            if(FindDisplayedElement(machineTypeResultLocator, 5000) is var elem)
            {
                ScrollDown(200);

                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain(machineTypeType.Text));

                elem = driver.FindElement(gpuModelResultLocator);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain(gpuType.Text));

                elem = driver.FindElement(numOfGPUsResultLocator);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain(numOfGPUs));

                elem = driver.FindElement(numOfInstancesResultLocator);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain(numOfInstances));

                elem = driver.FindElement(localSSDsResultLocator);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain(ssdType.Text));

                elem = driver.FindElement(osTypeResultLocator);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain(osType.Text));

                elem = driver.FindElement(provisioningModelResultLocator);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain("Regular"));

                elem = driver.FindElement(addGPUsResultLocator);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain(addGPUs.ToString().ToLower()));

                elem = driver.FindElement(regionResultLocator);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain(locationType.Text));

                elem = driver.FindElement(commitedUseResultLocator);
                Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain(commitedUsageType.Text));

                // elem = driver.FindElement(regionResultLocator);
                // Assert.That(elem.FindElement(By.XPath("following-sibling::span")).Text, Does.Contain("Frankfurt (europe-west3)"));
            }
        }
    }
}