using Core.Configuration;
using Core.Drivers;
using Microsoft.Extensions.Options;

namespace Core.Browsers.Factories
{
    public class BrowserFactory : IBrowserFactory
    {
        private readonly ICompositeWebDriverFactory webDriverFactory;
        private readonly GeneralSettings generalSettings;

        public BrowserFactory(
            ICompositeWebDriverFactory webDriverFactory,
            IOptions<GeneralSettings> generalOptions
        )
        {
            this.webDriverFactory = webDriverFactory;
            generalSettings = generalOptions.Value;
        }

        public IBrowser Create(BrowserType browserType) =>
            new Browser(webDriverFactory.Create(browserType), generalSettings.ScreenshotDir, generalSettings.BaseUrl);
    }
}