using OpenQA.Selenium;

namespace Core.Elements.BaseElements
{
    public class TextInputElement : Element, ITextInputElement
    {
        public TextInputElement(IWebElement element, IWebDriver webDriver) : base(element, webDriver)
        {
        }

        public string Value
        {
            get => GetAttribute("value");
            set
            {
                Click();
                WebElement.SendKeys(value);
            }
        }
    }
}