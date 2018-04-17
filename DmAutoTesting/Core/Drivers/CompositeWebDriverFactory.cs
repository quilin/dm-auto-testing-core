using Core.Browsers;
using Core.Exceptions;
using OpenQA.Selenium;

namespace Core.Drivers
{
    public class CompositeWebDriverFactory : ICompositeWebDriverFactory
    {
        private readonly IWebDriverFactory[] webDriverFactories;

        public CompositeWebDriverFactory(
            IWebDriverFactory[] webDriverFactories
        )
        {
            this.webDriverFactories = webDriverFactories;
        }

        public IWebDriver Create(BrowserType browserType)
        {
            foreach (var webDriverFactory in webDriverFactories)
            {
                if (webDriverFactory.CanCreate(browserType))
                {
                    return webDriverFactory.Create(browserType);
                }
            }

            throw new WebDriverFactoryException(browserType);
        }
    }
}