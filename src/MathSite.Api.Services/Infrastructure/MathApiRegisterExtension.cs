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
            IConfiguration authConfigconfigurationSource
        ) where TDomainServiceUriBuilder : class, IServiceUriBuilder
        {
            return services.AddApiRequester<TDomainServiceUriBuilder>(authConfigconfigurationSource, new Version(1, 0))
                .AddServices()
                .AddSingleton<MathServices>();
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<BaseApiService, UsersService>();
            services.AddSingleton<BaseApiService, SiteSettingsService>();
            services.AddSingleton<BaseApiService, PersonsService>();
            services.AddSingleton<BaseApiService, ProfessorsService>();
            services.AddSingleton<BaseApiService, PostTypesService>();
            services.AddSingleton<BaseApiService, PostSeoSettingsService>();
            services.AddSingleton<BaseApiService, PostSettingsService>();
            services.AddSingleton<BaseApiService, PostsService>();
            services.AddSingleton<BaseApiService, GroupsService>();
            services.AddSingleton<BaseApiService, DirectoriesService>();
            services.AddSingleton<BaseApiService, FilesService>();
            services.AddSingleton<BaseApiService, CategoriesService>();

            return services;
        }
    }
}