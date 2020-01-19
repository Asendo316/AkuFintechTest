using AcuTestAPI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AcuTestRestAPI.Services.Interfaces.v1.user.profile;
using AcuTestRestAPI.Services.Interfaces.v1.user.file;

namespace AcuTestRestAPI.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IUserProfileService, UserProfileService>();

            services.AddScoped<ICompareFilesService, CompareFilesService>();

        }
    }
}
