namespace Core.Browsers.Pool
{
    public interface IBrowserPool
    {
        IBrowser Get(BrowserType browserType);
        void Release(IBrowser browser);
        void RemoveFromPool(IBrowser browser);
    }
}