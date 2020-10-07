using System.Linq;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Charity.Application.AdminModule;
using Charity.Application.AdminModule.Mappings;
using Charity.Application.Behaviors;
using Charity.Application.FileModule;
using Charity.Application.PostModule;
using Charity.Application.ProjectModule;

namespace Charity.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddProjectModule();
            services.AddPhilanthropistModule();
            services.AddFileModule();
            services.AddPostModule();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
