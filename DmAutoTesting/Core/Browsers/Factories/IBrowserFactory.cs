namespace Core.Browsers.Factories
{
    public interface IBrowserFactory
    {
        IBrowser Create(BrowserType browserType);
    }
}