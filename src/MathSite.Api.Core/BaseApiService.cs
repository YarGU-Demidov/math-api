using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        protected BaseApiService(IApiRequester apiRequester)
        {
            ApiRequester = apiRequester;
        }

        protected abstract string ServiceName { get; }
        protected IApiRequester ApiRequester { get; }

        protected ServiceMethod GetMethod(string methodName, string serviceName = null)
        {
            return new ServiceMethod(serviceName ?? ServiceName, methodName);
        }

        protected async Task<TReturn> GetRequestAsync<TReturn>(string methodName, MethodArgs args = null)
        {
            return GetResponseOrFail(
                await ApiRequester.GetAsync<ApiResponse<TReturn>>(GetMethod(methodName), args)
            );
        }

        protected async Task GetRequestAsync(string methodName, MethodArgs args = null)
        {
            FailIfError(
                await ApiRequester.GetAsync<VoidApiResponse<string>>(GetMethod(methodName), args)
            );
        }

        protected async Task<TReturn> PostRequestAsync<TReturn>(string methodName, MethodArgs args = null, IDictionary<string, IEnumerable<Stream>> files = null)
        {
            return GetResponseOrFail(
                await ApiRequester.PostAsync<ApiResponse<TReturn>>(GetMethod(methodName), args, files)
            );
        }

        protected async Task PostRequestAsync(string methodName, MethodArgs args = null)
        {
            FailIfError(
                await ApiRequester.PostAsync<VoidApiResponse<string>>(GetMethod(methodName), args)
            );
        }

        private TReturn GetResponseOrFail<TReturn>(ApiResponse<TReturn> response)
        {
            FailIfError(response);

            return response.Data;
        }

        private void FailIfError(ApiResponse response)
        {
            if (response.HasError())
                throw new ApiExecutionException(response.Reason);
        }

        protected IEnumerable<string> ToStringEnumerable<T>(IEnumerable<T> data) where T : BaseEntity<TPrimaryKey>
        {
            return data.Select(dto => dto.Id.ToString());
        }
    }

    public abstract class ApiService { }
}