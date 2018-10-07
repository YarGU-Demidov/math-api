using System;
using MathSite.Api.Core;
using MathSite.Common.ApiServiceRequester;
using MathSite.Common.ApiServiceRequester.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MathSite.Api.Services.Infrastructure
{
    public static class MathApiRegisterExtension
    {
        public static IServiceCollection AddMathApi<TDomainServiceUriBuilder>(
            this IServiceCollection services,
            IConfiguration authConfigurationSource
        ) where TDomainServiceUriBuilder : class, IServiceUriBuilder
        {
            return services.AddApiRequester<TDomainServiceUriBuilder>(authConfigurationSource, new Version(1, 0))
                .AddServices()
                .AddSingleton<MathServices>();
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ApiService, UsersService>();
            services.AddSingleton<ApiService, SiteSettingsService>();
            services.AddSingleton<ApiService, PersonsService>();
            services.AddSingleton<ApiService, ProfessorsService>();
            services.AddSingleton<ApiService, PostTypesService>();
            services.AddSingleton<ApiService, PostSeoSettingsService>();
            services.AddSingleton<ApiService, PostSettingsService>();
            services.AddSingleton<ApiService, PostsService>();
            services.AddSingleton<ApiService, GroupsService>();
            services.AddSingleton<ApiService, DirectoriesService>();
            services.AddSingleton<ApiService, FilesService>();
            services.AddSingleton<ApiService, CategoriesService>();

            return services;
        }
    }
}