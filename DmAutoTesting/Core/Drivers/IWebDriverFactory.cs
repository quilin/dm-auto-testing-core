using Core.Browsers;
using OpenQA.Selenium;

namespace Core.Drivers
{
    public interface IWebDriverFactory
    {
        bool CanCreate(BrowserType browserType);
        IWebDriver Create(BrowserType browserType);
    }
}