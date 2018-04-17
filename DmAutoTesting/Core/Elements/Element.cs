using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.Elements
{
    public class Element : IElement
    {
        protected readonly IWebElement WebElement;
        private readonly IWebDriver webDriver;

        public Element(IWebElement element, IWebDriver webDriver)
        {
            WebElement = element;
            this.webDriver = webDriver;
        }

        public bool Exists => true;
        public string TagName => WebElement.TagName;
        public bool Visible => WebElement.Displayed;
        public int Height => WebElement.Size.Height;
        public int Width => WebElement.Size.Width;
        public string Text => WebElement.Text;

        public void Click()
        {
            WebElement.Click();
        }

        public void ScrollTo()
        {
            var scrollPosition = WebElement.Location.Y + WebElement.Size.Height / 2 -
                                 webDriver.Manage().Window.Size.Height / 2;
            ((IJavaScriptExecutor) webDriver).ExecuteScript($"window.scrollTo(0,{scrollPosition});");
        }

        public void HoverMouse()
        {
            var actions = new Actions(webDriver);
            actions.MoveToElement(WebElement).Perform();
        }

        public void HoverClick()
        {
            HoverMouse();
            Click();
        }

        public string GetAttribute(string name)
        {
            return WebElement.GetAttribute(name);
        }

        public bool HasAttribute(string name)
        {
            return !string.IsNullOrEmpty(GetAttribute(name));
        }
    }
}