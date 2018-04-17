using System;
using Core.Pages;

namespace Core.Exceptions
{
    public class PageLoadException<TPage> : Exception
        where TPage : IPage
    {
        public PageLoadException(TPage page) : base($"Unable to load page {typeof(TPage).Name} at url {page.Url}")
        {
        }
    }
}