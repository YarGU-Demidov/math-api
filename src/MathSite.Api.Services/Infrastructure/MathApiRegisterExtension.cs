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
            services.AddTransient<ApiService, UsersService>();
            services.AddTransient<ApiService, SiteSettingsService>();
            services.AddTransient<ApiService, PersonsService>();
            services.AddTransient<ApiService, ProfessorsService>();
            services.AddTransient<ApiService, PostTypesService>();
            services.AddTransient<ApiService, PostSeoSettingsService>();
            services.AddTransient<ApiService, PostSettingsService>();
            services.AddTransient<ApiService, PostsService>();
            services.AddTransient<ApiService, GroupsService>();
            services.AddTransient<ApiService, DirectoriesService>();
            services.AddTransient<ApiService, FilesService>();
            services.AddTransient<ApiService, CategoriesService>();
            services.AddTransient<ApiService, AuthService>();

            return services;
        }
    }
}