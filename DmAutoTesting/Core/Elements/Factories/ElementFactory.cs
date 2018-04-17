using System;
using Core.Elements.Searchers;
using OpenQA.Selenium;

namespace Core.Elements.Factories
{
    public class ElementFactory : IElementFactory
    {
        private readonly By searchCriteria;
        private readonly ISearchable searchable;

        public ElementFactory(IWebElement element, IWebDriver webDriver, ISearchable searchable)
        {
            this.searchable = searchable;
            Element = element;
            WebDriver = webDriver;
        }

        public ElementFactory(By searchCriteria, ISearchable searchable)
        {
            this.searchCriteria = searchCriteria;
            this.searchable = searchable;
        }

        public IWebElement Element { get; }
        public IWebDriver WebDriver { get; }

        public IElement AsElement()
        {
            return Element == null
                ? (IElement) new EmptyElement(searchCriteria, searchable)
                : (IElement) new Element(Element, WebDriver);
        }

        public TComponent AsComponent<TComponent>() where TComponent : class, IComponent =>
            (TComponent) Activator.CreateInstance(typeof(TComponent), Element, WebDriver);
    }
}