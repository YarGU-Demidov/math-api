using System;
using System.Threading.Tasks;
using MathSite.Api.Core;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Services
{
    public class AuthService : ApiService
    {
        public AuthService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        protected override string ServiceName { get; } = ServiceNames.Auth;

        public async Task<Guid> GetCurrentUserIdAsync()
        {
            return await GetRequestAsync<Guid>(MethodNames.Auth.GetCurrentUserId);
        }
    }
}