using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ninject.Modules;

namespace IHttpFactoryWithAspNetMVCNinject.Services
{
    public class DotNetCoreBridgeModule : NinjectModule
    {
        public override void Load()
        {
            var hostBuilder = new HostBuilder();
            hostBuilder.ConfigureServices(ConfigureServices);
            Bind<IHttpClientFactory>().ToConstant(hostBuilder.Build().Services.GetService<IHttpClientFactory>());
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
        }
    }
}
