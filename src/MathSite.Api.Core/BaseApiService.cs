using System;
using System.Collections.Generic;
using System.Linq;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Core
{
    public abstract class BaseApiService : BaseApiService<Guid>
    {
        protected BaseApiService(IApiRequester apiRequester) : base(apiRequester)
        {
        }
    }

    public abstract class BaseApiService<TPrimaryKey> : ApiService
    {
        protected BaseApiService(IApiRequester apiRequester) : base(apiRequester)
        {
        }

        protected IEnumerable<string> ToStringEnumerable<T>(IEnumerable<T> data) where T : BaseEntity<TPrimaryKey>
        {
            return data.Select(dto => dto.Id.ToString());
        }
    }
}