using OpenQA.Selenium;
using NetAutomation_WebDriverTask3_Models;

namespace NetAutomation_WebDriverTask3
{
    public class ComputeEnginePage
    (
        MachineFamilyType machineFamilyType,
        MachineTypeType machineTypeType,
        MachineSeriesType machineSeriesType,
        OperatingSystemType osType, 
        GPUType gpuType, 
        LocationType locationType, 
        SSDType ssdType, 
        CommitedUsageType commitedUsageType, 
        bool addGPUs,
        string numOfInstances,
        string numOfGPUs,
        IWebDriver driver, 
        string url = ""
    ) : BasePage(driver, url)
    {
        private readonly By numOfInstancesLocator = By.XPath("//div[contains(text(),'Number of instances')]/../..//input[@type='number' and @min and @max]");
        private readonly By operatingSystemLocator = By.XPath("//span[text()='Operating System / Software']/ancestor::*[@role='combobox']");
        private readonly By operatingSystemChoiceLocator = By.XPath($"//ul[@aria-label='Operating System / Software']//li[@data-value = '{osType.Key}']");
        private readonly By provisioningModelSelector = By.XPath("//label[text()='Regular']/preceding-sibling::input[@type='radio']/parent::div");
        private readonly By commitedUsageSelector = By.XPath($"//label[text()='{commitedUsageType.Key}']/preceding-sibling::input[@type='radio']/parent::div");
        private readonly By machineFamilyLocator = By.XPath("//span[text()='Machine Family']/ancestor::*[@role='combobox']");
        private readonly By machineFamilyChoiceLocator = By.XPath($"//ul[@aria-label='Machine Family']//li[@data-value = '{machineFamilyType.Key}']");
        private readonly By machineSeriesLocator = By.XPath("//span[text()='Series']/ancestor::*[@role='combobox']");
        private readonly By machineSeriesChoiceLocator = By.XPath($"//ul[@aria-label='Series']//li[@data-value = '{machineSeriesType.Key}']");
        private readonly By machineTypeLocator = By.XPath("//span[text()='Machine type']/ancestor::*[@role='combobox']");
        private readonly By machineTypeChoiceLocator = By.XPath($"//ul[@aria-label='Machine type']//li[@data-value = '{machineTypeType.Key}']");
        private readonly By addGPUsLocator = By.XPath("//div[text()='Add GPUs']/../..//button[@type='button' and @role='switch']");
        private readonly By gpuModelLocator = By.XPath("//span[text()='GPU Model']/ancestor::*[@role='combobox']");
        private readonly By gpuModelChoiceLocator = By.XPath($"//ul[@aria-label='GPU Model']//li[@data-value = '{gpuType.Key}']");
        private readonly By numberOfGPUsLocator = By.XPath("//span[text()='Number of GPUs']/ancestor::*[@role='combobox']");
        private readonly By numberOfGPUsChoiceLocator = By.XPath($"//ul[@aria-label='Number of GPUs']//li[@data-value = '{numOfGPUs}']");
        private readonly By localSSDTypeLocator = By.XPath("//span[text()='Local SSD']/ancestor::*[@role='combobox']");
        private readonly By localSSDTypeChoiceLocator = By.XPath($"//ul[@aria-label='Local SSD']//li[@data-value = '{ssdType.Key}']");
        private readonly By regionTypeLocator = By.XPath("//span[text()='Region']/ancestor::*[@role='combobox']");
        private readonly By regionTypeChoiceLocator = By.XPath($"//ul[@aria-label='Region' and @role='listbox']//li[@data-value = '{locationType.Key}']");
        private readonly bool addGPUs = addGPUs;
        private readonly string numOfInstances = numOfInstances;

        // public ComputeEnginePage(OperatingSystemType osType, GPUType gpuType, LocationType locationType, SSDType ssdType, IWebDriver driver, string url = "") : base(driver, url)
        // {
        //     //
        // }
        
        public void SelectNumOfInstances()
        {
            if(FindDisplayedElement(numOfInstancesLocator) is var elem)
            {
                elem.Clear();
                elem.SendKeys(numOfInstances);
            }
        }
        
        public void SelectOperatingSystem()
        {
            if(FindDisplayedElement(operatingSystemLocator) is var elem)
            {
                elem.Click();

                var selectedElem = elem.FindElement(operatingSystemChoiceLocator);
                selectedElem.Click();
            }
        }

        public void SelectProvisioning()
        {
            FindDisplayedElement(provisioningModelSelector).Click();
        }

        public void SelectCommitedUsage()
        {
            FindDisplayedElement(commitedUsageSelector).Click();
        }

        public void SelectMachineFamily()
        {
            if(FindDisplayedElement(machineFamilyLocator) is var elem)
            {
                elem.Click();

                var selectedElem = elem.FindElement(machineFamilyChoiceLocator);
                selectedElem.Click();
            }
        }

        public void SelectMachineSeries()
        {
            if(FindDisplayedElement(machineSeriesLocator) is var elem)
            {
                elem.Click();

                var selectedElem = elem.FindElement(machineSeriesChoiceLocator);
                selectedElem.Click();
            }
        }

        public void SelectMachineType()
        {
            if(FindDisplayedElement(machineTypeLocator) is var elem)
            {
                elem.Click();

                var selectedElem = elem.FindElement(machineTypeChoiceLocator);
                selectedElem.Click();
            }
        }

        public void AddGPUs()
        {
            if(addGPUs)
                FindDisplayedElement(addGPUsLocator).Click();
        }

        public void SetGPUModel()
        {
            if(FindDisplayedElement(gpuModelLocator) is var elem)
            {
                elem.Click();

                var selectedElem = elem.FindElement(gpuModelChoiceLocator);
                selectedElem.Click();
            }
        }

        public void SetNumOfGPUs()
        {
            if(FindDisplayedElement(numberOfGPUsLocator) is var elem)
            {
                elem.Click();

                var selectedElem = elem.FindElement(numberOfGPUsChoiceLocator);
                selectedElem.Click();
            }
        }

        public void SetTypeOfSSD()
        {
            if(FindDisplayedElement(localSSDTypeLocator) is var elem)
            {
                elem.Click();

                var selectedElem = elem.FindElement(localSSDTypeChoiceLocator);
                selectedElem.Click();
            }
        }

        public void SetLocation()
        {
            if(FindDisplayedElement(regionTypeLocator) is var elem)
            {
                elem.Click();
                Thread.Sleep(250);

                var selectedElem = elem.FindElement(regionTypeChoiceLocator);
                selectedElem.Click();
                Thread.Sleep(250);
            }
        }
    }
}