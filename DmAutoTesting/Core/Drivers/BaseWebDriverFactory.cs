using Core.Browsers;
using OpenQA.Selenium;

namespace Core.Drivers
{
    public abstract class BaseWebDriverFactory : IWebDriverFactory
    {
        public bool CanCreate(BrowserType browserType) => browserType == BrowserType;

        protected abstract BrowserType BrowserType { get; }

        public abstract IWebDriver Create(BrowserType browserType);
    }
}