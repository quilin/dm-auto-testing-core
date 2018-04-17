using OpenQA.Selenium;

namespace Core.Elements.Factories
{
    public interface IElementFactory
    {
        IWebElement Element { get; }
        IWebDriver WebDriver { get; }

        IElement AsElement();
        TComponent AsComponent<TComponent>() where TComponent : class, IComponent;
    }
}