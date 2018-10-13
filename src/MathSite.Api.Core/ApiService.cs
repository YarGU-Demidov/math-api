using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MathSite.Common.ApiServiceRequester.Abstractions;

namespace MathSite.Api.Core
{
    public abstract class ApiService
    {
        protected ApiService(IApiRequester apiRequester)
        {
            ApiRequester = apiRequester;
        }

        public bool ShouldRaiseException { get; set; }

        protected abstract string ServiceName { get; }
        protected IApiRequester ApiRequester { get; }

        protected ServiceMethod GetMethod(string methodName, string serviceName = null)
        {
            return new ServiceMethod(serviceName ?? ServiceName, methodName);
        }

        protected async Task<TReturn> GetRequestAsync<TReturn>(string methodName, MethodArgs args = null)
        {
            var raiseOnFail = GetAndResetShouldRaiseException();
            var response = await ApiRequester.GetAsync<ApiResponse<TReturn>>(GetMethod(methodName), args);

            return raiseOnFail
                ? GetResponseOrFail(response)
                : GetResponseOrDefault(response);
        }

        protected async Task GetRequestAsync(string methodName, MethodArgs args = null)
        {
            var raiseOnFail = GetAndResetShouldRaiseException();
            var response = await ApiRequester.GetAsync<VoidApiResponse<string>>(GetMethod(methodName), args);

            if (raiseOnFail)
                FailIfError(response);
        }

        protected async Task<TReturn> PostRequestAsync<TReturn>(string methodName, MethodArgs args = null,
            IDictionary<string, IEnumerable<Stream>> files = null)
        {
            var raiseOnFail = GetAndResetShouldRaiseException();
            var response = await ApiRequester.PostAsync<ApiResponse<TReturn>>(GetMethod(methodName), args, files);

            return raiseOnFail
                ? GetResponseOrFail(response)
                : GetResponseOrDefault(response);
        }

        protected async Task PostRequestAsync(string methodName, MethodArgs args = null)
        {
            var raiseOnFail = GetAndResetShouldRaiseException();
            var response = await ApiRequester.PostAsync<VoidApiResponse<string>>(GetMethod(methodName), args);

            if (raiseOnFail)
                FailIfError(response);
        }

        private TReturn GetResponseOrFail<TReturn>(ApiResponse<TReturn> response)
        {
            FailIfError(response);

            return response.Data;
        }

        private TReturn GetResponseOrDefault<TReturn>(ApiResponse<TReturn> response)
        {
            return response.HasError()
                ? default
                : response.Data;
        }

        private void FailIfError(ApiResponse response)
        {
            if (response.HasError())
                throw new ApiExecutionException(response.Reason);
        }

        private bool GetAndResetShouldRaiseException()
        {
            var value = ShouldRaiseException;
            ShouldRaiseException = true;
            return value;
        }
    }
}