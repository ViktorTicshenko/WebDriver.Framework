namespace NetAutomation_WebDriverTask3;

using NetAutomation_WebDriverTask3_TestData;
using NetAutomation_WebDriverTask3_Models;

[SetUpFixture]
public class Environment
{
    public static Config Config
    {
        get;
        private set;
    }

    public static OperatingSystemType OSType
    {
        get;
        private set;
    }

    public static GPUType GPUType
    {
        get;
        private set;
    }

    public static LocationType LocationType
    {
        get;
        private set;
    }

    public static SSDType SSDType
    {
        get;
        private set;
    }
    
    public static CommitedUsageType CommitedUsageType
    {
        get;
        private set;
    }
    
    public static MachineFamilyType MachineFamilyType
    {
        get;
        private set;
    }
    
    public static MachineTypeType MachineTypeType
    {
        get;
        private set;
    }
    
    public static MachineSeriesType MachineSeriesType
    {
        get;
        private set;
    }

    [OneTimeSetUp]
    public void Setup()
    {
        Config = TestDataRepository.LoadConfig(ConfigType.DataSet0);

        OSType = new(Config.OperatingSystem, TestDataRepository.ConvertKey(Config.OperatingSystem));
        GPUType = new(Config.GPUModel, TestDataRepository.ConvertKey(Config.GPUModel));
        LocationType = new(Config.Location, TestDataRepository.ConvertKey(Config.Location));
        SSDType = new(Config.NumOfSSDs, TestDataRepository.ConvertKey(Config.NumOfSSDs));
        CommitedUsageType = new(Config.CommitedUsage, TestDataRepository.ConvertKey(Config.CommitedUsage));
        MachineFamilyType = new(Config.MachineFamily, TestDataRepository.ConvertKey(Config.MachineFamily));
        MachineTypeType = new(Config.MachineType, TestDataRepository.ConvertKey(Config.MachineType));
        MachineSeriesType = new(Config.MachineSeries, TestDataRepository.ConvertKey(Config.MachineSeries));
    }

    [OneTimeTearDown]
    public void Cleanup()
    {
    }
}