using System;
using System.Threading.Tasks;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Core
{
    public abstract class CrudPageableWithAliasBaseApiService<T> : CrudPageableBaseApiService<T, Guid>
        where T: BaseEntityWithAlias
    {
        protected CrudPageableWithAliasBaseApiService(IApiRequester apiRequester) : base(apiRequester)
        {
        }
    }

    public abstract class CrudPageableWithAliasBaseApiService<T, TPrimaryKey> : CrudPageableBaseApiService<T, TPrimaryKey>
        where T: BaseEntityWithAlias<TPrimaryKey>
    {
        protected CrudPageableWithAliasBaseApiService(IApiRequester apiRequester) 
            : base(apiRequester)
        {
        }

        public Task<T> GetByAliasAsync(string alias)
        {
            var args = new MethodArgs
            {
                {nameof(alias), alias}
            };

            return GetRequestAsync<T>(MethodNames.Global.GetByAlias, args);
        }
    }
}