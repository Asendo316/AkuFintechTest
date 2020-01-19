using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcuTestRestAPI.Installers
{
    interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
