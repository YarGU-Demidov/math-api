using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MathSite.Api.Internal;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Core
{
    public abstract class CrudPageableWithAliasBaseApiService<T> : CrudPageableWithAliasBaseApiService<T, Guid>
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

        public Task<IEnumerable<T>> GetByAliasAsync(string alias)//TODO Changed API
        {
            var args = new MethodArgs
            {
                {nameof(alias), alias}
            };

            return GetRequestAsync< IEnumerable<T>>(MethodNames.Global.GetByAlias, args);
        }
    }
}