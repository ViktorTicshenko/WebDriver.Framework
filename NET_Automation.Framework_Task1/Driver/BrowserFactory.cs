using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace NetAutomation_WebDriverTask3;

public class DriverFactory 
{
    public enum BrowserType
    {
        FIREFOX,
        CHROME,
        EDGE
    };

    private static readonly ThreadLocal<IWebDriver?> _driver = new();
    private DriverFactory(){}

    public static IWebDriver GetDriver(BrowserType browserType)
    {
        if (_driver.Value == null)
        {
            switch (browserType)
            {
                case BrowserType.CHROME: 
                {
                    var options = new ChromeOptions();
                    options.AddArgument("--start-maximized");

                    _driver.Value = new ChromeDriver(options);

                    break;
                }
                case BrowserType.EDGE: 
                {
                    var options = new EdgeOptions();
                    options.AddArgument("--start-maximized");

                    _driver.Value = new EdgeDriver(options);

                    break;
                }
                case BrowserType.FIREFOX: 
                {
                    _driver.Value = new FirefoxDriver();
                    _driver.Value.Manage().Window.Maximize();

                    break;
                }
                default: 
                {
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
                }
            }
        }

        return _driver.Value;
    }

    public static void CloseDriver()
    {
        _driver.Value?.Dispose();
        _driver.Value = null;
    }
}