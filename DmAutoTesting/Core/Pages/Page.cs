using Core.Browsers;
using Core.Elements.Searchers;
using OpenQA.Selenium;

namespace Core.Pages
{
    public abstract class Page : IPage
    {
        private ElementSearcher elementSearcher;
        protected IWebDriver WebDriver { get; private set; }
        protected IBrowser Browser { get; private set; }

        public void Initialize(IWebDriver webDriver, IBrowser browser)
        {
            WebDriver = webDriver;
            Browser = browser;
            elementSearcher = new ElementSearcher(webDriver, this, webDriver);
        }

        public IElementGetter Get => elementSearcher;
        public IElementFinder Find => elementSearcher;

        public abstract string Uri { get; }
        public string Url => WebDriver.Url;
        public abstract bool IsError { get; }

        public bool IsLoaded =>
            ((IJavaScriptExecutor) WebDriver).ExecuteScript("return document.readyState;").Equals("complete");
    }
}