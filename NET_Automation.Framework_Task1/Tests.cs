using NUnit.Framework.Interfaces;

namespace NetAutomation_WebDriverTask3;

using NetAutomation_WebDriverTask3_Utilities;

using BrowserType = DriverFactory.BrowserType;

[Parallelizable(scope: ParallelScope.Fixtures)]
[TestFixture("Chrome")]
[TestFixture("Firefox")]
[TestFixture("Edge")]
public class CreatePasteTest(string browserTypeString)
{
    private HomePage? homePage;
    private AddToEstimatePage? addToEstimatePage;
    private ComputeEnginePage? computeEnginePage;
    private ShareEstimatePage? shareEstimatePage;
    private EstimateSummaryPage? estimateSummaryPage;
    private readonly string browserTypeString = browserTypeString;
    private BrowserType browserType;

    [SetUp]
    public void SetUp()
    {
        if (Enum.TryParse<BrowserType>(browserTypeString, true, out browserType))
        {
            var driver = DriverFactory.GetDriver(browserType);
            var config = Environment.Config;

            homePage = new HomePage(driver, "https://cloud.google.com/products/calculator");

            addToEstimatePage = new AddToEstimatePage(driver);

            computeEnginePage = new ComputeEnginePage
            (
                machineFamilyType : Environment.MachineFamilyType,
                machineTypeType   : Environment.MachineTypeType,
                machineSeriesType : Environment.MachineSeriesType,
                osType            : Environment.OSType,
                gpuType           : Environment.GPUType,
                locationType      : Environment.LocationType,
                ssdType           : Environment.SSDType,
                commitedUsageType : Environment.CommitedUsageType,
                addGPUs           : config.AddGPU,
                numOfInstances    : config.NumOfInstances,
                numOfGPUs         : config.NumOfGPUs,
                driver            : driver
            );

            shareEstimatePage = new ShareEstimatePage(driver);

            estimateSummaryPage = new EstimateSummaryPage
            (
                machineTypeType   : Environment.MachineTypeType,
                osType            : Environment.OSType,
                gpuType           : Environment.GPUType,
                locationType      : Environment.LocationType,
                ssdType           : Environment.SSDType,
                commitedUsageType : Environment.CommitedUsageType,
                addGPUs           : config.AddGPU,
                numOfInstances    : config.NumOfInstances,
                numOfGPUs         : config.NumOfGPUs,
                driver            : driver
            );

            homePage!.NavigateToPage();
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(browserTypeString), browserTypeString, null);
        }
    }

    [Test]
    public void PopulateCalculator()
    {
        homePage!.ClickAddToEstimateBtn();

        addToEstimatePage!.SelectComputeEngine();

        computeEnginePage!.SelectNumOfInstances();
        computeEnginePage.SelectOperatingSystem();
        computeEnginePage.ScrollDown(600);

        computeEnginePage.SelectProvisioning();
        computeEnginePage.ScrollDown(100);

        computeEnginePage.SelectMachineSeries();
        computeEnginePage.SelectMachineFamily();
        computeEnginePage.SelectMachineType();
        computeEnginePage.ScrollDown(700);

        computeEnginePage.AddGPUs();
        computeEnginePage.ScrollDown(100);

        computeEnginePage.SetGPUModel();
        computeEnginePage.SetNumOfGPUs();
        computeEnginePage.SetTypeOfSSD();
        computeEnginePage.ScrollDown(200);

        computeEnginePage.SelectCommitedUsage();
        computeEnginePage.SetLocation();

        shareEstimatePage!.ShareEstimate();
        shareEstimatePage.OpenEstimate();

        estimateSummaryPage!.Verify();
    }

    [TearDown]
    public void TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            DriverFactory.GetDriver(browserType).TakeScreenshot(TestContext.CurrentContext.Test.Name);
        }

        DriverFactory.CloseDriver();
    }
}