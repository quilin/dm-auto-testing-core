using Core.Elements.Searchers;
using OpenQA.Selenium;

namespace Core.Elements
{
    public class Component : Element, IComponent
    {
        private readonly ElementSearcher elementSearcher;

        public Component(IWebElement element, IWebDriver webDriver) : base(element, webDriver)
        {
            elementSearcher = new ElementSearcher(element, this, webDriver);
        }

        public IElementGetter Get => elementSearcher;
        public IElementFinder Find => elementSearcher;
    }
}