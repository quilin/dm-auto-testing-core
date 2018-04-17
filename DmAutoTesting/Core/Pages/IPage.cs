using Core.Browsers;
using Core.Elements.Searchers;
using OpenQA.Selenium;

namespace Core.Pages
{
    public interface IPage : ISearchable
    {
        string Uri { get; } // constant page-dependent identifier
        string Url { get; } // current page url that may depend on query parameters
        bool IsError { get; }
        bool IsLoaded { get; }

        void Initialize(IWebDriver webDriver, IBrowser browser);
    }
}