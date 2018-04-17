using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Core.Browsers.Factories;
using Core.Configuration;
using Microsoft.Extensions.Options;

namespace Core.Browsers.Pool
{
    public class BrowserPool : IBrowserPool
    {
        private readonly IBrowserFactory browserFactory;
        private readonly List<IBrowser> browsers;
        private readonly Semaphore semaphore;
        private readonly int degreeOfParallelism;

        public BrowserPool(
            IBrowserFactory browserFactory,
            IOptions<GeneralSettings> generalOptions
        )
        {
            this.browserFactory = browserFactory;
            degreeOfParallelism = generalOptions.Value.MaximumDegreeOfParallelism;
            browsers = new List<IBrowser>(degreeOfParallelism);
            semaphore = new Semaphore(degreeOfParallelism, degreeOfParallelism);
        }

        public IBrowser Get(BrowserType browserType)
        {
            semaphore.WaitOne();
            try
            {
                lock (browsers)
                {
                    var browser = browsers.FirstOrDefault() ?? browserFactory.Create(browserType);
                    browsers.Remove(browser);
                    return browser;
                }
            }
            catch (Exception)
            {
                semaphore.Release();
                throw;
            }
        }

        public void Release(IBrowser browser)
        {
            lock (browsers)
            {
                browsers.Add(browser);

                var freeBrowsersCount = semaphore.Release() + 1;
                if (freeBrowsersCount < degreeOfParallelism) return;

                browsers.ForEach(b => b.Dispose());
                browsers.Clear();
            }
        }

        public void RemoveFromPool(IBrowser browser)
        {
            semaphore.Release();
        }
    }
}