using System.Reflection;
using System.Text.Json;

namespace NetAutomation_WebDriverTask3_TestData
{
    public enum ConfigType
    {
        DataSet0,
        DataSet1
    }
    public record Config
    (
        string NumOfInstances,
        string OperatingSystem,
        string MachineFamily,
        string MachineSeries,
        string MachineType,
        string GPUModel,
        string NumOfGPUs,
        string NumOfSSDs,
        string Location,
        string CommitedUsage,
        bool AddGPU
    );

    public class TestDataRepository
    {
        private static readonly Dictionary<string, string> ConversionDict = LoadConversionTable("conversion.json");

        public static string ConvertKey(string key)
        {
            string value = "";

            ConversionDict.TryGetValue(key, out value!);

            return value;
        }

        private static string LoadJson(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourcePath = assembly.GetManifestResourceNames().Single(str => str.EndsWith(name));

            using Stream stream = assembly.GetManifestResourceStream(resourcePath);
            using StreamReader reader = new(stream);

            return reader.ReadToEnd();
        }

        private static Dictionary<string, string> LoadConversionTable(string tableName)
        {
            return JsonSerializer.Deserialize<Dictionary<string, string>>(LoadJson(tableName));
        }

        public static Config LoadConfig(ConfigType configType)
        {
            return JsonSerializer.Deserialize<Config>(LoadJson((configType == ConfigType.DataSet0) ? "dev.json" : "test.json"));
        }
    }
}