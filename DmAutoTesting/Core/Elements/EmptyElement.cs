using Core.Elements.Searchers;
using Core.Exceptions;
using OpenQA.Selenium;

namespace Core.Elements
{
    public class EmptyElement : IElement
    {
        private readonly ElementNotFoundException exception;

        public EmptyElement(By searchCriteria, ISearchable searchable)
        {
            exception = new ElementNotFoundException(searchCriteria, searchable);
        }

        public bool Exists => false;
        public string TagName => throw exception.Append("get tag name.");
        public bool Visible => throw exception.Append("know if element is visible.");
        public int Height => throw exception.Append("get element height.");
        public int Width => throw exception.Append("get element width.");
        public string Text => throw exception.Append("get element inner text.");

        public void Click()
        {
            throw exception.Append("click element");
        }

        public void ScrollTo()
        {
            throw exception.Append("scroll to element");
        }

        public void HoverMouse()
        {
            throw exception.Append("move mouse over element");
        }

        public void HoverClick()
        {
            throw exception.Append("move mouse over element and click");
        }

        public string GetAttribute(string name)
        {
            throw exception.Append($"get element {name} attribute value");
        }

        public bool HasAttribute(string name)
        {
            throw exception.Append($"know if element has {name} attribute");
        }
    }
}