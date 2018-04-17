using Core.Browsers;
using Core.Elements.Searchers;
using OpenQA.Selenium;

namespace Core.Elements
{
    public class Component : Element, IComponent
    {
        private readonly IBrowser browser;
        private readonly ElementSearcher elementSearcher;

        public Component(IWebElement element, IWebDriver webDriver, IBrowser browser) : base(element, webDriver)
        {
            this.browser = browser;
            elementSearcher = new ElementSearcher(element, this, webDriver);
        }

        public IElementGetter Get => elementSearcher;
        public IElementFinder Find => elementSearcher;
    }
}