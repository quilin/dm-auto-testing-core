using Autofac;
using Core.Browsers;
using Core.Browsers.Pool;
using Core.Configuration;
using Microsoft.Extensions.Options;
using Xunit;

namespace Core.Testing.Unit
{
    public class ContainerConfigurationTests
    {
        [Fact]
        public void TestCreateContainer()
        {
            var container = ContainerConfiguration.CreateContainer();
            var browserPool = container.Resolve<IBrowserPool>();
            browserPool.Get(BrowserType.Webkit);
            Assert.True(true);
        }

        [Fact]
        public void TestRegisterOptions()
        {
            var container = ContainerConfiguration.CreateContainer();
            var generalSettings = container.Resolve<IOptions<GeneralSettings>>().Value;

            Assert.Equal(1, generalSettings.MaximumDegreeOfParallelism);
            Assert.Equal("../../../screenshots", generalSettings.ScreenshotDir);
            Assert.Equal("https://yandex.ru", generalSettings.BaseUrl);
        }
    }
}