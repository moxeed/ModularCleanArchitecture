using Charity.Application.AdminModule.Interfaces.Repositories;
using Charity.Application.FileModule.Interfaces.Repositories;
using Charity.Application.Interfaces;
using Charity.Application.Module.Interfaces;
using Charity.Application.PostModule.Interfaces.Repositories;
using Charity.Application.ProjectModule.Interfaces.Repositories;
using Charity.Infrastructure.Persistence.Contexts;
using Charity.Infrastructure.Persistence.Repositories;
using Charity.Infrastructure.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Charity.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("DefaultConnection"),
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IProjectRepositoryAsync, ProjectRepositoryAsync>();
            services.AddTransient<IPhilanthropistRepositoryAsync, PhilanthropistRepositoryAsync>();
            services.AddTransient<IUploadedFileRepositoryAsync, UploadedFileRepositoryAsync>();
            services.AddTransient<IPostRepository, PostRepositoryAsync>();
            #endregion

            services.AddScoped<IConstantService, ConstantService>();
        }
    }
}
