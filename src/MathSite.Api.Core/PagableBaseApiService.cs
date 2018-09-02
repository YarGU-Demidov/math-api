using System.Collections.Generic;
using System.Threading.Tasks;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Core
{
    public abstract class PagableBaseApiService<T> : CountableBaseApiService where T : BaseEntity
    {
        protected PagableBaseApiService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        public virtual async Task<IEnumerable<T>> GetAllPagedAsync(int page, int perPage)
        {
            var args = new MethodArgs
            {
                {"page", page.ToString()},
                {"perPage", perPage.ToString()}
            };

            return await PostRequestAsync<IEnumerable<T>>(MethodNames.Global.GetPaged, args);
        }
    }
}