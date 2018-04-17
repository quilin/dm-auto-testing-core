using System;
using Core.Elements.Searchers;
using OpenQA.Selenium;

namespace Core.Exceptions
{
    public class ElementNotFoundException : Exception
    {
        private readonly By searchCriteria;
        private readonly ISearchable searchable;

        public ElementNotFoundException(By searchCriteria, ISearchable searchable)
            : base($"Could not find element by {searchCriteria} in {searchable.GetType().Name}")
        {
            this.searchCriteria = searchCriteria;
            this.searchable = searchable;
        }

        private ElementNotFoundException(By searchCriteria, ISearchable searchable, string message)
            : base($"Could not find element by {searchCriteria} in {searchable.GetType().Name}, but tried to {message}")
        {
        }

        public ElementNotFoundException Append(string message)
        {
            return new ElementNotFoundException(searchCriteria, searchable, message);
        }
    }
}