using System.Threading.Tasks;
using MathSite.Api.Core;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class SiteSettingsService : BaseApiService
    {
        public SiteSettingsService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        protected override string ServiceName { get; } = ServiceNames.SiteSettings;

        public async Task<int> GetPerPageCountAsync(int count = 18)
        {
            var args = new MethodArgs
            {
                {nameof(count), count.ToString()}
            };

            return await GetRequestAsync<int>(MethodNames.SiteSettings.GetPerPageCount, args);
        }

        public async Task<string> GetTitleDelimiterAsync()
        {
            return await GetRequestAsync<string>(MethodNames.SiteSettings.GetTitleDelimiter);
        }

        public async Task<string> GetDefaultHomePageTitleAsync()
        {
            return await GetRequestAsync<string>(MethodNames.SiteSettings.GetDefaultHomePageTitle);
        }

        public async Task<string> GetDefaultNewsPageTitleAsync()
        {
            return await GetRequestAsync<string>(MethodNames.SiteSettings.GetDefaultNewsPageTitle);
        }

        public async Task<string> GetSiteNameAsync()
        {
            return await GetRequestAsync<string>(MethodNames.SiteSettings.GetSiteName);
        }

        public async Task<bool> SetPerPageCountAsync(string count)
        {
            var args = new MethodArgs
            {
                {nameof(count), count}
            };

            return await PostRequestAsync<bool>(MethodNames.SiteSettings.SetPerPageCount, args);
        }

        public async Task<bool> SetTitleDelimiter(string delimiter)
        {
            var args = new MethodArgs
            {
                {nameof(delimiter), delimiter}
            };

            return await PostRequestAsync<bool>(MethodNames.SiteSettings.SetTitleDelimiter, args);
        }

        public async Task<bool> SetDefaultHomePageTitle(string title)
        {
            var args = new MethodArgs
            {
                {nameof(title), title}
            };

            return await PostRequestAsync<bool>(MethodNames.SiteSettings.SetDefaultHomePageTitle, args);
        }

        public async Task<bool> SetDefaultNewsPageTitle(string title)
        {
            var args = new MethodArgs
            {
                {nameof(title), title}
            };

            return await PostRequestAsync<bool>(MethodNames.SiteSettings.SetDefaultNewsPageTitle, args);
        }

        public async Task<bool> SetSiteName(string siteName)
        {
            var args = new MethodArgs
            {
                {nameof(siteName), siteName}
            };

            return await PostRequestAsync<bool>(MethodNames.SiteSettings.SetSiteName, args);
        }
    }
}