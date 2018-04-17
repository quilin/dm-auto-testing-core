using System;
using Core.Browsers;

namespace Core.Exceptions
{
    public class WebDriverFactoryException : Exception
    {
        public WebDriverFactoryException(BrowserType browserType)
            : base($"No factory found for browser type {browserType}")
        {
        }
    }
}