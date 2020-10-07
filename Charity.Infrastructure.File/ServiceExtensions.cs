using Charity.Application.FileModule.Interfaces;
using Charity.Domain.Settings;
using Charity.Infrastructure.File.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Charity.Infrastructure.File
{
    public static class ServiceExtensions
    {
        public static void AddFileInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUploadService, UploadService>();
            services.Configure<UploadSettings>(configuration.GetSection(nameof(UploadSettings)));
        }
    }
}
