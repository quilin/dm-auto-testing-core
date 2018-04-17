using Core.Elements.Factories;
using Core.Exceptions;
using OpenQA.Selenium;

namespace Core.Elements.Searchers
{
    public class ElementSearcher : IElementFinder, IElementGetter
    {
        private readonly ISearchContext searchContext;
        private readonly ISearchable searchable;
        private readonly IWebDriver webDriver;

        public ElementSearcher(
            ISearchContext searchContext,
            ISearchable searchable,
            IWebDriver webDriver
        )
        {
            this.searchContext = searchContext;
            this.searchable = searchable;
            this.webDriver = webDriver;
        }

        private IElementFactory GetElement(By searchCriteria)
        {
            var element = searchContext.FindElement(searchCriteria);
            return element == null
                ? throw new ElementNotFoundException(searchCriteria, searchable)
                : new ElementFactory(element, webDriver, searchable);
        }

        private IElementFactory FindElement(By searchCriteria)
        {
            var element = searchContext.FindElement(searchCriteria);
            return element == null
                ? new ElementFactory(searchCriteria, searchable)
                : new ElementFactory(element, webDriver, searchable);
        }


        IElementFactory IElementGetter.ById(string id) => GetElement(By.Id(id));

        IElementFactory IElementGetter.ByName(string name) => GetElement(By.Name(name));

        IElementFactory IElementGetter.ByCss(string css) => GetElement(By.CssSelector(css));

        IElementFactory IElementGetter.ByXPath(string xpath) => GetElement(By.XPath(xpath));

        IElementFactory IElementGetter.ByContent(string content) =>
            GetElement(By.XPath($"//*[normalize-space(.)='{content}' or @value='{content}']"));

        IElementFactory IElementFinder.ById(string id) => FindElement(By.Id(id));

        IElementFactory IElementFinder.ByName(string name) => FindElement(By.Name(name));

        IElementFactory IElementFinder.ByCss(string css) => FindElement(By.CssSelector(css));

        IElementFactory IElementFinder.ByXPath(string xpath) => FindElement(By.XPath(xpath));
    }
}