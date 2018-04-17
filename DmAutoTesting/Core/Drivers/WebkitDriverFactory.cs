using Core.Browsers;
using Core.Configuration;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core.Drivers
{
    public class WebkitDriverFactory : BaseWebDriverFactory
    {
        private readonly DriverSettings driverSettings;

        public WebkitDriverFactory(
            IOptions<DriverSettings> driverBinaryPathsOptions
        )
        {
            driverSettings = driverBinaryPathsOptions.Value;
        }

        protected override BrowserType BrowserType => BrowserType.Webkit;

        public override IWebDriver Create(BrowserType browserType) =>
            new ChromeDriver(ChromeDriverService.CreateDefaultService(driverSettings.ChromeBinaryPath));
    }
}