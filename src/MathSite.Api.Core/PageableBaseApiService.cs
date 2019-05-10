using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Core
{
    public abstract class PageableBaseApiService<T> : PageableBaseApiService<T, Guid> where T : BaseEntity
    {
        protected PageableBaseApiService(IApiRequester apiRequester) : base(apiRequester)
        {
        }
    }

    public abstract class PageableBaseApiService<T, TPrimaryKey> : CountableBaseApiService<TPrimaryKey> where T : BaseEntity<TPrimaryKey>
    {
        protected PageableBaseApiService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        public virtual async Task<IEnumerable<T>> GetAllPagedAsync(int page, int perPage)
        {
            var args = new MethodArgs
            {
                {nameof(page), page.ToString()},
                {nameof(perPage), perPage.ToString()}
            };

            return await GetRequestAsync<IEnumerable<T>>(MethodNames.Global.GetPaged, args);
        }
    }
}