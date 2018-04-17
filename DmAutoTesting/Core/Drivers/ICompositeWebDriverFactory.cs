using Core.Browsers;
using OpenQA.Selenium;

namespace Core.Drivers
{
    public interface ICompositeWebDriverFactory
    {
        IWebDriver Create(BrowserType browserType);
    }
}