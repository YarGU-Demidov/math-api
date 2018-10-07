using System;
using System.Threading.Tasks;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Core
{
    public abstract class CountableBaseApiService : CountableBaseApiService<Guid>
    {
        protected CountableBaseApiService(IApiRequester apiRequester) : base(apiRequester)
        {
        }
    }

    public abstract class CountableBaseApiService<TPrimaryKey> : BaseApiService<TPrimaryKey>
    {
        protected CountableBaseApiService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        public virtual async Task<int> GetCountAsync()
        {
            return await PostRequestAsync<int>(MethodNames.Global.GetCount);
        }
    }
}