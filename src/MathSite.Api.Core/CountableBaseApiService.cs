using System.Threading.Tasks;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Core
{
    public abstract class CountableBaseApiService : BaseApiService
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